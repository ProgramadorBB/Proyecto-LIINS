using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototipoLIINS.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VistaInstrucciones : ContentPage
	{
		public VistaInstrucciones ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            int cont = 0;
            Application.Current.Properties["contador"] = cont;
        }

        private async void BtnVolver_Clicked(object sender, EventArgs e)
        {
            int cont = (Int32)Application.Current.Properties["contador"];

            if (cont < 1)
            {
                cont = cont + 1;
                Application.Current.Properties["contador"] = cont;
                await Navigation.PopAsync();
            }
        }
    }
}