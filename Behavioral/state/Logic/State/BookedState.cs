namespace State_Design_Pattern.Logic
{
    public class BookedState : BookingState
    {
        public override void Cancel()
        {
            booking.TransitionToState(new ClosedState("Booking canceled: Expect a refund"));
        }

        public override void DatePassed()
        {
            booking.TransitionToState(new ClosedState("Hope you enjoy the event!"));
        }

        public override void EnterDetails(string attendee, int ticketCount)
        {
        }

        public override void SetState(BookingContext bookingContext)
        {
            booking = bookingContext;
            booking.ShowState("Booked");
            booking.View.ShowStatusPage("Enjoy the event.");
        }
    }
}
