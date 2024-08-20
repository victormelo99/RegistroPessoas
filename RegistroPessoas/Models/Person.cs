using System.ComponentModel.DataAnnotations;

namespace RegistroPessoas.Models
{
    public class Person
    {
        [Key]
        public  Guid Id { get; set; }
        
        [Required(ErrorMessage ="The Name field is required.")]
        [StringLength(150, MinimumLength = 3 , ErrorMessage = "The name must be between 3 and 150 characters.")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateBirth { get; set; }

        [EmailAddress(ErrorMessage ="The Email field is not a valid email address.")]
        public  string? Email { get; set; }
        
        [Phone(ErrorMessage ="The Celphone field is not a valid phone number.")]
        public string?  Celphone { get; set; }

        [Required(ErrorMessage ="The Sex field is required.")]
        public char Sex { get; set; }

        [Required(ErrorMessage = " The HourlyPay field is required.")]
        public decimal HourlyPay { get; set; }

        [Required(ErrorMessage = "The HoursWorked field is required. ")]
        public TimeSpan HoursWorked { get; set; }

        public decimal DailyPayment => (decimal)HoursWorked.TotalHours * HourlyPay;

        public Person()
        {
        }

        public Person(Guid id, string name, DateTime dateBirth, string? email, string? celphone, char sex, decimal hourlyPay)
        {
            Id = id;
            Name = name;
            DateBirth = dateBirth;
            Email = email;
            Celphone = celphone;
            Sex = sex;
            HourlyPay = hourlyPay;
        }
    }
}
