using MartianExplorationDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianExplorationDomain.RobotCommands
{
    public  class ForwardRobotCommand : IRobotCommand
    {
        public void ProcessCommand(Mars mars, Robot robot)
        {
            MoveForwards(mars, robot);
        }

        private void MoveForwards(Mars mars, Robot robot)
        {
            switch (robot.CurrentPosition.Orientation)
            {
                case OrientationEnum.N:
                    if (robot.CurrentPosition.Y+1 <= mars.TopRight.Y)
                    {
                        robot.CurrentPosition.Y = robot.CurrentPosition.Y + 1;
                    }
                    else
                    {
                        ProcessRobotLost(mars, robot);
                    }
                    break;
                case OrientationEnum.E:
                    if (robot.CurrentPosition.X+1 <= mars.TopRight.X)
                    {
                        robot.CurrentPosition.X = robot.CurrentPosition.X + 1;
                    }
                    else
                    {
                        ProcessRobotLost(mars, robot);
                    }
                    break;
                case OrientationEnum.S:
                    if (robot.CurrentPosition.Y - 1 >= mars.BottomLeft.Y)
                    {
                        robot.CurrentPosition.Y = robot.CurrentPosition.Y - 1;
                    }
                    else
                    {
                        ProcessRobotLost(mars, robot);
                    }
                    break;
                case OrientationEnum.W:
                    if (robot.CurrentPosition.X - 1 >= mars.BottomLeft.X)
                    {
                        robot.CurrentPosition.X = robot.CurrentPosition.X - 1;
                    }
                    else
                    {
                        ProcessRobotLost(mars, robot);
                    }
                    break;
            }
        }

        private void ProcessRobotLost(Mars mars, Robot robot)
        {
            // if a robot is going to be lost we fisrt need to check for previous lost robots. 
            // If we had a robot lost in the same position the previous robots lost scent saves 
            // this robot as it does not process the command.
            if (!mars.HasRobotBeenLostFromSamePosition(robot))
            {
                robot.RobotFellOffMars(mars);
            }
        }
    }
}
