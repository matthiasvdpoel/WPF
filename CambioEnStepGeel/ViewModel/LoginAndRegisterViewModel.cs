using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CambioEnStepGeel.ViewModel
{
    class LoginAndRegisterViewModel :BaseViewModel
    {

		private BaseViewModel selectedViewModel = new RegisterViewModel();

		public BaseViewModel SelectedViewModel
		{
			get { return selectedViewModel; }
			set {selectedViewModel = value; }
		}

		public ICommand UpdateViewCommand
		{
			get; set;
		}


	}
}
