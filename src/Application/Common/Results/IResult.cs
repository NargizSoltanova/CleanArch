﻿namespace practice.Application.Common.Results;

public interface IResult
{
    public bool Success { get; }
    public string Message { get; }
}
