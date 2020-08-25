namespace State_Design_Pattern.Logic
{
    public class ClosedState : BookingState
    {
        private readonly string _reasonClosed;
        public ClosedState(string reasonClosed)
        {
            _reasonClosed = reasonClosed;
        }

        public override void Cancel()
        {
            booking.View.ShowError("Invalid action for this state", "Closed Booking Error");
        }

        public override void DatePassed()
        {
            booking.View.ShowError("Invalid action for this state", "Closed Booking Error");
        }

        public override void EnterDetails(string attendee, int ticketCount)
        {
            booking.View.ShowError("Invalid action for this state", "Closed Booking Error");
        }

        public override void SetState(BookingContext bookingContext)
        {
            booking = bookingContext;
            booking.ShowState("Closed");
            booking.View.ShowStatusPage(_reasonClosed);
        }
    }
}
