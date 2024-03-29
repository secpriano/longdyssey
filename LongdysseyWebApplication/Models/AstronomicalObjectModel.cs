﻿namespace WebApplication.Models
{
    public class AstronomicalObjectModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Radius { get; set; }
        public decimal Azimuth { get; set; }
        public decimal Inclination { get; set; }
        public decimal OrbitalSpeed { get; set; }

        public AstronomicalObjectModel(long id, string name, decimal radius, decimal azimuth, decimal inclination, decimal orbitalSpeed)
        {
            Id = id;
            Name = name;
            Radius = radius;
            Azimuth = azimuth;
            Inclination = inclination;
            OrbitalSpeed = orbitalSpeed;
        }

        private static double DegreeToRadians(double degree) => degree * (Math.PI / 180);

        public double[] SphericalToCartesianCoordinates()
        {
            double azimuthInRadians = DegreeToRadians((double)Azimuth);
            double inclinationInRadians = DegreeToRadians((double)Inclination);

            return new double[3]
            {
                (double)Radius * Math.Cos(inclinationInRadians) * Math.Cos(azimuthInRadians),
                (double)Radius * Math.Cos(inclinationInRadians) * Math.Sin(azimuthInRadians),
                (double)Radius * Math.Sin(inclinationInRadians)
            };
        }

        public enum Coordinates
        {
            X,
            Y,
            Z
        }
    }
}
