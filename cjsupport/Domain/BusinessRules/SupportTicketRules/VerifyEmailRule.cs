using System.Text.RegularExpressions;

namespace cjsupport.Domain.BusinessRules.SupportTicketRules
{
    public static class VerifyEmailRule
    {
        static string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        public static bool IsValidEmailAddress(string emailAddress)
        {
            if(Regex.IsMatch(emailAddress, emailPattern))
                return true;
            return false;
        }
    }
}
