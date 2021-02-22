using System;
using System.Collections.Generic;
using System.Text;

namespace MartianExplorationDomain.RobotCommands
{
    public interface IRobotCommand
    {
        public void ProcessCommand(Mars mars, Robot robot);
    }
}
