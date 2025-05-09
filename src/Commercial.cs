using System; 

namespace OOP 
{
    public class Commercial : Aircraft 
    {
        public int numPassangers = 0; // In unit of passengers, each passanger counts as one

        public Commercial(string id, AircraftState state, int distance, int speed, string type, double fuelCapacity, double fuelConsumption, double currentFuel, int numPassangers) 
        : base(id, state, distance, speed, type, fuelCapacity, fuelConsumption, currentFuel)
        {
            this.id = id; 
            this.state = state; 
            this.distance = distance; 
            this.speed = speed; 
            this.type = type; 
            this.fuelCapacity = fuelCapacity; 
            this.fuelConsumption = fuelConsumption; 
            this.currentFuel = currentFuel; 
            this.numPassangers = numPassangers; 

        }

        public override void ShowAirplaneInfo() // Shows the information about the aircraft 
        {
            base.ShowAirplaneInfo(); 
            Console.WriteLine($" | Passenger Load: {numPassangers}");
        }  

    }


}