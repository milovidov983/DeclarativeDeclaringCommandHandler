using System;
using System.Collections.Generic;
using System.Text;

namespace CommandHandlerFreamwork
{
    public class TestService
    {
        public List<(string HandlerFunctionName, string TestData)> DataCollection { get; } 
            = new List<(string callerName, string TestData)>();
        public void Execute(string functionName, string payload)
        {
            DataCollection.Add(
                (
                    HandlerFunctionName: functionName,
                    TestData: payload
                )
            );
        }
    }
}
