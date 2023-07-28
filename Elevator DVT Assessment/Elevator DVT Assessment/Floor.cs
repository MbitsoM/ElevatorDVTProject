using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_DVT_Assessment
{
    public class Floor
    {
        public int FloorNumber { get;  set; }
        public int NumberOfPeopleWaiting { get;  set; }

        public Floor(int floorNumber)
        {
            FloorNumber = floorNumber;
            NumberOfPeopleWaiting = 0;
        }       

        public void ShowStatus()
        {
            Console.WriteLine($"Floor {FloorNumber}:");
            Console.WriteLine($"  Number of People Waiting: {NumberOfPeopleWaiting}");
        }
    }
}
