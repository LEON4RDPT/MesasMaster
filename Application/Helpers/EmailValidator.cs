using System.Text.RegularExpressions;

namespace Application.Helpers
{
    public static class EmailValidator
    {
        // Method to validate an email using a regular expression
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            // Regular expression for a basic email validation
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            var regex = new Regex(emailPattern);

            return regex.IsMatch(email);
        }
    }
}
