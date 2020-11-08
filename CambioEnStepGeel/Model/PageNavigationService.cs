using CambioEnStepGeel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CambioEnStepGeel.Model
{
    public class PageNavigationService
    {
        Dashboard dashboard = null;
        Login login = null;
        Register register = null;
        Boeking boeking = null;
        Community community = null;
        Profiel profiel = null;
        Overzichtboekingen overzicht = null;
        public PageNavigationService()
        {

        }

        public void Navigate(string page)
        {
            switch (page)
            {
                case "dashboard":
                    dashboard = new Dashboard();
                    ApplicationHelper.NavigationService.Navigate(dashboard);
                    break;
                case "login":
                    login = new Login();
                    ApplicationHelper.NavigationService.Navigate(login);
                    break;
                case "registreren":
                    register = new Register();
                    ApplicationHelper.NavigationService.Navigate(register);
                    break;
                case "boekingen":
                    boeking = new Boeking();
                    ApplicationHelper.NavigationService.Navigate(boeking);
                    break;
                case "community":
                    community = new Community();
                    ApplicationHelper.NavigationService.Navigate(community);
                    break;
                case "profiel":
                    profiel = new Profiel();
                    ApplicationHelper.NavigationService.Navigate(profiel);
                    break;
                case "overzichtboekingen":
                    overzicht = new Overzichtboekingen();
                    ApplicationHelper.NavigationService.Navigate(overzicht);
                    break;

                   


                default:
                    break;
            }
        }
    }
}
