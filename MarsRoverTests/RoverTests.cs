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
    }
}
