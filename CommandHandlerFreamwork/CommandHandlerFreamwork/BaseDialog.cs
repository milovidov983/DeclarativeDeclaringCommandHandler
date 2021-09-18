using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CommandHandlerFreamwork
{
    public abstract class BaseDialog
    {
        protected Dictionary<DialogCommandCode, CommandHandlerContainer>
            Handlers = new Dictionary<DialogCommandCode, CommandHandlerContainer>();

        private readonly Type _currentDialogType;

        protected BaseDialog()
        {
            _currentDialogType = GetType();
            InitCommandHandlers();
        }

        private void InitCommandHandlers()
        {

            Handlers = _currentDialogType
                .GetMethods()
                .Where(y => y.GetCustomAttributes().OfType<CommandHandlerAttribute>().Any())
                .ToDictionary(
                    z => z.GetCustomAttribute<CommandHandlerAttribute>().HandledCode,
                    z => new CommandHandlerContainer
                        (
                            handler: async (IDialogContext context, IActivityCommand command) =>
                               {
                                   await BeforeHandle(context, command);
                                   await (Task)z.Invoke(this, new object[] { context, command });
                                   await AfterHandle(context, command);
                               },
                            handlerName: z.Name
                       )
                    );


        }

        protected virtual Task BeforeHandle(IDialogContext context, IActivityCommand command) => Task.CompletedTask;
        protected virtual Task AfterHandle(IDialogContext context, IActivityCommand command) => Task.CompletedTask;
        protected virtual Task BeforeStart(IDialogContext context, IActivityCommand command) => Task.CompletedTask;
        protected virtual Task AfterStart(IDialogContext context, IActivityCommand command) => Task.CompletedTask;
    }

}
