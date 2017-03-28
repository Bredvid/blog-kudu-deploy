using Newtonsoft.Json;

public class SlackMessage
{
    [JsonProperty(PropertyName = "username")]
    public string Username { get; set; }
    [JsonProperty(PropertyName = "icon_emoji")]
    public string IconEmoji { get; set; }
    [JsonProperty(PropertyName = "text")]
    public string Text { get; set; }
    [JsonProperty(PropertyName = "channel")]
    public string Channel { get; set; }

    public static SlackMessage From(KuduDeployResult result)
    {
        return new SlackMessage
        {
            Username = (result.IsSuccess ? "Published: " : "Failed: ")
                + (result.SiteName ?? "unknown"),
            IconEmoji = result.IsSuccess ? ":shipit:" : ":warning:",
            Text = $@"Initiated by: {result.Author ?? "unknown"} {result.EndTime:O}
<https://{result.SiteName}|{result.SiteName}> Id: {result.Id}{Environment.NewLine}```{result.Message}```",
            Channel = "channel"
        };
    } 

    public SlackMessage ToChannel(string channel) 
    {
        Channel = channel;
        return this;
    }
}
