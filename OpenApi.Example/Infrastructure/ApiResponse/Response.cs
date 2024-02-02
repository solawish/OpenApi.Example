﻿namespace OpenApi.Example.Infrastructure.ApiResponse;

public class Response<T>
{
    public string Code { get; set; }

    public string Message { get; set; }

    public T Data { get; set; }
}