using System;

namespace State_Design_Pattern.Logic
{
    public class NewState : BookingState
    {
        public override void Cancel()
        {
            booking.TransitionToState(new ClosedState("Booking Canceled"));
        }

        public override void DatePassed()
        {
            booking.TransitionToState(new ClosedState("Booking expired"));
        }

        public override void EnterDetails(string attendee, int ticketCount)
        {
            booking.Attendee = attendee;
            booking.TicketCount = ticketCount;
            booking.TransitionToState(new PendingState());
        }

        public override void SetState(BookingContext bookingContext)
        {
            booking = bookingContext;
            booking.BookingID = new Random().Next();
            booking.ShowState("New");
            booking.View.ShowEntryPage();
        }
    }
}
