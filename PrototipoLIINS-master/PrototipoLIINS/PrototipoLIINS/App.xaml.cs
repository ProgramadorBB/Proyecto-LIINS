using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrototipoLIINS.Modelo;
using PrototipoLIINS.Conexion;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrototipoLIINS
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();

            UsuarioRepository.Inicializador(filename);
            MainPage = new NavigationPage(new MainPage())
            { BarBackgroundColor = Color.Black, BarTextColor = Color.White };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
