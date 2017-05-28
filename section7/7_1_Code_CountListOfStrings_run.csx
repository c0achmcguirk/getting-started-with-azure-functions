using System.Net;

public static HttpResponseMessage Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request. Updated again.");

    // parse query parameter
    string list = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "list", true) == 0)
        .Value;
    
    if (list == null) {
        return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a list on the query string");
    }

    var count = list.Split(',').ToList().Count();
    return req.CreateResponse(HttpStatusCode.OK, $"The count is {count}");
}
