using System.Net;

namespace OpenApi.Example.Infrastructure.ApiResultCodes;

public class ConstApiReslutCodes
{
    public static ApiResultCode Success { get; } =
        new ApiResultCode("0000", "執行成功", HttpStatusCode.OK);

    public static ApiResultCode PageNotFound { get; } =
        new ApiResultCode("B0001", "查無頁面", HttpStatusCode.NotFound);

    public static ApiResultCode BadRequest { get; } =
       new ApiResultCode("B0004", "參數錯誤", HttpStatusCode.BadRequest);

    public static ApiResultCode Forbidden { get; } =
       new ApiResultCode("B0007", "權限不足", HttpStatusCode.Forbidden);

    public static ApiResultCode Unauthorized { get; } =
        new ApiResultCode("B9998", "未登入", HttpStatusCode.Unauthorized);

    public static ApiResultCode InteralServerError { get; } =
        new ApiResultCode("B9999", "系統異常", HttpStatusCode.InternalServerError);
}