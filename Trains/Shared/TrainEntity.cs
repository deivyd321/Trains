using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using TrainColor = Trains.Shared.Enums.TrainColor;

namespace Trains.Shared
{
    public class TrainEntity
    {
        [JsonConstructor]
        public TrainEntity() { }

        public TrainEntity(string name, int yearMade, TrainColor color, string licensePlate, string company, string homeStation)
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
        public TrainColor Color { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string HomeStation { get; set; }

        [Required]
        public bool IsRenovated { get; set; }

        public void Edit(TrainEntity train)
        {
            Name = train.Name;
            Color = train.Color;
            LicensePlate = train.LicensePlate;
            Company = train.Company;
            HomeStation = train.HomeStation;
            IsRenovated = train.IsRenovated;
        }

        public void Edit(string name, TrainColor color, string licensePlate, bool isRenovated)
        {
            Name = name;
            Color = color;
            LicensePlate = licensePlate;
            IsRenovated = isRenovated;
        }
    }
}
