using System.Threading.Tasks;

namespace CommandHandlerFreamwork
{

    public class ExampleDialog : BaseDialog
    {
        private readonly TestService _testService;

        public ExampleDialog(TestService testService) : base()
        {
            _testService = testService;

            var totalDialogCanHandleCommand = Handlers.Count; // <-- такого мы не можем

        }

        public async Task HandleCommand(IDialogContext context, IActivityCommand command)
        {
            bool canHandle = Handlers.TryGetValue(command.CommandCode, out var handler);

            if (!canHandle)  // <-- такого мы тоже не можем, только путем перебора в огромных switch
                return;

            await handler.ExecuteHandler(context, command);
        }
        
        [CommandHandler(DialogCommandCode.Example1Command)]
        public Task Example1CommandHandlerFunction(IDialogContext context, IActivityCommand command)
        {
            var currentFunctionName = nameof(Example1CommandHandlerFunction);
            _testService.Execute(currentFunctionName, "example-test-data");

            System.Diagnostics.Debug.WriteLine(
                $"\n\n function {currentFunctionName} is executed..\n\n");
            return Task.CompletedTask;
        }

        protected override Task BeforeHandle(IDialogContext context, IActivityCommand command)
        {
            var currentFunctionName = nameof(BeforeHandle);
            _testService.Execute(currentFunctionName, "before-handle-test-data");

            System.Diagnostics.Debug.WriteLine(
                $"\n\n function {currentFunctionName} is executed..\n\n");
            return Task.CompletedTask;
        }
        protected override Task AfterHandle(IDialogContext context, IActivityCommand command)
        {
            var currentFunctionName = nameof(AfterHandle);
            _testService.Execute(currentFunctionName, "after-handle-test-data");

            System.Diagnostics.Debug.WriteLine(
                $"\n\n function {currentFunctionName} is executed..\n\n");
            return Task.CompletedTask;
        }
    }
}
