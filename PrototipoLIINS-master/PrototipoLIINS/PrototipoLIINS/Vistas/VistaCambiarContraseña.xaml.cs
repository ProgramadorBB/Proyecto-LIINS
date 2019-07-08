using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrototipoLIINS.Modelo;
using PrototipoLIINS.Vistas;
using PrototipoLIINS.Conexion;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototipoLIINS.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VistaCambiarContraseña : ContentPage
	{
		public VistaCambiarContraseña ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            lblMensaje.Text = "";            
        }

        private async void BtnGuardarCambios_Clicked(object sender, EventArgs e)
        {
            string pass1 = txtPass1.Text;
            string pass2 = txtPass2.Text;

            lblMensaje.Text = "";

            if (string.IsNullOrWhiteSpace(pass1) || string.IsNullOrWhiteSpace(pass2))
            {
                lblMensaje.Text = "Campos Vacios";
            }
            else
            {
                if (pass1.Length.Equals(6))
                {
                    if (pass1 == pass2)
                    {
                        Usuario u = Application.Current.Properties["sesion"] as Usuario;
                        u.Contraseña = pass1;
                        UsuarioRepository.Instancia.UpdateUser(u);
                        await this.DisplayAlert("LIINS: ", "Contraseña cambiada de forma exitosa, vuelva a ingresar las credenciales", "Aceptar");
                        await Navigation.PopToRootAsync();
                    }
                    else
                    {
                        lblMensaje.Text = "Las contraseñas ingresadas no coinciden.";
                    }
                }
                else
                {
                    lblMensaje.Text = "Caracteres insuficientes";
                }
            }
        }

        private async void BtnInformación_Clicked(object sender, EventArgs e)
        {
            await this.DisplayAlert("INFORMACIÓN: ", "Es obligatorio cambiar la contraseña que viene por defecto, la contraseñas deben coincidir para efectuar el cambio y deben contener un mínimo de 6 caracteres", "OK");
        }

        private void BtnMostrarOcultar_Clicked(object sender, EventArgs e)
        {
            if (btnMostrarOcultar.Text.Equals("Mostrar Contraseñas"))
            {
                txtPass1.IsPassword = false;
                txtPass2.IsPassword = false;
                btnMostrarOcultar.Text = "Ocultar Contraseñas";
                btnMostrarOcultar.ImageSource = "ocultar.png";
            }
            else
            {
                txtPass1.IsPassword = true;
                txtPass2.IsPassword = true;
                btnMostrarOcultar.Text = "Mostrar Contraseñas";
                btnMostrarOcultar.ImageSource = "mostrar.png";
            }
        }
    }
}