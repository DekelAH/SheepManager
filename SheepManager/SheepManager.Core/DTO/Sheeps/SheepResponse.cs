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
        public uint TagNumber { get; set; }
        public double Weight { get; set; }
        public string? Gender { get; set; }
        public string? Race { get; set; }
        public string? BloodType { get; set; }
        public string? Selection { get; set; }
        public DateTime Birthdate { get; set; }
        public uint MotherTagNumber { get; set; }
        public uint FatherTagNumber { get; set; }
        public bool IsDead { get; set; }
        public bool IsSold { get; set; }
        public bool IsPregnant { get; set; }
        public Guid BirthId { get; set; }
        public Guid VaccineId { get; set; }

        #endregion

        #region Methods

        public Sheep ToSheep()
        {
            return new Sheep()
            {
                SheepId = SheepId,
                TagNumber = TagNumber,
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
                IsPregnant = IsPregnant,
                BirthId = BirthId,
                VaccineId = VaccineId
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
                IsPregnant = sheep.IsPregnant,
                BirthId = sheep.BirthId,
                VaccineId = sheep.VaccineId
            };
        }
    }
}
