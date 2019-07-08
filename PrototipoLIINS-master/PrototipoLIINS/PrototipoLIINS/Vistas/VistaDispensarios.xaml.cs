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
	public partial class VistaDispensarios : ContentPage
	{
		public VistaDispensarios ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            int cont = 0;
            Application.Current.Properties["contador"] = cont;

            //string msj = "El Boton 'Rellenado Listo' solo se activa cuando el Volumen de algún dispensario es menor o igual al 15%";

            pkContenido1.Items.Add("Coca-Cola");
            pkContenido1.Items.Add("Fanta");
            pkContenido1.Items.Add("Sprite");

            pkContenido2.Items.Add("Coca-Cola");
            pkContenido2.Items.Add("Fanta");
            pkContenido2.Items.Add("Sprite");

            pkContenido3.Items.Add("Coca-Cola");
            pkContenido3.Items.Add("Fanta");
            pkContenido3.Items.Add("Sprite");
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
            if (slDispensador1.IsVisible == true && slDispensador2.IsVisible == false && slDispensador3.IsVisible == false)
            {
                lblTitulo.Text = "Monitorear Dispensadores";

                btnDispensador1.IsVisible = true;
                btnDispensador2.IsVisible = true;
                btnDispensador3.IsVisible = true;
                btnDispensadorTodos.IsVisible = true;
                btnVolver.IsVisible = true;
                icono.IsVisible = true;

                slDispensador1.IsVisible = false;
                btnRellenoListo1.IsVisible = false;
                btnInformación1.IsVisible = false;
                btnVolver2.IsVisible = false;
            }

            if (slDispensador2.IsVisible == true && slDispensador1.IsVisible == false && slDispensador3.IsVisible == false)
            {
                lblTitulo.Text = "Monitorear Dispensadores";

                btnDispensador1.IsVisible = true;
                btnDispensador2.IsVisible = true;
                btnDispensador3.IsVisible = true;
                btnDispensadorTodos.IsVisible = true;
                btnVolver.IsVisible = true;
                icono.IsVisible = true;

                slDispensador2.IsVisible = false;
                btnRellenoListo2.IsVisible = false;
                btnInformación2.IsVisible = false;
                btnVolver2.IsVisible = false;
            }

            if (slDispensador3.IsVisible == true && slDispensador1.IsVisible == false && slDispensador2.IsVisible == false)
            {
                lblTitulo.Text = "Monitorear Dispensadores";

                btnDispensador1.IsVisible = true;
                btnDispensador2.IsVisible = true;
                btnDispensador3.IsVisible = true;
                btnDispensadorTodos.IsVisible = true;
                btnVolver.IsVisible = true;
                icono.IsVisible = true;

                slDispensador3.IsVisible = false;
                btnRellenoListo3.IsVisible = false;
                btnInformación3.IsVisible = false;
                btnVolver2.IsVisible = false;
            }

            if (slDispensador1.IsVisible == true && slDispensador2.IsVisible == true && slDispensador3.IsVisible == true)
            {
                lblTitulo.Text = "Monitorear Dispensadores";

                btnDispensador1.IsVisible = true;
                btnDispensador2.IsVisible = true;
                btnDispensador3.IsVisible = true;
                btnDispensadorTodos.IsVisible = true;
                btnVolver.IsVisible = true;
                icono.IsVisible = true;

                slDispensador1.IsVisible = false;
                slDispensador2.IsVisible = false;
                slDispensador3.IsVisible = false;
                btnRellenoListo1.IsVisible = false;
                btnRellenoListo2.IsVisible = false;
                btnRellenoListo3.IsVisible = false;
                btnInformación1.IsVisible = false;
                btnInformación2.IsVisible = false;
                btnInformación3.IsVisible = false;
                btnVolver2.IsVisible = false;
            }

        }

        private void BtnDispensador1_Clicked(object sender, EventArgs e)
        {
            lblTitulo.Text = "Monitorear Dispensador n°1";

            btnDispensador1.IsVisible = false;
            btnDispensador2.IsVisible = false;
            btnDispensador3.IsVisible = false;
            btnDispensadorTodos.IsVisible = false;
            btnVolver.IsVisible = false;
            icono.IsVisible = false;

            slDispensador1.IsVisible = true;
            slBotones1.IsVisible = true;
            btnRellenoListo1.IsVisible = true;
            btnInformación1.IsVisible = true;            
            btnVolver2.IsVisible = true;

            string msj = "El Boton 'Rellenado Listo' solo se activa cuando el Volumen del dispensador n°1 es menor o igual al 15%";

            if (!string.IsNullOrEmpty(lblCapacidad1.Text))
            {
                var a = Convert.ToInt32(lblCapacidad1.Text);
                if (a <= 15)
                {
                    btnRellenoListo1.IsEnabled = true;

                    lblContenido1.IsVisible = false;
                    pkContenido1.IsVisible = true;
                    msj = "Con el Boton 'Rellenado Listo' activado del dispensador n°1 deberá volver a selecionar el liquido contenido en el dispensador. (para agregar más opciones notifique a la compañia)";
                    //i = null;
                }
            }
            Application.Current.Properties["info"] = msj;

        }

        private void BtnDispensador2_Clicked(object sender, EventArgs e)
        {
            lblTitulo.Text = "Monitorear Dispensador n°2";

            btnDispensador1.IsVisible = false;
            btnDispensador2.IsVisible = false;
            btnDispensador3.IsVisible = false;
            btnDispensadorTodos.IsVisible = false;
            btnVolver.IsVisible = false;
            icono.IsVisible = false;

            slDispensador2.IsVisible = true;
            slBotones2.IsVisible = true;
            btnRellenoListo2.IsVisible = true;
            btnInformación2.IsVisible = true;
            btnVolver2.IsVisible = true;

            string msj = "El Boton 'Rellenado Listo' solo se activa cuando el Volumen del dispensario n°2 es menor o igual al 15%";

            if (!string.IsNullOrEmpty(lblCapacidad2.Text))
            {
                var a = Convert.ToInt32(lblCapacidad2.Text);
                if (a <= 15)
                {
                    btnRellenoListo2.IsEnabled = true;

                    lblContenido2.IsVisible = false;
                    pkContenido2.IsVisible = true;
                    msj = "Con el Boton 'Rellenado Listo' activado del dispensador n°2 deberá volver a selecionar el liquido contenido en el dispensador. (para agregar más opciones notifique a la compañia)";
                    //i = null;
                }
            }
            Application.Current.Properties["info2"] = msj;
        }

        private void BtnDispensador3_Clicked(object sender, EventArgs e)
        {
            lblTitulo.Text = "Monitorear Dispensador n°3";

            btnDispensador1.IsVisible = false;
            btnDispensador2.IsVisible = false;
            btnDispensador3.IsVisible = false;
            btnDispensadorTodos.IsVisible = false;
            btnVolver.IsVisible = false;
            icono.IsVisible = false;

            slDispensador3.IsVisible = true;
            slBotones3.IsVisible = true;
            btnRellenoListo3.IsVisible = true;
            btnInformación3.IsVisible = true;
            btnVolver2.IsVisible = true;

            string msj = "El Boton 'Rellenado Listo' solo se activa cuando el Volumen del dispensario n°3 es menor o igual al 15%";

            if (!string.IsNullOrEmpty(lblCapacidad3.Text))
            {
                var a = Convert.ToInt32(lblCapacidad3.Text);
                if (a <= 15)
                {
                    btnRellenoListo3.IsEnabled = true;

                    lblContenido3.IsVisible = false;
                    pkContenido3.IsVisible = true;
                    msj = "Con el Boton 'Rellenado Listo' activado del dispensador n°3 deberá volver a selecionar el liquido contenido en el dispensador. (para agregar más opciones notifique a la compañia)";
                    //i = null;
                }
            }
            Application.Current.Properties["info3"] = msj;
        }

        private void BtnDispensadorTodos_Clicked(object sender, EventArgs e)
        {
            lblTitulo.Text = "Monitorear Todos los Dispensadores";

            btnDispensador1.IsVisible = false;
            btnDispensador2.IsVisible = false;
            btnDispensador3.IsVisible = false;
            btnDispensadorTodos.IsVisible = false;
            btnVolver.IsVisible = false;
            icono.IsVisible = false;

            slDispensador1.IsVisible = true;            
            slDispensador2.IsVisible = true;
            slDispensador3.IsVisible = true;
            slBotones1.IsVisible = true;
            slBotones2.IsVisible = true;
            slBotones3.IsVisible = true;
            btnRellenoListo1.IsVisible = true;
            btnRellenoListo2.IsVisible = true;
            btnRellenoListo3.IsVisible = true;
            btnInformación1.IsVisible = true;
            btnInformación2.IsVisible = true;
            btnInformación3.IsVisible = true;
            btnVolver2.IsVisible = true;


        }        

        private async void BtnRellenoListo1_Clicked(object sender, EventArgs e)
        {
            if(pkContenido1.SelectedItem == null)
            {
                await this.DisplayAlert("LIINS: ", "Para ejecutar esta función debe selecionar un liquido", "Aceptar");
            }
            else
            {
                await this.DisplayAlert("LIINS: ", "¡Correcto!, ha selecionado: "+pkContenido1.SelectedItem.ToString(), "Aceptar");
            }

        }

        private async void BtnRellenoListo2_Clicked(object sender, EventArgs e)
        {
            if (pkContenido2.SelectedItem == null)
            {
                await this.DisplayAlert("LIINS: ", "Para ejecutar esta función debe selecionar un liquido", "Aceptar");
            }
            else
            {
                await this.DisplayAlert("LIINS: ", "¡Correcto!, ha selecionado: " + pkContenido2.SelectedItem.ToString(), "Aceptar");
            }
        }

        private async void BtnRellenoListo3_Clicked(object sender, EventArgs e)
        {
            if (pkContenido3.SelectedItem == null)
            {
                await this.DisplayAlert("LIINS: ", "Para ejecutar esta función debe selecionar un liquido", "Aceptar");
            }
            else
            {
                await this.DisplayAlert("LIINS: ", "¡Correcto!, ha selecionado: " + pkContenido3.SelectedItem.ToString(), "Aceptar");
            }
        }

        private async void BtnInformación1_Clicked(object sender, EventArgs e)
        {
            string info = (String)Application.Current.Properties["info"];
            await this.DisplayAlert("Información: ", info, "OK");
        }

        private async void BtnInformación2_Clicked(object sender, EventArgs e)
        {
            string info = (String)Application.Current.Properties["info2"];
            await this.DisplayAlert("Información: ", info, "OK");
        }

        private async void BtnInformación3_Clicked(object sender, EventArgs e)
        {
            string info = (String)Application.Current.Properties["info3"];
            await this.DisplayAlert("Información: ", info, "OK");
        }
    }
}