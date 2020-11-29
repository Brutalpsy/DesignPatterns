using System;

namespace BridgePattern
{
    public class MovieLicense
    {
        public string Movie { get; }
        public DateTime PurchaseTime { get; }
        private readonly Discount _discount;
        private readonly LicenceType _licenceType;
        private readonly SpecialOffer _specialOffer;

        public MovieLicense(string movie, DateTime purchaseTime, Discount discount, LicenceType licenceType, SpecialOffer specialOffer = SpecialOffer.None)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
            _discount = discount;
            _licenceType = licenceType;
            _specialOffer = specialOffer;
        }

        public decimal GetPrice()
        {
            //Inheritance
            //var discount = _discount.GetDiscount();

            //Composition
            var discount = GetDiscount();

            var multiplier = 1 - (discount / 100m);
            return GetBasePrice() * multiplier;
        }

        public int GetDiscount()
        {
            return _discount switch
            {
                Discount.None => 0,
                Discount.Military => 10,
                Discount.Senior => 20,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }


        private decimal GetBasePrice()
        {
            return _licenceType switch
            {
                LicenceType.LifeLong => 8,
                LicenceType.TwoDays => 4,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public DateTime? GetExpirationDate()
        {
            var expirationDate = GetBaseExperationDate();
            var extension = GetSpecialOfferExtension();
            return expirationDate?.Add(extension);
        }

        private TimeSpan GetSpecialOfferExtension()
        {
            return _specialOffer switch
            {
                SpecialOffer.None => TimeSpan.Zero,
                SpecialOffer.TwoDaysExtension => TimeSpan.FromDays(2),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private global::System.DateTime? GetBaseExperationDate()
        {
            return _licenceType switch
            {
                LicenceType.LifeLong => null,
                LicenceType.TwoDays => PurchaseTime.AddDays(2) as DateTime?,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }


    #region Composition
    public enum Discount
    {
        None,
        Military,
        Senior
    }

    public enum LicenceType
    {
        TwoDays,
        LifeLong
    }

    public enum SpecialOffer
    {
        None,
        TwoDaysExtension
    }

    #endregion
    #region Inheritance
    //public abstract class Discount
    //{
    //    public abstract int GetDiscount();
    //}

    //public class NoDiscount : Discount
    //{
    //    public override int GetDiscount() => 0;
    //}

    //public class MilitaryDiscount : Discount
    //{
    //    public override int GetDiscount() => 10;
    //}
    //public class SeniorDiscount : Discount
    //{
    //    public override int GetDiscount() => 20;
    //}

    //public class TwoDaysLicense : MovieLicense
    //{
    //    public TwoDaysLicense(string movie, DateTime purchaseTime, Discount discount)
    //        : base(movie, purchaseTime, discount)
    //    {
    //    }

    //    protected override decimal GetPriceCore() => 4;

    //    public override DateTime? GetExpirationDate() => PurchaseTime.AddDays(2);
    //}

    //public class LifeLongLicense : MovieLicense
    //{
    //    public LifeLongLicense(string movie, DateTime purchaseTime, Discount discount)
    //        : base(movie, purchaseTime, discount)
    //    {
    //    }

    //    protected override decimal GetPriceCore() => 8;

    //    public override DateTime? GetExpirationDate() => null;
    //}
    #endregion 

}
