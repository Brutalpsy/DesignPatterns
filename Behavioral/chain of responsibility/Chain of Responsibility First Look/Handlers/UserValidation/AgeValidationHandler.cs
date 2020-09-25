
using Chain_of_Responsibility_First_Look.Business;

namespace Chain_of_Responsibility_First_Look.Handlers.UserValidation
{
    public class AgeValidationHandler : Handler<User>
    {
        public AgeValidationHandler()
        {
        }

        public override void Handle(User request)
        {
            if (request.Age < 18)
            {
                throw new UserValidationException("You have to be 18 years old");
            }

            base.Handle(request);
        }
    }
}
