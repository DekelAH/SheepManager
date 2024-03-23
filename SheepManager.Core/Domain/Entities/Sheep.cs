using System.ComponentModel.DataAnnotations;

namespace SheepManager.Core.Domain.Entities
{
    public class Sheep
    {
        #region Properties

        [Key]
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

        public double GetAge()
        {
            DateTime today = DateTime.Today;
            int years = today.Year - Birthdate.Year;
            DateTime last = Birthdate.AddYears(years);

            if (last > today)
            {
                last = last.AddYears(-1);
                years--;
            }

            DateTime next = last.AddYears(1);
            double yearDays = (next - last).Days;
            double days = (today - last).Days;
            double exactAge = (double)years + (days / yearDays);

            return exactAge;
        }



        #endregion
    }
}
