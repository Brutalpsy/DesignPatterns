﻿using State_Design_Pattern.UI;

namespace State_Design_Pattern.Logic
{
    public class BookingContext
    {
        public MainWindow View { get; private set; }
        public string Attendee { get; set; }
        public int TicketCount { get; set; }
        public int BookingID { get; set; }

        private BookingState _currentState;

        public void TransitionToState(BookingState state)
        {
            _currentState = state;
            _currentState.SetState(this);
        }

        public BookingContext(MainWindow view)
        {
            View = view;
            TransitionToState(new NewState());
        }

        public void SubmitDetails(string attendee, int ticketCount)
        {
            _currentState.EnterDetails(attendee, ticketCount);
        }

        public void Cancel()
        {
            _currentState.Cancel();
        }

        public void DatePassed()
        {
            _currentState.DatePassed();
        }

        public void ShowState(string stateName)
        {
            View.grdDetails.Visibility = System.Windows.Visibility.Visible;
            View.lblCurrentState.Content = stateName;
            View.lblTicketCount.Content = TicketCount;
            View.lblAttendee.Content = Attendee;
            View.lblBookingID.Content = BookingID;
        }
    }
}
