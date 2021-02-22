using System.Collections.Generic;

namespace MartianExplorationDomain
{
    public class Mars
    {
        public List<LostRobotScent> lostRobots { get; } = new List<LostRobotScent>();

        public Coordinates TopRight  { get; set; } = new Coordinates { X = 0, Y = 0 };
        public Coordinates BottomLeft { get; } = new Coordinates { X = 0, Y = 0};

        public bool HasRobotBeenLostFromSamePosition(Robot robot)
        {
            bool robotAlreadyLost = false;

            foreach (var lostRobot in lostRobots)
            {
                if (lostRobot.PreLostPositon.Orientation == robot.CurrentPosition.Orientation
                    && lostRobot.PreLostPositon.Y == robot.CurrentPosition.Y
                    && lostRobot.PreLostPositon.X == robot.CurrentPosition.X)
                {
                    robotAlreadyLost = true;
                    break;
                }
            }

            return robotAlreadyLost;
        }
    }
}
