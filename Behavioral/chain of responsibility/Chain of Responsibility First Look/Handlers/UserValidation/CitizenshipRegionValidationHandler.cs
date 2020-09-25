
using Chain_of_Responsibility_First_Look.Business;

namespace Chain_of_Responsibility_First_Look.Handlers.UserValidation
{
    public class CitizenshipRegionValidationHandler : Handler<User>
    {
        public CitizenshipRegionValidationHandler()
        {
        }

        public override void Handle(User request)
        {
            if (request.RegionInfo.ThreeLetterISORegionName == "NO")
            {
                throw new UserValidationException("We currently don't support that region");
            }

            base.Handle(request);
        }
    }
}
