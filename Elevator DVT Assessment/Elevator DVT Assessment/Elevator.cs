using System;
using System.Collections.Generic;
using System.Linq;

namespace Elevator_DVT_Assessment
{
    public class Elevator
    {
        public int ElevatorId { get; set; }
        public int CurrentFloor { get;  set; }
        public bool IsMoving { get;  set; }
        public Direction Direction { get;  set; }
        public int Capacity { get;  set; }
        public int NumberOfPeople { get;  set; }

        public int CurrentWeight { get;  set; }
        public int WeightLimit { get;  set; }

        public Elevator(int elevatorId, int capacity, int weightLimit)
        {
            ElevatorId = elevatorId;
            CurrentFloor = 1;
            IsMoving = false;
            Direction = Direction.None;
            Capacity = capacity;
            NumberOfPeople = 0;
            CurrentWeight = 0;
            WeightLimit = weightLimit;
        }

        public void MoveToFloor(int targetFloor)
        {
            if (IsMoving)
            {
                Console.WriteLine($"Elevator {ElevatorId} is already in motion.");
                return;
            }

            if (targetFloor == CurrentFloor)
            {
                Console.WriteLine($"Elevator {ElevatorId} is already on floor {CurrentFloor}.");
                return;
            }

            Direction = targetFloor > CurrentFloor ? Direction.Up : Direction.Down;
            IsMoving = true;

            Console.WriteLine($"Elevator {ElevatorId} is moving {Direction.ToString().ToLower()} to floor {targetFloor}.");

            // Simulate the elevator movement
            while (CurrentFloor != targetFloor)
            {
                if (Direction == Direction.Up)
                {
                    CurrentFloor++;
                }
                else
                {
                    CurrentFloor--;
                }

                Console.WriteLine($"Elevator {ElevatorId} reached floor {CurrentFloor}.");
            }

            IsMoving = false;
            Direction = Direction.None; // Reset direction after reaching the target floor
            Console.WriteLine($"Elevator {ElevatorId} has arrived at floor {CurrentFloor}.");
        }

        public void SetNumberOfPeople(int numberOfPeople)
        {
            if (numberOfPeople > Capacity)
            {
                Console.WriteLine($"Elevator {ElevatorId} cannot carry more than {Capacity} people.");
                return;
            }

            int totalWeight = NumberOfPeople * 70; // Assuming an average weight of 70kg per person
            if (totalWeight + (numberOfPeople * 70) > WeightLimit)
            {
                Console.WriteLine($"Elevator {ElevatorId} has reached its weight limit.");
                return;
            }

            NumberOfPeople = numberOfPeople;
            CurrentWeight = NumberOfPeople * 70;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Elevator {ElevatorId} - Current Floor: {CurrentFloor}, " +
            $"Is Moving: {IsMoving}, Direction: {Direction}, " +
            $"Number of People: {NumberOfPeople}, Current Weight: {CurrentWeight} kg");
        }
    }
 }

