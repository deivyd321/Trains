using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using Color = Trains.Shared.Enums.Color;

namespace Trains.Shared
{
    public class Train
    {
        [JsonConstructor]
        public Train() { }

        public Train(string name, int yearMade, Color color, string licensePlate, string company, string homeStation)
        {
            Id = Guid.NewGuid();
            Name = name;
            YearMade = yearMade;
            Color = color;
            LicensePlate = licensePlate;
            Company = company;
            HomeStation = homeStation;
        }

        public Guid Id { get; set; }

        [Required]
        public int YearMade { get; set; }

        [StringLength(10, ErrorMessage = "Name is too long.")]
        [Required]
        public string Name { get; set; }

        [Required]
        public Color Color { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string HomeStation { get; set; }
    }
}
