using System; 

namespace OOP 
{

    public class Runway 
    {

        public string id { get; set; } // Number of the runway 
        public RunwayStatus runwayStatus { get; set; } // Status of the Runway (Free, Ocupied)
        public Aircraft CurrentAircraft { get; set; } // Information about the Aircraft if occuping the Runway
        public int ticksToFree { get; set; } // The amount of ticks needed for a Aircraft to exit the Runway

        public enum RunwayStatus // Possible states of the Runway
        {
            Free,
            Ocupied
        }

        public Runway(string id)
        {
            this.id = id; 
            runwayStatus = RunwayStatus.Free;  // By default the runway is free
            CurrentAircraft = null; // We start with runways with no planes
            ticksToFree = 3; // By default it takes 3 ticks to clear a runway 
        }
        public void RequestRunway(Aircraft aircraft)
        {
            if (runwayStatus == RunwayStatus.Free) // Check if the runway is free 
            {
            
                runwayStatus = RunwayStatus.Ocupied; // The runway is in use by the plane which is landing 
                CurrentAircraft = aircraft; // We assing the plane as landing 
                ticksToFree = 3; // Reset the counter of ticks
                Console.WriteLine($"Aircraft {aircraft.id} is landing on Runway {id}"); // We show the info 
                aircraft.state = Aircraft.AircraftState.Landing; // We change the status of the plane to landing
            }
            else 
            {
                Console.WriteLine($"Runway number {id} is not free"); // We tell that the runway is being used by another plane
            }
        }

        public void ReleaseRunway()
        {

            if (CurrentAircraft != null)
            {
                CurrentAircraft.state = Aircraft.AircraftState.OnGround; // We assign the plane as OnGroud 
                 
                Console.WriteLine($"Airplane {CurrentAircraft.id} has landed successfully"); // We show that the plane has landed

                CurrentAircraft = null; 
            }

            runwayStatus = RunwayStatus.Free; // We now put the runway as free
            ticksToFree = 0; // The tick counter has gone to 0

        }

        public string GetStatus()
        {
            Console.Clear(); 
            if (runwayStatus == RunwayStatus.Free) // If the runway status is free
            {
                return $"{id} IS FREE";
            }

            else // If the runway status is anything but free
            {
                return $"{id} is ocupied by Aircraft {CurrentAircraft.id}, {ticksToFree} ticks remaining";
            }
        }   

            // Método que simula el paso de un tick en la pista
        public void UpdateTick() // Method which simulatoes the ticks in the runway
        {
            // We verify that the runway is occupied and there is an airplane on it
            if (runwayStatus == RunwayStatus.Ocupied && CurrentAircraft != null) 
            {
                ticksToFree--; // We substract a tick   

                // We show to the user the ticks remaining 
                GetStatus(); 

                // If no ticks remain, we free the runway automatically
                if (ticksToFree <= 0)
                {
                    ReleaseRunway(); // We call the release method to release the runway
                }
            }
        }



    }

}