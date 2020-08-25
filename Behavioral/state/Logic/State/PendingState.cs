using System.Threading;

namespace State_Design_Pattern.Logic
{
    public class PendingState : BookingState
    {
        public CancellationTokenSource cancelationToken;
        public override void Cancel()
        {
            cancelationToken.Cancel();
        }

        public override void DatePassed()
        {
        }

        public override void EnterDetails(string attendee, int ticketCount)
        {
        }

        public override void SetState(BookingContext bookingContext)
        {
            booking = bookingContext;
            cancelationToken = new CancellationTokenSource();
            booking.ShowState("Pending");
            booking.View.ShowStatusPage("Processing Booking");
            StaticFunctions.ProcessBooking(booking, ProcessingComplete, cancelationToken);
        }

        private void ProcessingComplete(BookingContext booking, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Sucess:
                    booking.TransitionToState(new BookedState());
                    break;
                case ProcessingResult.Fail:
                    booking.View.ShowProcessingError();
                    booking.TransitionToState(new NewState());
                    break;
                case ProcessingResult.Cancel:
                    booking.TransitionToState(new ClosedState("Processing Canceled"));
                    break;
                default:
                    break;
            }
        }
    }
}
