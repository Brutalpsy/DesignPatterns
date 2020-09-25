
using Chain_of_Responsibility_First_Look.Business;

namespace Chain_of_Responsibility_First_Look.Handlers.UserValidation
{
    public class SocialSecurityNumberValidatorHandler : Handler<User>
    {
        private SocialSecurityNumberValidator socialSecurityNumberValidator = new SocialSecurityNumberValidator();
        public SocialSecurityNumberValidatorHandler()
        {
        }

        public override void Handle(User request)
        {
            if (socialSecurityNumberValidator.Validate(request.SocialSecurityNumber, request.RegionInfo))
            {
                throw new UserValidationException("Social security number could not be validated");
            }

            base.Handle(request);
        }
    }
}
