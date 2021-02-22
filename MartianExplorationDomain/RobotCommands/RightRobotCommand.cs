using MartianExplorationDomain.Enums;
using System;

namespace MartianExplorationDomain.RobotCommands
{
    public class RightRobotCommand : IRobotCommand
    {
        public void ProcessCommand(Mars mars, Robot robot)
        {
            robot.CurrentPosition.Orientation = OrientateRight(robot.CurrentPosition.Orientation);
        }

        private OrientationEnum OrientateRight(OrientationEnum currentOrientation)
        {
            OrientationEnum newOrientation = currentOrientation;

            switch (currentOrientation)
            {
                case OrientationEnum.N:
                    newOrientation = OrientationEnum.E;
                    break;
                case OrientationEnum.E:
                    newOrientation = OrientationEnum.S;
                    break;
                case OrientationEnum.S:
                    newOrientation = OrientationEnum.W;
                    break;
                case OrientationEnum.W:
                    newOrientation = OrientationEnum.N;
                    break;
            }

            return newOrientation;
        }
    }
}
