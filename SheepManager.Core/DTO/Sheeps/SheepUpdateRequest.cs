using SheepManager.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.DTO.Sheeps
{
    public class SheepUpdateRequest
    {
        #region Properties

        public Guid SheepId { get; set; }

        [Required(ErrorMessage = "Tag Number can't be blank")]
        [Range(0, int.MaxValue, ErrorMessage = "Weight can't be lower than 0")]
        public int TagNumber { get; set; }
        public Guid HerdId { get; set; }

        [Required(ErrorMessage = "Weight can't be blank")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Weight can't be lower than 0")]
        public double Weight { get; set; }

        public string? Gender { get; set; }
        public string? Race { get; set; }
        public string? BloodType { get; set; }
        public string? Selection { get; set; }

        [Required(ErrorMessage = "Birthdate can't be blank")]
        public DateTime Birthdate { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Weight can't be lower than 0")]
        public int MotherTagNumber { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Weight can't be lower than 0")]
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
}
