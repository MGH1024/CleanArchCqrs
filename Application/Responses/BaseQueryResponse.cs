﻿namespace Application.Responses;

public class BaseQueryResponse<T> where T : class
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public T Data { get; set; }
}