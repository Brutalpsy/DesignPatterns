using Chain_of_Responsibility_First_Look.Handlers.UserValidation;
using System;

namespace Chain_of_Responsibility_First_Look.Business
{
    public class UserProcessor
    {
        private readonly SocialSecurityNumberValidator SocialSecurityNumberValidator = new SocialSecurityNumberValidator();

        public UserProcessor()
        {

        }

        public bool Register(User user)
        {
            try
            {
                var handler = new SocialSecurityNumberValidatorHandler();
                handler.SetNext(new AgeValidationHandler())
                    .SetNext(new NameValidationHandler())
                    .SetNext(new CitizenshipRegionValidationHandler());

                handler.Handle(user);
            }
            catch (UserValidationException ex)
            {
                return false;
            }
            return true;
        }
    }
}
