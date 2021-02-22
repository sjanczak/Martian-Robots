namespace MartianExplorationDomain
{
    public class Robot
    {
        public OrientatedCoordinates InitalPosition { get; }

        public OrientatedCoordinates CurrentPosition { get; }

        public RobotInstructions Instructions { get; set; }

        public bool Lost { get; private set; } = false;

        public Robot(OrientatedCoordinates position, RobotInstructions instruction)
        {
            InitalPosition = position;
            CurrentPosition = new OrientatedCoordinates() { Orientation = InitalPosition.Orientation, X = InitalPosition.X, Y = InitalPosition.Y };
            Instructions = instruction;
        }

        public string ProcessInstructions(Mars mars)
        {
            foreach(var command in Instructions.Commands)
            {
                command.ProcessCommand(mars, this);

                if (Lost)
                    break;
            }

            var finalPosition = $"{CurrentPosition.X} {CurrentPosition.Y} {CurrentPosition.Orientation}";

            if (Lost)
                finalPosition += " LOST";

            return finalPosition;
        }

        public void RobotFellOffMars(Mars mars)
        {
            Lost = true;
            mars.lostRobots.Add(new LostRobotScent() { PreLostPositon = CurrentPosition });
        }
    }
}
