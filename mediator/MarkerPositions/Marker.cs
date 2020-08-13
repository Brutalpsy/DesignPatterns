using System;
using System.Drawing;
using System.Windows.Forms;

namespace MarkerPositions
{
    public class Marker : Label
    {
        private MarkerMediator mediator;
        private Point mouseDownLocation;

        public Marker()
        {
            Text = "{Drag me}";
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;
        }

        protected void OnMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        protected  void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Text = Location.ToString();
                Left = e.X + Left - mouseDownLocation.X;
                Top = e.Y + Top - mouseDownLocation.Y;
                this.mediator.Send(this.Location, this);
            }
        }


        internal void SetMediator(MarkerMediator markerMediator)
        {
            this.mediator = markerMediator;
        }

        internal void ReceiveLocation(Point location)
        {
            var distance = CalcDistance(location);

            if(distance< 100 && this.BackColor != Color.Red)
            {
                BackColor = Color.Red;
            }
            else if(distance >= 100 && BackColor != Color.Green)
            {
                BackColor = Color.Green;
            }

            double CalcDistance(Point point) => Math.Sqrt(Math.Pow(point.X - Location.X, 2)+ Math.Pow(point.Y - Location.Y,2));
        }
    }
}