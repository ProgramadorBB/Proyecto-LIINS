using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrototipoLIINS.Modelo;
using PrototipoLIINS.Conexion;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototipoLIINS.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage
	{
		public Registro ()
		{
			InitializeComponent ();
		}

        private async void BtnCrearCuenta_Clicked(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            lblMensaje.TextColor = Color.DarkRed;
            //lblMensaje.Text = UsuarioRepository.Instancia.EstadoMensaje;

            string tipo = "Usuario";
            string estado = "Bloqueado";

            if (string.IsNullOrEmpty(txtUser.Text) &&
                string.IsNullOrEmpty(txtContraseña.Text) &&
                string.IsNullOrEmpty(txtNombre.Text) &&
                string.IsNullOrEmpty(txtApellido.Text))
            {
                lblMensaje.Text = string.Empty;
                lblMensaje.TextColor = Color.DarkRed;
                lblMensaje.Text = "Campos vacios";
            }
            else
            {
                UsuarioRepository.Instancia.AddNuevoUsuario(txtUser.Text, txtContraseña.Text,
                txtNombre.Text, txtApellido.Text, tipo, estado);

                string mensaje = UsuarioRepository.Instancia.EstadoMensaje;

                if (mensaje.Equals("Constraint"))
                {
                    txtUser.Text = string.Empty;
                    txtContraseña.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtApellido.Text = string.Empty;

                    await this.DisplayAlert("Mensaje", "El usuario ya está registrado", "OK");
                    lblMensaje.Text = string.Empty;
                }
                else
                {
                    lblMensaje.Text = "";
                    await this.DisplayAlert("Mensaje:", "El Usuario se ha registrado correctamente en la base de datos LIINS", "Aceptar");
                    await this.Navigation.PopToRootAsync();
                }
            }
        }

    }
}