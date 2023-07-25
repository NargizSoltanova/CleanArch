﻿namespace practice.Application.Common.Results;

public interface IDataResult<out T> : IResult
{
    T Data { get; }
}
