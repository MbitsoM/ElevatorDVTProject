using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_DVT_Assessment
{
    public class ElevatorManager
    {
        private List<Elevator> elevators;
        private List<Floor> floors;

        public ElevatorManager(int numberOfElevators, int numberOfFloors, int elevatorCapacity, int elevatorWeightLimit)
        {
            elevators = new List<Elevator>();
            floors = new List<Floor>();

            for (int i = 1; i <= numberOfElevators; i++)
            {
                var elevator = new Elevator(i, elevatorCapacity, elevatorWeightLimit);
                elevators.Add(elevator);
            }

            for (int i = 1; i <= numberOfFloors; i++)
            {
                var floor = new Floor(i);
                floors.Add(floor);
            }
        }

        public Elevator GetNearestElevator(int floorNumber)
        {
            var nearestElevator = elevators.OrderBy(e => Math.Abs(e.CurrentFloor - floorNumber))
                                          .FirstOrDefault();

            return nearestElevator;
        }

        public void CallElevator(int floorNumber, int numberOfPeopleWaiting)
        {
            var elevator = GetNearestElevator(floorNumber);
            elevator.SetNumberOfPeople(numberOfPeopleWaiting);
            elevator.MoveToFloor(floorNumber);
        }
        public void SetNumberOfPeopleWaitingOnFloor(int floorNumber, int numberOfPeopleWaiting)
        {
            var floor = floors.FirstOrDefault(f => f.FloorNumber == floorNumber);
            if (floor != null)
            {
                floor.NumberOfPeopleWaiting = numberOfPeopleWaiting;
            }
        }


        public void ShowElevatorStatus()
        {
            Console.WriteLine("Elevator Status:");
            foreach (var elevator in elevators)
            {
                elevator.ShowStatus();
            }
        }

        public void ShowFloorStatus()
        {
            Console.WriteLine("Floor Status:");
            foreach (var floor in floors)
            {
                floor.ShowStatus();
            }
        }
    }

}
