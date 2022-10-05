﻿using IL.DTO;

namespace BLL.Entity
{
    internal class Flight
    {
        public ulong Id { get; set; }
        public DateTime Departuretime { get; set; }
        public string Status { get; set; }
        public string FlightNumber { get; set; }
        public Gate OriginGate { get; set; }
        public Gate DestinationGate { get; set; }
        public Spaceship Spaceship { get; set; }

        public Flight(ulong id, DateTime departuretime, string status, string flightNumber, Gate originGate, Gate destinationGate, Spaceship spaceship)
        {
            Id = id;
            Departuretime = departuretime;
            Status = status;
            FlightNumber = flightNumber;
            OriginGate = originGate;
            DestinationGate = destinationGate;
            Spaceship = spaceship;

            GenerateFlightNumber();
        }

        public Flight(FlightDTO dto)
        {
            Id = dto.Id;
            Departuretime = dto.DepartureTime;
            Status = dto.Status;
            FlightNumber = dto.FlightNumber;
            OriginGate = new(dto.OriginGate);
            DestinationGate = new(dto.DestinationGate);
            Spaceship = new(dto.Spaceship);
        }
        public string GenerateFlightNumber()
        {
            return "";
        }

        public DateTime CalcuclateFlightDuration() 
        {
            double distanceBetweenSpaceport = Math.Sqrt((OriginGate.Spaceport.X - DestinationGate.Spaceport.X) + (OriginGate.Spaceport.Y - DestinationGate.Spaceport.Y) + (OriginGate.Spaceport.Z - DestinationGate.Spaceport.Z));

            DateTime flightDuration = DateTime.Parse((distanceBetweenSpaceport / Spaceship.Speed).ToString());

            return flightDuration;
        }

    }
}