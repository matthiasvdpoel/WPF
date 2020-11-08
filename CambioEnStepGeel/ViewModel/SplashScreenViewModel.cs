using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using CambioEnStepGeel.Model;

namespace CambioEnStepGeel.ViewModel
{
    class SplashScreenViewModel : BaseViewModel
    {
        public SplashScreenViewModel()
        {
            Console.WriteLine("spalshscreenViewmodel");
            /*SplashScreen = new SplashScreen();*/
            dT.Tick += new EventHandler(dt_Tick);
            dT.Interval = new TimeSpan(0, 0, 2);
            dT.Start();
        }

        public SplashScreen SplashScreen { get; set; }



        DispatcherTimer dT = new DispatcherTimer();
       
        private void dt_Tick(object sender, EventArgs e)
        {
            dT.Stop();
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("login");
        }
    }

}
