using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Timer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {       
        public MainPage()
        {
            InitializeComponent();           
        }

        bool alive = true;
        int t;

        private void button1_click (object sender, EventArgs e)
        {
            t = Convert.ToInt32(textBox1.Text);
            Device.StartTimer(TimeSpan.FromSeconds(t), timeFinished);
            Device.StartTimer(TimeSpan.FromSeconds(1), timerTick);
            progressBar1.Progress = 1;
            progressBar1.ProgressTo(0, (uint)t * 1000, Easing.Linear);
        }

        private void button2_click (object sender, EventArgs e)
        {
            if (alive == true)
            {
                alive = false;
            }
            else
            {
                alive = true;
                Device.StartTimer(TimeSpan.FromSeconds(1), timerTick);
            }
        }

        private bool timeFinished ()
        {
            DisplayAlert("TimerMessage", "Time Finished", "OK");
            return false;
        }

        private bool timerTick ()
        {
            t--;
            textBox1.Text = t.ToString();
            return alive;
        }
    }
}
