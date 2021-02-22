using MartianExplorationDomain.RobotCommands;
using System.Collections.Generic;

namespace MartianExplorationDomain
{
    public class RobotInstructions
    {
        public List<IRobotCommand> Commands { get; } = new List<IRobotCommand>();
    }
}
