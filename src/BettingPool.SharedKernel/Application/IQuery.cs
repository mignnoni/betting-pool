using Ardalis.Result;
using MediatR;

namespace BettingPool.SharedKernel.Application;

/// <summary>
/// Represents the query interface.
/// </summary>
/// <typeparam name="TResponse">The query response type.</typeparam>
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
