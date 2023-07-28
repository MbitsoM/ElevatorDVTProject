using Elevator_DVT_Assessment;
using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main()
    {
        int numberOfElevators = 2;
        int numberOfFloors = 5;
        int elevatorCapacity = 10; // Capacity assumed to be 10 people per elevator
        int elevatorWeightLimit = 1000; // Assumed weight limit of 1000 kg for all elevators

        var elevatorManager = new ElevatorManager(numberOfElevators, numberOfFloors, elevatorCapacity, elevatorWeightLimit);

        bool exitApplication = false;

        while (!exitApplication)
        {
            Console.WriteLine("Available actions:");
            Console.WriteLine("1. Call Elevator to a Floor");
            Console.WriteLine("2. Set Number of People Waiting on a Floor");
            Console.WriteLine("3. Show Elevator Status");
            Console.WriteLine("4. Show Floor Status");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the floor number to call the elevator: ");
                    int floorNumber = int.Parse(Console.ReadLine());

                    Console.Write("Enter the number of people waiting on the floor: ");
                    int numberOfPeopleWaiting = int.Parse(Console.ReadLine());

                    elevatorManager.CallElevator(floorNumber, numberOfPeopleWaiting);
                    break;

                case 2:
                    Console.Write("Enter the floor number to set the number of people waiting: ");
                    if (!int.TryParse(Console.ReadLine(), out int floorNumberInput))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid floor number.");
                        break;
                    }

                    if (floorNumberInput < 1 || floorNumberInput > numberOfFloors)
                    {
                        Console.WriteLine($"Invalid floor number. Please enter a floor number between 1 and {numberOfFloors}.");
                        break;
                    }

                    Console.Write("Enter the number of people waiting on the floor: ");
                    if (!int.TryParse(Console.ReadLine(), out int numberOfPeopleWaitingInput))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number of people waiting.");
                        break;
                    }

                    if (numberOfPeopleWaitingInput < 0)
                    {
                        Console.WriteLine("Invalid number of people waiting. Please enter a non-negative value.");
                        break;
                    }

                    elevatorManager.SetNumberOfPeopleWaitingOnFloor(floorNumberInput, numberOfPeopleWaitingInput);
                    break;

                case 3:
                    elevatorManager.ShowElevatorStatus();
                    break;

                case 4:
                    elevatorManager.ShowFloorStatus();
                    break;

                case 5:
                    exitApplication = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
