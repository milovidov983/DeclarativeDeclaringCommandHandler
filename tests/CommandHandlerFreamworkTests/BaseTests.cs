using CommandHandlerFreamwork;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CommandHandlerFreamworkTests
{
    public class BaseTests
    {
        [Fact]
        public async Task HandleExampleDialog_DialogHandledProperly()
        {
            var exampleCommand = new ActivityCommand(DialogCommandCode.Example1Command);
            var context = new DialogContext();
            var exampleService = new TestService();

            var dialogUnderTest = new ExampleDialog(exampleService);

            await dialogUnderTest.HandleCommand(context, exampleCommand);

            var result = exampleService.DataCollection
                .Where(x => 
                x.HandlerFunctionName == nameof(ExampleDialog.Example1CommandHandlerFunction)
                ).ToArray();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);

            var handlerFunctionName = result.First().HandlerFunctionName;
            var testData = result.First().TestData;
            Assert.Equal(nameof(ExampleDialog.Example1CommandHandlerFunction), handlerFunctionName);
            Assert.Equal("example-test-data", testData);


        }
    }
}
