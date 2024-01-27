using Microsoft.Identity.Client;
using SheepManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheepManager.Core.DTO.Sheeps
{
    public class SheepResponse
    {
        #region Properties

        public Guid SheepId { get; set; }
        public int TagNumber { get; set; }
        public Guid HerdId { get; set; }
        public double Weight { get; set; }
        public string? Gender { get; set; }
        public string? Race { get; set; }
        public string? BloodType { get; set; }
        public string? Selection { get; set; }
        public DateTime Birthdate { get; set; }
        public int MotherTagNumber { get; set; }
        public int FatherTagNumber { get; set; }
        public bool IsDead { get; set; }
        public bool IsSold { get; set; }
        public bool IsPregnant { get; set; }

        #endregion

        #region Methods

        public Sheep ToSheep()
        {
            return new Sheep()
            {
                SheepId = SheepId,
                TagNumber = TagNumber,
                HerdId = HerdId,
                Weight = Weight,
                Gender = Gender,
                Race = Race,
                BloodType = BloodType,
                Selection = Selection,
                Birthdate = Birthdate,
                MotherTagNumber = MotherTagNumber,
                FatherTagNumber = FatherTagNumber,
                IsDead = IsDead,
                IsSold = IsSold,
                IsPregnant = IsPregnant
            };
        }

        #endregion
    }

    public static class SheepExtensionMethods
    {
        public static SheepResponse ToSheepResponse(this Sheep sheep)
        {
            return new SheepResponse()
            {
                SheepId = sheep.SheepId,
                TagNumber = sheep.TagNumber,
                HerdId = sheep.HerdId,
                Weight = sheep.Weight,
                Gender = sheep.Gender,
                Race = sheep.Race,
                BloodType = sheep.BloodType,
                Selection = sheep.Selection,
                Birthdate = sheep.Birthdate,
                MotherTagNumber = sheep.MotherTagNumber,
                FatherTagNumber = sheep.FatherTagNumber,
                IsDead = sheep.IsDead,
                IsSold = sheep.IsSold,
                IsPregnant = sheep.IsPregnant
            };
        }
    }
}
