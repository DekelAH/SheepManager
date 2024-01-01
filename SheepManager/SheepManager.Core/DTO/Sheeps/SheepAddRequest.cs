using SheepManager.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.DTO.Sheeps
{
    public class SheepAddRequest
    {
        #region Properties

        [Required(ErrorMessage = "Tag Number can't be blank")]
        public int TagNumber { get; set; }

        [Required(ErrorMessage = "Weight can't be blank")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Weight can't be lower than 0")]
        public double Weight { get; set; }

        public string? Gender { get; set; }
        public string? Race { get; set; }
        public string? BloodType { get; set; }
        public string? Selection { get; set; }

        [Required(ErrorMessage = "Birthdate can't be blank")]
        public DateTime Birthdate { get; set; }

        public int MotherTagNumber { get; set; }
        public int FatherTagNumber { get; set; }
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
                VaccineId = VaccineId,
            };
        }

        #endregion
    }
}
