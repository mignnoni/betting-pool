using Ardalis.Result;
using MediatR;

namespace BettingPool.SharedKernel.Application
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, Result<TResult>>
        where TCommand : ICommand<TResult>
    {
    }
}
