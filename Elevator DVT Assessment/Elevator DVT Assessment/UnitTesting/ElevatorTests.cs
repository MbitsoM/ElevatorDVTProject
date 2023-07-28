using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Elevator_DVT_Assessment.UnitTesting
{
    [TestClass]
    public class ElevatorTests
    {
        [TestMethod]
        public void TestElevatorMoveToFloor()
        {
            // Arrange
            int elevatorId = 1;
            int capacity = 10;
            int weightLimit = 1000;
            var elevator = new Elevator(elevatorId, capacity, weightLimit);

            int targetFloor = 3;

            // Act
            elevator.MoveToFloor(targetFloor);

            // Assert
            Assert.AreEqual(targetFloor, elevator.CurrentFloor);
            Assert.IsFalse(elevator.IsMoving);
            Assert.AreEqual(Direction.None, elevator.Direction);
        }

        [TestMethod]
        public void TestElevatorSetNumberOfPeopleWithinCapacity()
        {
            // Arrange
            int elevatorId = 1;
            int capacity = 10;
            int weightLimit = 1000;
            var elevator = new Elevator(elevatorId, capacity, weightLimit);

            int numberOfPeople = 5;

            // Act
            elevator.SetNumberOfPeople(numberOfPeople);

            // Assert
            Assert.AreEqual(numberOfPeople, elevator.NumberOfPeople);
        }

        [TestMethod]
        public void TestElevatorSetNumberOfPeopleExceedCapacity()
        {
            // Arrange
            int elevatorId = 1;
            int capacity = 10;
            int weightLimit = 1000;
            var elevator = new Elevator(elevatorId, capacity, weightLimit);

            int numberOfPeople = 15;

            // Act
            elevator.SetNumberOfPeople(numberOfPeople);

            // Assert
            Assert.AreEqual(0, elevator.NumberOfPeople); // Number of people should not exceed capacity.
        }

        [TestMethod]
        public void TestElevatorSetNumberOfPeopleExceedWeightLimit()
        {
            // Arrange
            int elevatorId = 1;
            int capacity = 10;
            int weightLimit = 1000;
            var elevator = new Elevator(elevatorId, capacity, weightLimit);

            int numberOfPeopleWithinLimit = 5;
            int numberOfPeopleToExceedLimit = 8;

            // Act
            elevator.SetNumberOfPeople(numberOfPeopleWithinLimit);
            elevator.SetNumberOfPeople(numberOfPeopleToExceedLimit);

            // Assert
            Assert.AreEqual(numberOfPeopleWithinLimit, elevator.NumberOfPeople); // Weight limit should not be exceeded.
        }
    }
}
