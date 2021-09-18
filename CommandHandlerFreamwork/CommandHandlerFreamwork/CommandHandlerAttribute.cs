using System;

namespace CommandHandlerFreamwork
{
    public class CommandHandlerAttribute : Attribute
    {
        public CommandHandlerAttribute(DialogCommandCode handledCode)
        {
            HandledCode = handledCode;
        }

        public DialogCommandCode HandledCode { get; }
    }

}
