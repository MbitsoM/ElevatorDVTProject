using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elevator_DVT_Assessment.UnitTesting
{
    [TestClass]
    public class ElevatorManagerTests
    {
        [TestMethod]
        public void TestGetNearestElevator()
        {
            // Arrange
            int numberOfElevators = 2;
            int numberOfFloors = 5;
            int elevatorCapacity = 10;
            int elevatorWeightLimit = 1000;
            var elevatorManager = new ElevatorManager(numberOfElevators, numberOfFloors, elevatorCapacity, elevatorWeightLimit);
            var targetFloor = 3;

            // Act
            var nearestElevator = elevatorManager.GetNearestElevator(targetFloor);

            // Assert
            Assert.IsNotNull(nearestElevator);
            // Add more specific assertions if needed.
        }

        [TestMethod]
        public void TestCallElevator()
        {
            // Arrange
            int numberOfElevators = 2;
            int numberOfFloors = 5;
            int elevatorCapacity = 10;
            int elevatorWeightLimit = 1000;
            var elevatorManager = new ElevatorManager(numberOfElevators, numberOfFloors, elevatorCapacity, elevatorWeightLimit);
            var floorNumber = 3;
            var numberOfPeopleWaiting = 5;

            // Act
            elevatorManager.CallElevator(floorNumber, numberOfPeopleWaiting);

            // Assert
            var elevator = elevatorManager.GetNearestElevator(floorNumber);
            Assert.AreEqual(floorNumber, elevator.CurrentFloor);
            Assert.AreEqual(numberOfPeopleWaiting, elevator.NumberOfPeople);
        }

        [TestMethod]
        public void TestCallElevatorExceedWeightLimit()
        {
            // Arrange
            int numberOfElevators = 2;
            int numberOfFloors = 5;
            int elevatorCapacity = 10;
            int elevatorWeightLimit = 1000;
            var elevatorManager = new ElevatorManager(numberOfElevators, numberOfFloors, elevatorCapacity, elevatorWeightLimit);
            var floorNumber = 1;
            var numberOfPeopleWaiting = 7; // Exceeds elevator capacity

            // Act
            elevatorManager.CallElevator(floorNumber, numberOfPeopleWaiting);

            // Assert
            var elevator = elevatorManager.GetNearestElevator(floorNumber);
            Assert.AreEqual(0, elevator.NumberOfPeople); // Weight limit should not be exceeded.
        }

        [TestMethod]
        public void TestCallElevatorInvalidFloor()
        {
            // Arrange
            int numberOfElevators = 2;
            int numberOfFloors = 5;
            int elevatorCapacity = 10;
            int elevatorWeightLimit = 1000;
            var elevatorManager = new ElevatorManager(numberOfElevators, numberOfFloors, elevatorCapacity, elevatorWeightLimit);
            var floorNumber = 10; // Invalid floor number (out of range)
            var numberOfPeopleWaiting = 3;

            // Act
            elevatorManager.CallElevator(floorNumber, numberOfPeopleWaiting);

            // Assert
            var elevator = elevatorManager.GetNearestElevator(floorNumber);
            Assert.AreEqual(1, elevator.CurrentFloor); // Elevator should not move to an invalid floor.
            Assert.AreEqual(0, elevator.NumberOfPeople); // No one should be picked up as it's an invalid floor.
        }

    }
}
