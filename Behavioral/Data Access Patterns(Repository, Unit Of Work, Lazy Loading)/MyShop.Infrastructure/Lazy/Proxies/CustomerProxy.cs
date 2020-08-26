using MyShop.Domain.Models;
using MyShop.Infrastructure.Services;

namespace MyShop.Infrastructure.Lazy.Proxies
{
    public class CustomerProxy : Customer
    {
        public override byte[] ProfilePicture
        {
            get
            {
                if (base.ProfilePicture == null)
                {
                    base.ProfilePicture = ProfilePictureService.GetFor(base.Name);
                }

                return base.ProfilePicture;
            }

            set => base.ProfilePicture = value;
        }
    }
}
