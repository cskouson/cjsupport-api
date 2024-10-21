using cjsupport.Common.Dtos;

namespace cjsupport.Domain.BusinessRules.SupportTicketRules
{
    public static class SupportTicketRulesBase
    {
        public static bool RunAllValidations(SupportTicketDto dto)
        {
            if(!VerifyEmailRule.IsValidEmailAddress(dto.UserEmail))
                return false;
            if(!VerifyDescriptionRule.IsValidDescription(dto.Description)) 
                return false;
            if(!VerifyDateRule.IsValidDate(dto.DueDate)) 
                return false;
            return true;
        }
    }
}
