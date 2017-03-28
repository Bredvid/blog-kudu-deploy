#r "Newtonsoft.Json"
#load "./extensions.csx"
#load "./kudu.csx"
#load "./slack.csx"

using System.Net;
using Newtonsoft.Json;
using System.Configuration;
using System.Text;
 
public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");
    
    var channel = ConfigurationManager.AppSettings["slack.channel"];
    var outgoingWebhook = ConfigurationManager.AppSettings["slack.webhook"];

    // Get request body
    var data = await req.Content.ReadAsAsync<KuduDeployResult>();
    
    var slackMessage = SlackMessage.From(data)
        .ToChannel(channel)
        .Map(JsonConvert.SerializeObject)
        .Map(x => new StringContent(x, Encoding.UTF8, "application/json"));
    
    using (var httpClient = new HttpClient())
    {
        var httpResponse = await httpClient.PostAsync(outgoingWebhook, slackMessage);
        if (!httpResponse.IsSuccessStatusCode) {
            return  req.CreateResponse(httpResponse.StatusCode , $"Status: {httpResponse.StatusCode} {httpResponse.ReasonPhrase}");
        }
    }
    return  req.CreateResponse(HttpStatusCode.OK);
}
