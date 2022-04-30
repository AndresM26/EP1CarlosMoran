using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarlosMoran
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {

            String user = txtUsuario.Text;
            String pass = txtContrasenia.Text;

            if ((user == "moranCarlos2022") && (pass == "uisrael2022"))
            {
                Navigation.PushAsync(new registro());
            }
            else
            {
                DisplayAlert("Datos incorrectos", " Intentar nuevamente", "cerrar");

            }
        }
    }
}