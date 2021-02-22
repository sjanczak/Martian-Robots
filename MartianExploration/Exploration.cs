using System;
using System.Collections.Generic;
using MartianExplorationDomain;

namespace MartianExploration
{
    public class Exploration
    {
        // A robot position consists of a grid coordinate (a pair of integers: x-coordinate followed by
        // y-coordinate) and an orientation (N, S, E, W for north, south, east, and west).
        // A robot instruction is a string of the letters “L”, “R”, and “F” which represent, respectively, the
        // instructions:
        // ● Left : the robot turns left 90 degrees and remains on the current grid point.
        // ● Right : the robot turns right 90 degrees and remains on the current grid point.
        // ● Forward : the robot moves forward one grid point in the direction of the current
        // orientation and maintains the same orientation.    

        // Since the grid is rectangular and bounded (…yes Mars is a strange planet), a robot that
        // moves “off” an edge of the grid is lost forever. However, lost robots leave a robot “scent” that
        // prohibits future robots from dropping off the world at the same grid point. The scent is left at
        // the last grid position the robot occupied before disappearing over the edge. An instruction to
        // move “off” the world from a grid point from which a robot has been previously lost is simply
        // ignored by the current robot.

        // Resrictions
        // The maximum value for any coordinate is 50.
        // All instruction strings will be less than 100 characters in length.  

        private Mars Mars { get; }
        private List<Robot> Robots { get; }

        public Exploration(string telemetryCommands)
        { 
            var telemetryInterpretor = new TelemetryInterpretor();

            telemetryInterpretor.ConvertInstructions(telemetryCommands);

            Mars = new Mars() {TopRight = telemetryInterpretor.MarsEndOfGridCoordinates};
            Robots = telemetryInterpretor.Robots;            
        }

        public string ProcessRobots()
        {
            var robotFinalPositions = new List<string>();

            foreach (var robot in Robots)
            {
                robotFinalPositions.Add(robot.ProcessInstructions(Mars));
            }

            return String.Join("\\r\\n", robotFinalPositions);
        }
    }
}
