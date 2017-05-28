using System.Net;

public static HttpResponseMessage Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    var numerator = 10;
    var denominator = 5;

    var result = numerator/denominator;

    return req.CreateResponse(HttpStatusCode.OK, result);
}
