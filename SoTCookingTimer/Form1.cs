using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoTCookingTimer
{
    public partial class cookingTimer : Form
    {
        private int _timerSeconds;
        private Timer _timer;
        private IKeyboardMouseEvents _keyboardEvents;

        public cookingTimer()
        {
            InitializeComponent();
        }

        private void cookingTimer_Load(object sender, EventArgs e)
        {
            _keyboardEvents = Hook.GlobalEvents();

            var fkeys = new Dictionary<Combination, Action>();
            fkeys.Add(Combination.TriggeredBy(Keys.F9), F9Press); //Fish
            fkeys.Add(Combination.TriggeredBy(Keys.F10), F10Press); //Trophy Fish
            fkeys.Add(Combination.TriggeredBy(Keys.F11), F11Press); //Meat & shark
            fkeys.Add(Combination.TriggeredBy(Keys.F12), F12Press); //Meg & Kraken

            _keyboardEvents.OnCombination(fkeys);
        }

        private void F9Press()
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }

            _timerSeconds = 45;
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += TimerTick;
            _timer.Start();
            foodType.Text = "Normie Fish";
            timeLeftLabel.Text = $"{_timerSeconds} seconds my dude";
        }

        private void F10Press()
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }

            _timerSeconds = 90;
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += TimerTick;
            _timer.Start();
            foodType.Text = "Trophy fish";
            timeLeftLabel.Text = $"{_timerSeconds} seconds my dude";
        }

        private void F11Press()
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }

            _timerSeconds = 60;
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += TimerTick;
            _timer.Start();
            foodType.Text = "spicy meat";
            timeLeftLabel.Text = $"{_timerSeconds} seconds my dude";
        }

        private void F12Press()
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }

            _timerSeconds = 120;
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += TimerTick;
            _timer.Start();
            foodType.Text = "Meg or Kraken";
            timeLeftLabel.Text = $"{_timerSeconds} seconds my dude";
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (_timerSeconds == 0)
            {
                SoundPlayer player = new SoundPlayer("SoundEffect/food.wav");
                player.Play();
                _timer.Dispose();
                foodType.Text = "None";
                timeLeftLabel.Text = $"None";
                return;
            }

            _timerSeconds--;

            timeLeftLabel.Text = $"{_timerSeconds} seconds my dude";

        }
    }
}
