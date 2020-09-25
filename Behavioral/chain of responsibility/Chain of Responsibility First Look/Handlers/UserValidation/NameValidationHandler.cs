
using Chain_of_Responsibility_First_Look.Business;

namespace Chain_of_Responsibility_First_Look.Handlers.UserValidation
{
    public class NameValidationHandler : Handler<User>
    {
        private SocialSecurityNumberValidator socialSecurityNumberValidator = new SocialSecurityNumberValidator();
        public NameValidationHandler()
        {
        }

        public override void Handle(User request)
        {
            if (request.Name.Length <= 1)
            {
                throw new UserValidationException("Your name is unlikely this short");
            }

            base.Handle(request);
        }
    }
}
