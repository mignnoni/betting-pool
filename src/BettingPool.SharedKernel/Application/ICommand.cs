using MediatR;
using Ardalis.Result;

namespace BettingPool.SharedKernel.Application;

public interface ICommand : IRequest<Result>
{

}

public interface ICommand<TResult> : IRequest<Result<TResult>>
{

}