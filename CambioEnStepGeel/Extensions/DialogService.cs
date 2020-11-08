using CambioEnStepGeel.Model;
using CambioEnStepGeel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CambioEnStepGeel.Extensions
{
    class DialogService
    {

        Window BoekingDetailView = new BoekingDetailView();
        public DialogService() {
           
        }

        public void ShowDetailDialog()
        {

            BoekingDetailView.ShowDialog();
        }

        public void CloseDetailDialog()
        {

            Console.WriteLine("CloseDetailDialog()");
           // if (BoekingDetailView != null)
                BoekingDetailView.Close();
        }
    }
}
