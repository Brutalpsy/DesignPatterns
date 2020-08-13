using System;
using System.Windows.Forms;

namespace MarkerPositions
{
    public partial class Form1 : Form
    {
        private MarkerMediator mediator = new MarkerMediator();
        private Button addButton;
        public Form1()
        {
            InitializeComponent();
            addButton = new Button();
            addButton.Click += OnAddClick;
            addButton.Text = "Add Marker";
            addButton.Dock = DockStyle.Bottom;
            this.Controls.Add(this.addButton);
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            var marker = mediator.CreateMarker();
            this.Controls.Add(marker);
        }
    }
}
