using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace Killer.Architecture
{
    public partial class KillerMenu : Form
    {
        private readonly MediaPlayer _mainMenu = new MediaPlayer();
        
        public KillerMenu()
        {
            _mainMenu.Open(new Uri(Environment.CurrentDirectory + @"\Sounds\MainMenu.wav"));
            _mainMenu.Volume = 0.1;
            _mainMenu.Play();
            _mainMenu.MediaEnded += (sender, args) =>
            {
                _mainMenu.Stop();
                _mainMenu.Play();
            };
            var label = new Label
            {
                ForeColor = Color.Brown,
                Location = new Point(350, 0),
                BackColor = Color.Transparent,
                Font = new Font("Comic Sans MS", 50),
                Size = new Size(ClientSize.Width, 100),
                Text = "Killer"
            };
            Controls.Add(label);
            var version = new Label
            {
                ForeColor = Color.Red,
                Location = new Point(880, 495),
                BackColor = Color.Transparent,
                Font = new Font("Comic Sans MS", 10),
                Size = new Size(ClientSize.Width, 30),
                Text = "v1.2.0"
            };
            Controls.Add(version);
            var byVsAlt = new Label
            {
                ForeColor = Color.Red,
                Location = new Point(0, 495),
                BackColor = Color.Transparent,
                Font = new Font("Comic Sans MS", 10),
                Size = new Size(ClientSize.Width, 30),
                Text = "by VsALT"
            };
            Controls.Add(byVsAlt);
            var button1 = new Button
            {
                Location = new Point(30, label.Bottom + 10),
                Size = new Size(90, 50),
                Text = "First level"
            };
            Controls.Add(button1);
            button1.Click += (sender, args) =>
            {
                if (Game.IsOver) return;
                Invalidate();
                var firstLevel = new KillerWindow("Level1", 0, false, false);
                firstLevel.ShowDialog();
                firstLevel.FormClosing += (o, eventArgs) => { firstLevel.Invalidate(); };
            };
            var button2 = new Button
            {
                Location = new Point(150, label.Bottom + 10),
                Size = new Size(90, 50),
                Text = "Second level"
            };
            button2.Click += (sender, args) =>
            {
                if (Game.IsOver) return;
                Invalidate();
                var secondLevel = new KillerWindow("Level2", 0, false, false);
                secondLevel.ShowDialog();
            };
            Controls.Add(button2);
            var button3 = new Button
            {
                Location = new Point(270, label.Bottom + 10),
                Size = new Size(90, 50),
                Text = "Third level"
            };
            button3.Click += (sender, args) =>
            {
                if (Game.IsOver) return;
                Invalidate();
                var thirdLevel = new KillerWindow("Level3", 14, true, false);
                thirdLevel.ShowDialog();
            };
            Controls.Add(button3);
            var button4 = new Button
            {
                Location = new Point(390, label.Bottom + 10),
                Size = new Size(90, 50),
                Text = "Fourth level"
            };
            button4.Click += (sender, args) =>
            {
                if (Game.IsOver) return;
                Invalidate();
                var fourthLevel = new KillerWindow("Level4", 21, false, false);
                fourthLevel.ShowDialog();
            };
            Controls.Add(button4);
            var button5 = new Button
            {
                Location = new Point(510, label.Bottom + 10),
                Size = new Size(90, 50),
                Text = "Fifth level"
            };
            button5.Click += (sender, args) =>
            {
                if (Game.IsOver) return;
                Invalidate();
                var fifthLevel = new KillerWindow("Level5", 21, false, false);
                fifthLevel.ShowDialog();
            };
            Controls.Add(button5);
            var button6 = new Button
            {
                Location = new Point(630, label.Bottom + 10),
                Size = new Size(90, 50),
                Text = "Sixth level"
            };
            button6.Click += (sender, args) =>
            {
                if (Game.IsOver) return;
                Invalidate();
                var sixthLevel = new KillerWindow("Level6", 0, false, false);
                sixthLevel.ShowDialog();
            };
            Controls.Add(button6);
            var button7 = new Button
            {
                Location = new Point(750, label.Bottom + 10),
                Size = new Size(90, 50),
                Text = "Seventh level"
            };
            button7.Click += (sender, args) =>
            {
                if (Game.IsOver) return;
                Invalidate();
                var seventhLevel = new KillerWindow("Level7", 0, false, true);
                seventhLevel.ShowDialog();
            };
            Controls.Add(button7);
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            var death = new Label
            {
                ForeColor = Color.Red,
                Location = new Point(120, 150),
                BackColor = Color.Transparent,
                Font = new Font("Comic Sans MS", 40),
                Size = new Size(800, 80),
                Text = "Тьма поглотила вас..."
            };
            if (Game.IsOver)
            {
                Controls.Clear();
                BackgroundImage = null;
                BackColor = Color.Black;
                Controls.Add(death);
            }
            base.OnActivated(e);
        }
    }
}