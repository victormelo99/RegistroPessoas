using RegistroPessoas.Models;
namespace RegistroPessoas.Service
{
    public class PaymentService
    {
        public Decimal CalculateDailyPayment(Person person)
        {
            decimal hoursWorked = (decimal)person.HoursWorked.TotalHours;

            return hoursWorked * person.HourlyPay;
        }
    }
}
