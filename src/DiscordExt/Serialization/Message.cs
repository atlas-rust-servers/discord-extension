using System.Collections;
using System.Text;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace Oxide.Ext.DiscordExt;

[Serializable]
public class Message
{
    [JsonProperty("username")]
    private string Username { get; set; }

    [JsonProperty("avatar_url")]
    private string AvatarUrl { get; set; }

    [JsonProperty("content")]
    private string Content { get; set; }

    [JsonProperty("embeds")]
    private List<Embed> Embeds { get; }

    public Message(string username = null, string avatarUrl = null)
    {
        Username = username;
        AvatarUrl = avatarUrl;
        Embeds = new List<Embed>();
    }

    public Message(Embed embed, string username = null, string avatarUrl = null)
    {
        Username = username;
        AvatarUrl = avatarUrl;
        Embeds = new List<Embed> { embed };
    }

    public void AddEmbed(Embed embed)
    {
        if (Embeds.Count >= 10)
            throw new IndexOutOfRangeException("Only 10 embeds are allowed per message!");

        Embeds.Add(embed);
    }

    public void AddContent(string contentIn)
    {
        Content = contentIn;
    }

    public string ToJson() => JsonConvert.SerializeObject(this);

    public void Post(string webhook, Action<UnityWebRequest> onSuccess, Action<UnityWebRequest> onError, params string[] files)
    {
        var forms = new List<IMultipartFormSection>();

        string json = JsonConvert.SerializeObject(this);
        forms.Add(new MultipartFormDataSection("payload_json", json));

        foreach (string path in files)
        {
            if (!File.Exists(path))
                continue;

            byte[] bytes = File.ReadAllBytes(path);
            forms.Add(new MultipartFormFileSection("file", bytes, Path.GetFileName(path), "application/octet-stream"));
        }

        byte[] boundary = UnityWebRequest.GenerateBoundary();
        byte[] formSectionsData = UnityWebRequest.SerializeFormSections(forms, boundary);
        byte[] terminateData = Encoding.UTF8.GetBytes(string.Concat("\r\n--", Encoding.UTF8.GetString(boundary), "--"));
        byte[] postData = new byte[formSectionsData.Length + terminateData.Length];

        Buffer.BlockCopy(formSectionsData, 0, postData, 0, formSectionsData.Length);
        Buffer.BlockCopy(terminateData, 0, postData, formSectionsData.Length, terminateData.Length);

        var uploadHandler = new UploadHandlerRaw(postData);
        uploadHandler.contentType = string.Concat("multipart/form-data; boundary=", Encoding.UTF8.GetString(boundary));

        var request = new UnityWebRequest(webhook, UnityWebRequest.kHttpVerbPOST);
        request.uploadHandler = uploadHandler;
        request.downloadHandler = new DownloadHandlerBuffer();

        IEnumerator task = AwaitWebRequest(request, www => HandleWebRequestResult(www, onSuccess, onError));
        ServerMgr.Instance.StartCoroutine(task);
    }

    private static IEnumerator AwaitWebRequest(UnityWebRequest request, Action<UnityWebRequest> onComplete)
    {
        yield return request.SendWebRequest();

        onComplete.Invoke(request);
    }

    private static void HandleWebRequestResult(UnityWebRequest request, Action<UnityWebRequest> onSuccess, Action<UnityWebRequest> onError)
    {
        if (request.result == UnityWebRequest.Result.Success)
            onSuccess?.Invoke(request);
        else
            onError?.Invoke(request);

        request.Dispose();
    }
}