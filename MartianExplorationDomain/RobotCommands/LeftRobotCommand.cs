using MartianExplorationDomain.Enums;
using System;

namespace MartianExplorationDomain.RobotCommands
{
    public  class LeftRobotCommand : IRobotCommand
    {
        public void ProcessCommand(Mars mars, Robot robot)
        {
            robot.CurrentPosition.Orientation = OrientateLeft(robot.CurrentPosition.Orientation);
        }

        private OrientationEnum OrientateLeft(OrientationEnum currentOrientation)
        {
            OrientationEnum newOrientation = currentOrientation;

            switch (currentOrientation)
            {
                case OrientationEnum.N:
                    newOrientation = OrientationEnum.W;
                    break;
                case OrientationEnum.E:
                    newOrientation = OrientationEnum.N;
                    break;
                case OrientationEnum.S:
                    newOrientation = OrientationEnum.E;
                    break;
                case OrientationEnum.W:
                    newOrientation = OrientationEnum.S;
                    break;
            }

            return newOrientation;
        }
    }
}
