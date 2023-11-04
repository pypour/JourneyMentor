using MediatR;

namespace Application.Commands
{
    public interface ICommandHandler<in TCommand> :
        IRequestHandler<TCommand> where TCommand : ICommand
    {

    }
}