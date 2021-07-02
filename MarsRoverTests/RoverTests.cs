using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover newRover = new Rover(300);
            Assert.AreEqual(newRover.Position, 300);
        }

        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover newRover = new Rover(300);
            Assert.AreEqual(newRover.Mode, "NORMAL");
        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover newRover = new Rover(300);
            Assert.AreEqual(newRover.GeneratorWatts, 110);
        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Command[] commands = { new Command("MODE_CHANGE") };
            Message newMessage = new Message("Go to bed", commands);
            Rover newRover = new Rover(700);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(newRover.Mode, "LOW_POWER");
        }

        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Rover newRover = new Rover(10);
            Command[] testCommandsOne = { new Command("MODE_CHANGE") };
            Command[] testCommandsTwo = { new Command("MOVE", 200) };
            newRover.ReceiveMessage(new Message("Power Down", testCommandsOne));
            newRover.ReceiveMessage(new Message("Try to Move", testCommandsTwo));
            Assert.AreEqual(newRover.Mode, "LOW_POWER");
            Assert.AreEqual(newRover.Position, 10);
        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Rover newRover = new Rover(10);
            Command[] testCommands = { new Command("MOVE", 200), new Command("MODE_CHANGE") };
            newRover.ReceiveMessage(new Message("Move, then sleep", testCommands));
            Assert.AreEqual(newRover.Position, 200);
            Command[] testCommandsTwo = { new Command("MOVE", 400), new Command("MODE_CHANGE") };
            newRover.ReceiveMessage(new Message("Try moving, then sleep", testCommandsTwo));
            Assert.AreEqual(newRover.Position, 200);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RoverReturnsAMessageForAnUnknownCommand()
        {
            Rover newRover = new Rover(50);
            Command[] testCommands = { new Command("SLEEP") };
            newRover.ReceiveMessage(new Message("Singing is not a valid command", testCommands));
        }
    }
}
