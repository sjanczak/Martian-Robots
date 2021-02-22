using MartianExplorationDomain.Enums;
using MartianExplorationDomain.RobotCommands;
using System;
using System.Collections.Generic;

namespace MartianExplorationDomain
{
    public class TelemetryInterpretor
    {
        public Coordinates MarsEndOfGridCoordinates { get; private set; } = new Coordinates() {X = 0, Y = 0};
        public List<Robot> Robots { get; private set; } = new List<Robot>();

        const int MAX_COORDINATE = 50;

        public void ConvertInstructions(string telemetryCommands)
        {            
            var dataLines = telemetryCommands.Split("\\r\\n");

            if ((dataLines.Length - 1) % 2 != 0) throw new ArgumentException("There are an uneven number of lines, each robot should only have 2 lines", nameof(telemetryCommands));

            MarsEndOfGridCoordinates = GetCoordinates(dataLines[0], MAX_COORDINATE, MAX_COORDINATE);

            for (int line = 1; line < dataLines.Length; line = line + 2)
            {
                var position = GetOrientatedCoordinates(dataLines[line].Trim(' '), MarsEndOfGridCoordinates.X, MarsEndOfGridCoordinates.Y);                
                var instructions = GetRobotInstruction(dataLines[line+1].Trim(' '));                

                Robots.Add(new Robot(position, instructions));
            }
        }

        private OrientatedCoordinates GetOrientatedCoordinates(string orientatedCoordinates, int maxX, int maxY)
        {
            orientatedCoordinates = orientatedCoordinates.TrimEnd(' ');

            var orientationLetter = orientatedCoordinates.Substring(orientatedCoordinates.Length - 1, 1);
            var coordinateNumbers = orientatedCoordinates.Substring(0, orientatedCoordinates.Length -1);

            OrientationEnum orientation;

            if (!Enum.TryParse(orientationLetter, true, out orientation)) throw new ArgumentException($"Orientation is not valid - {orientation}", nameof(orientatedCoordinates));

            var coordinate = GetCoordinates(coordinateNumbers, maxX, maxY);

            return new OrientatedCoordinates() {Orientation = orientation, X = coordinate.X, Y = coordinate.Y};
        }

        private Coordinates GetCoordinates(string coordinates, int maxX, int maxY)
        {
            var coordinatenumbers = coordinates.TrimEnd(' ').Split(' ');

            int x;
            int y;

            if (!int.TryParse(coordinatenumbers[0], out x))
            {
                throw new ArgumentException($"First coordinate is not a number - {coordinatenumbers[0]}", nameof(coordinates)); 
            }
            else if (x > maxX)
            {
                throw new ArgumentException($"X coordinate {x} is greater than max {maxX}", nameof(coordinates));
            }

            if (!int.TryParse(coordinatenumbers[1], out y))
            {
                throw new ArgumentException($"First coordinate is not a number - {coordinatenumbers[1]}", nameof(coordinates));
            }
            else if (y > maxY)
            {
                throw new ArgumentException($"Y coordinate {y} is greater than max {maxY}", nameof(coordinates));                
            }

            return new Coordinates() {X = x, Y = y};
        }

        private RobotInstructions GetRobotInstruction(string commands)
        {
            if (commands.Length >= 100) throw new ArgumentException("All instruction strings should be less than 100 characters in length", nameof(commands));

            var robotInstruction = new RobotInstructions();

            foreach (char command in commands.ToCharArray())
            {
                switch (command)
                {
                    case 'L':
                        robotInstruction.Commands.Add(new LeftRobotCommand());
                        break;
                    case 'R':
                        robotInstruction.Commands.Add(new RightRobotCommand());
                        break;
                    case 'F':
                        robotInstruction.Commands.Add(new ForwardRobotCommand());
                        break;
                    default:
                        throw new ArgumentException($"Command '{command}' is not valid", nameof(commands));
                }
            }

            return robotInstruction;
        }
    }
}
