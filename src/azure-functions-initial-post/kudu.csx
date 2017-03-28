
public class KuduDeployResult
{
    public string Id { get; set; }
    public string Status { get; set; }
    public string StatusText { get; set; }
    public string AuthorEmail { get; set; }
    public string Author { get; set; }
    public string Message { get; set; }
    public string Progress { get; set; }
    public string Deployer { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime ReceviedTime { get; set; }
    public DateTime LastSuccessEndTime { get; set; }
    public bool Complete { get; set; }
    public string SiteName { get; set; }

    public bool IsSuccess => Status == "success";
}