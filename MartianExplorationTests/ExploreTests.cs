using Microsoft.VisualStudio.TestTools.UnitTesting;
using MartianExploration;
using System;

namespace RobotTests
{
    [TestClass]
    public class ExploreTests
    {
        // The Input
        // The first line of input is the upper-right coordinates of the rectangular world, the lower-left
        // coordinates are assumed to be 0, 0.
        // The remaining input consists of a sequence of robot positions and instructions (two lines per
        // robot). A position consists of two integers specifying the initial coordinates of the robot and
        // an orientation (N, S, E, W), all separated by whitespace on one line. A robot instruction is a
        // string of the letters �L�, �R�, and �F� on one line.
        // Each robot is processed sequentially, i.e., finishes executing the robot instructions before the
        // next robot begins execution.
        // The maximum value for any coordinate is 50.
        // All instruction strings will be less than 100 characters in length.

        // The Output
        // For each robot position/instruction in the input, the output should indicate the final grid
        // position and orientation of the robot. If a robot falls off the edge of the grid the word �LOST�
        // should be printed after the position and orientation.

        // Sample Input
        // 5 3
        // 1 1 E
        // RFRFRFRF
        // 3 2 N
        // FRRFLLFFRRFLL
        // 0 3 W
        // LLFFFLFLFL

        // Sample Output
        // 1 1 E
        // 3 3 N LOST
        // 2 3 S

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaximumCoordinateTest()
        {
            string telemetryCommands =
            @"51 51\r\n1 1 E\r\nRFRFRFRF";

            // We should get an expception for this test as the maximum value for any coordinate is 50.
            new Exploration(telemetryCommands);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RobotXCoordinatesOutOfMarsTest()
        {
            string telemetryCommands =
            @"30 30\r\n31 1 E\r\nRFRFRFRF";

            // We should get an expception for this test as the robot x coordinate exceeeds the grid.
            new Exploration(telemetryCommands);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RobotYCoordinatesOutOfMarsTest()
        {
            string telemetryCommands =
            @"30 30\r\n30 31 E\r\nRFRFRFRF";

            // We should get an expception for this test as the robot y coordinate exceeds the grid.
            new Exploration(telemetryCommands);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RobotInstructionToLongTest()
        {
            string telemetryCommands =
            @"50 50\r\n1 1 E\r\nRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRF";

            // We should get an expception for the instaruction cannot exceed 100 characters.
            new Exploration(telemetryCommands);
        }

        [TestMethod]
        public void SingleRobotTest()
        {
            string telemetryCommands = @"5 3\r\n1 1 E\r\nRFRFRFRF";

            string expectedOutput = @"1 1 E";

            var exploration = new Exploration(telemetryCommands);

            var response = exploration.ProcessRobots();

            Assert.AreEqual(expectedOutput, response);
        }

        [TestMethod]
        public void SingleRobotNorthAtTopRightOfMarsTest()
        {
            string telemetryCommands = @"5 5\r\n4 4 N\r\nF";

            string expectedOutput = @"4 5 N";

            var exploration = new Exploration(telemetryCommands);

            var response = exploration.ProcessRobots();

            Assert.AreEqual(expectedOutput, response);
        }


        [TestMethod]
        public void SingleRobotEastAtTopRightOfMarsTest()
        {
            string telemetryCommands = @"5 5\r\n4 4 E\r\nF";

            string expectedOutput = @"5 4 E";

            var exploration = new Exploration(telemetryCommands);

            var response = exploration.ProcessRobots();

            Assert.AreEqual(expectedOutput, response);
        }

        [TestMethod]
        public void TwoRobotTest()
        {
            string telemetryCommands = @"5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL";

            string expectedOutput = @"1 1 E\r\n3 3 N LOST";

            var exploration = new Exploration(telemetryCommands);

            var response = exploration.ProcessRobots();

            Assert.AreEqual(expectedOutput, response);
        }

        [TestMethod]
        public void ThreeRobotTest()
        {
            string telemetryCommands = @"5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFLFLFL";

            string expectedOutput = @"1 1 E\r\n3 3 N LOST\r\n2 3 S";

            var exploration = new Exploration(telemetryCommands);

            var response = exploration.ProcessRobots();

            Assert.AreEqual(expectedOutput, response);
        }

        [TestMethod]
        public void SameRobotInstructionsTest()
        {
            string telemetryCommands = @"10 10\r\n0 0 E\r\nRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRF\r\n0 0 E\r\nRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRF\r\n0 0 E\r\nRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRF\r\n0 0 E\r\nRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRF\r\n0 0 E\r\nRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRF\r\n0 0 E\r\nRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRF\r\n0 0 E\r\nRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRF\r\n0 0 E\r\nRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRF\r\n0 0 E\r\nRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRF\r\n0 0 E\r\nRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRF\r\n0 0 E\r\nRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRFLFRF";

            string expectedOutput = @"0 0 S LOST\r\n1 0 S LOST\r\n2 0 S LOST\r\n3 0 S LOST\r\n4 0 S LOST\r\n5 0 S LOST\r\n6 0 S LOST\r\n7 0 S LOST\r\n8 0 S LOST\r\n9 0 S LOST\r\n10 0 S LOST";

            var exploration = new Exploration(telemetryCommands);

            var response = exploration.ProcessRobots();

            Assert.AreEqual(expectedOutput, response);
        }
    }
}
