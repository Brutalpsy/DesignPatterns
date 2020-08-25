namespace State_Design_Pattern.Logic
{
    public abstract class BookingState
    {
        protected BookingContext booking;
        public abstract void SetState(BookingContext bookingContext);
        public abstract void Cancel();
        public abstract void DatePassed();
        public abstract void EnterDetails(string attendee, int ticketCount);
    }
}
