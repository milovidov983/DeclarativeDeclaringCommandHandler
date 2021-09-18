using System;
using System.Collections.Generic;
using System.Text;

namespace CommandHandlerFreamwork
{
    public class ActivityCommand : IActivityCommand
    {
        public ActivityCommand(DialogCommandCode commandCode)
        {
            CommandCode = commandCode;
        }

        public DialogCommandCode CommandCode { get; }



    }
}
