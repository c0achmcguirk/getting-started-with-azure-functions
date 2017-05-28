using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // parse query parameters
    var num1String = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "num1", true) == 0)
        .Value;

    var num2String = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "num2", true) == 0)
        .Value;

    var num1 = StringToNullableInt(num1String);
    var num2 = StringToNullableInt(num2String);

    if (num1 == null || num2 == null) {
        // read values from request body
        dynamic data = await req.Content.ReadAsAsync<object>();

        // set nums to query string or body data
        num1 = num1 ?? data?.num1;
        num2 = num2 ?? data?.num2;
    }

    if (num1 == null) {
        log.Info("Returning bad request for num1");
        return req.CreateResponse(HttpStatusCode.BadRequest, 
        "Please pass in num1 on the query string or in the request body");
    }

    if (num2 == null) {
        log.Info("Returning bad request for num2");
        return req.CreateResponse(HttpStatusCode.BadRequest, 
        "Please pass in num2 on the query string or in the request body");
    }

    var sum = num1 + num2;
    log.Info($"Returning OK with value of {sum} for inputs {num1} + {num2}");
    return req.CreateResponse(HttpStatusCode.OK, sum);
}

public static int? StringToNullableInt(string input) {
    int outValue;
    return int.TryParse(input, out outValue) ? (int?)outValue : null;

}
