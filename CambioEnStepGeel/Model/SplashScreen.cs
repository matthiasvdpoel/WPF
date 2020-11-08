using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using CambioEnStepGeel.View;



namespace CambioEnStepGeel.Model
{
    class SplashScreen 
    {
        DispatcherTimer dT = new DispatcherTimer();
        public SplashScreen() 
        {

            Console.WriteLine("test1");
            dT.Tick += new EventHandler(dt_Tick);
            dT.Interval = new TimeSpan(0, 0, 3);
            dT.Start();
            Console.WriteLine("test2");

        }

        private void dt_Tick(object sender, EventArgs e)
        {
            LoginAndRegisterMain login = new LoginAndRegisterMain();
            Console.WriteLine("test");
            login.Show();
            dT.Stop();
            
            
        }
    }
}
