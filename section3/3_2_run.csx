// Github Trigger
using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Extract github comment from request body
    string gitHubComment = data?.comment?.body;

    log.Info($"The comment was { gitHubComment }");

    return req.CreateResponse(HttpStatusCode.OK, "From Github:" + gitHubComment);
}

// Timer Trigger
using System.Net;

public static void Run(TimerInfo myTimer, TraceWriter log) 
{
    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
}


// Http Trigger
using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    dynamic data = await req.Content.ReadAsAsync<object>();

    log.Info($"Data is {data?.comment}");

    return data == null ?
        req.CreateResponse(HttpStatusCode.BadRequest, "Please pass me some data") :
        req.CreateResponse(HttpStatusCode.OK, "Hello, thanks for the data.");
}
