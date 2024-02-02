using System.Net;

namespace OpenApi.Example.Infrastructure.ApiResultCodes;

public class ApiResultCode
{
    public ApiResultCode(string code, string message, HttpStatusCode httpStatusCode)
    {
        Code = code;
        Message = message;
        HttpStatusCode = httpStatusCode;
    }

    public string Code { get; set; }

    public string Message { get; set; }

    public HttpStatusCode HttpStatusCode { get; set; }
}