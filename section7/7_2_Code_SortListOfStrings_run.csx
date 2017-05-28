using System.Net;

public static HttpResponseMessage Run(HttpRequestMessage req, TraceWriter log)
{    
    log.Info("C# HTTP trigger function processed a request.");

    string inputStrings = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "list", true) == 0)
        .Value;

    if (list == null) {
      return req.CreateResponse(HttpStatusCode.BadRequest, "Please add list to the query string");
    }

    var individualStrings = inputStrings.Split(',').ToList<string>();
    individualStrings.Sort();
    
    return req.CreateResponse(HttpStatusCode.OK, "master: " + string.Join(",", individualStrings));
}
