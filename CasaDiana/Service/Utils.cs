using System.ComponentModel.DataAnnotations;

namespace CasaDiana.Service
{
    public class Utils
    {
        public static bool isValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public static bool isValidNumber(string number)
        {
            return number.All(Char.IsDigit);
        }
    }
}
