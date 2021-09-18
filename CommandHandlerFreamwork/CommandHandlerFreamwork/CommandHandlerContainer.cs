using System;
using System.Threading.Tasks;

namespace CommandHandlerFreamwork
{
    public class CommandHandlerContainer
    {
        public CommandHandlerContainer(
            Func<IDialogContext, IActivityCommand, Task> handler, 
            string handlerName)
        {
            Handler = handler;
            HandlerName = handlerName;
        }

        public Func<IDialogContext, IActivityCommand, Task> Handler { get; }
        public string HandlerName { get; }


        public Task ExecuteHandler(IDialogContext context, IActivityCommand command)
        {
            return Handler(context, command);
           
        }
    }

}
