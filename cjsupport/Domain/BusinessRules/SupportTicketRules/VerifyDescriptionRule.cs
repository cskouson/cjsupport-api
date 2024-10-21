namespace cjsupport.Domain.BusinessRules.SupportTicketRules
{
    public static class VerifyDescriptionRule
    {
        public static bool IsValidDescription(string description)
        {
            if(description.Length >= 100 && description.Length <= 1000)
                return true;
            return false;
        }
    }
}
