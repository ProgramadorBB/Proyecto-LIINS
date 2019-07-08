using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrototipoLIINS.Conexion;
using PrototipoLIINS.Modelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrototipoLIINS.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaBuscarUsuario : ContentPage
    {
        public VistaBuscarUsuario()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            int cont = 0;
            Application.Current.Properties["contador"] = cont;


            pkEstado.Items.Add("Desbloqueado");
            pkEstado.Items.Add("Bloqueado");
            pkEstado.Title = "Seleccione";
           // pkEstado.SelectedIndex = 1;

            
        }

        private void BtnEditarUsuario_Clicked(object sender, EventArgs e)
        {
            lblUser.IsVisible = false;
            lblContraseña.IsVisible = false;
            lblNombre.IsVisible = false;
            lblApellido.IsVisible = false;
            lblEstado.IsVisible = false;

            txtUser.IsVisible = true;
            txtContraseña.IsVisible = true;
            txtContraseña.IsEnabled = true;
            txtNombre.IsVisible = true;
            txtApellido.IsVisible = true;
            pkEstado.IsVisible = true;

            Usuario u = Application.Current.Properties["datos"] as Usuario;

            txtNombre.Text = u.Nombre;
            txtApellido.Text = u.Apellido;
            txtUser.Text = u.User;
            txtContraseña.Text = u.Contraseña;

            btnVolver.IsVisible = false;
            btnVolver2.IsVisible = true;
            btnEditarUsuario.IsVisible = false;
            btnGuardarCambios.IsVisible = true;
            btnEliminarUsuario.IsVisible = false;
            btnMostrarOcultar.IsVisible = true;
        }

        private void BtnCargar_Clicked(object sender, EventArgs e)
        {
            Usuario u = Application.Current.Properties["datos"] as Usuario;

            lblUser.Text = u.User;
            lblContraseña.IsVisible = false;
            txtContraseña.IsEnabled = false;
            txtContraseña.IsVisible = true;
            txtContraseña.Text = u.Contraseña;
           
            lblNombre.Text = u.Nombre;
            lblApellido.Text = u.Apellido;
            lblEstado.Text = u.Estado;

            icono.Source = "userProfile.png";
            lblTitle.Text = "Perfil de Usuario:";

            btnCargar.IsVisible = false;
            btnEditarUsuario.IsVisible = true;
            btnEliminarUsuario.IsVisible = true;
        }

        private async void BtnGuardarCambios_Clicked(object sender, EventArgs e)
        {
            if (pkEstado.SelectedItem == null)
            {
                await this.DisplayAlert("LIINS: ", "Para ejecutar esta función debe selecionar el estado del usuario (Bloqueado o Desbloqueado)", "Aceptar");
            }
            else
            {
                Usuario u = Application.Current.Properties["datos"] as Usuario;
                u.Nombre = txtNombre.Text;
                u.Apellido = txtApellido.Text;
                u.Contraseña = txtContraseña.Text;
                u.User = txtUser.Text;
                u.Estado = pkEstado.SelectedItem.ToString();

                if (await this.DisplayAlert("¿Guardar cambios del Usuario?",
                        "IMPORTANTE: Los datos se cambiaran de forma permanente",
                        "Guardar",
                        "Cancelar") == true)
                {
                    UsuarioRepository.Instancia.UpdateUser(u);
                    await this.DisplayAlert("LIINS: ", "Usuario actualizado en la base de datos", "Aceptar");
                    lblMensaje.Text = "";
                    await Navigation.PushAsync(new VistaAdmin());
                }
            }                                   
        }

        private async void BtnEliminarUsuario_Clicked(object sender, EventArgs e)
        {
            Usuario u = Application.Current.Properties["datos"] as Usuario;

            if (await this.DisplayAlert("¿Borrar usuario?",
                    "IMPORTANTE: El usuario [" + u.Nombre + " " + u.Apellido + "] Se eliminara de forma permanente",
                    "Eliminar usuario",
                    "Cancelar") == true)
            {
                UsuarioRepository.Instancia.DeleteUsuario(u.Id);
                await this.DisplayAlert("LIINS: ", "Usuario eliminado de la base de datos", "Aceptar");
                await Navigation.PushAsync(new VistaAdmin());
            }
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

        private void BtnVolver2_Clicked(object sender, EventArgs e)
        {
            Usuario u = Application.Current.Properties["datos"] as Usuario;

            lblUser.Text = u.User;            
            txtContraseña.Text = u.Contraseña;
            lblNombre.Text = u.Nombre;
            lblApellido.Text = u.Apellido;
            lblEstado.Text = u.Estado;

            icono.Source = "userProfile.png";
            lblTitle.Text = "Perfil de Usuario:";

            lblUser.IsVisible = true;
            txtContraseña.IsVisible = true;
            lblNombre.IsVisible = true;
            lblApellido.IsVisible = true;
            lblEstado.IsVisible = true;

            txtUser.IsVisible = false;
            txtContraseña.IsEnabled = false;
            txtNombre.IsVisible = false;
            txtApellido.IsVisible = false;
            pkEstado.IsVisible = false;

            btnCargar.IsVisible = false;
            btnEditarUsuario.IsVisible = true;
            btnEliminarUsuario.IsVisible = true;
            btnVolver.IsVisible = true;
            btnVolver2.IsVisible = false;
            btnGuardarCambios.IsVisible = false;
            btnMostrarOcultar.IsVisible = false;

            txtContraseña.IsPassword = true;
            btnMostrarOcultar.Text = "Mostrar Contraseña";
            btnMostrarOcultar.ImageSource = "mostrar.png";
        }

        private void BtnMostrarOcultar_Clicked(object sender, EventArgs e)
        {
            if (btnMostrarOcultar.Text.Equals("Mostrar Contraseña"))
            {
                txtContraseña.IsPassword = false;
                btnMostrarOcultar.Text = "Ocultar Contraseña";
                btnMostrarOcultar.ImageSource = "ocultar.png";
            }
            else
            {
                txtContraseña.IsPassword = true;
                btnMostrarOcultar.Text = "Mostrar Contraseña";
                btnMostrarOcultar.ImageSource = "mostrar.png";
            }
        }
    }
}