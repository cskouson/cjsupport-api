namespace cjsupport.Domain.BusinessRules.SupportTicketRules
{
    public static class VerifyDateRule
    {
        public static bool IsValidDate(string date)
        {
            if (DateTime.TryParse(date, out DateTime newDate))
                return true;
            return false;
        }
    }
}
