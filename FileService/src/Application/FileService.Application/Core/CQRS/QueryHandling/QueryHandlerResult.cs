﻿using FluentValidation.Results;

namespace FileService.Application.Core.CQRS.QueryHandling;

/// <summary>
/// QueryHandler result class
/// </summary>
/// <typeparam name="TResult"></typeparam>
public record class QueryHandlerResult<TResult>
{
    public ValidationResult ValidationResult { get; }

    public TResult Result { get; set; }

    public QueryHandlerResult(IQuery<QueryHandlerResult<TResult>> query)
    {
        ValidationResult = query.Validate();
    }
}
