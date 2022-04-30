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
    public partial class registro : ContentPage
    {
        private Double interes = 0;
        private Double CuotaFinal = 0;
        private string user = "";
        private string text;

        public registro()
        {
            InitializeComponent();
            this.lblusuario.Text = "Bienvenido: " + user;
            this.user = user;
        }

        public registro(string text)
        {
            this.text = text;
        }

        private void btnCaulcular_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtNombre.Text) || String.IsNullOrWhiteSpace(txtInicial.Text) || String.IsNullOrWhiteSpace(txtMensual.Text))
                {
                    DisplayAlert("Aviso", "Campos vacíos", "OK");
                }
                else
                {
                    if (Convert.ToDouble(txtInicial.Text) > 1800)
                    {
                        DisplayAlert("Aviso", "El monto inicial no deber superar los 1800", "OK");
                        txtInicial.Text = "1800";
                    }
                    else
                    {
                        if (Convert.ToDouble(txtInicial.Text) == 1800)
                        {
                            txtInicial.Text = "1800";
                            txtMensual.Text = "0";
                            lblCuotas.Text = "Monto final 1800$.";
                            Navigation.PushAsync(new resumen(this.user, txtNombre.Text, lblCuotas.Text));
                        }
                        else
                        {
                            interes = 1800 * 0.05;
                            double cuotas = Convert.ToDouble(txtMensual.Text) * 3;
                            double doubleFinal = cuotas + Convert.ToDouble(txtInicial.Text);
                            if (doubleFinal <= 1800)
                            {

                                this.CuotaFinal = (Convert.ToDouble(txtMensual.Text) * 3) + interes;
                                double MontoFinal = (this.CuotaFinal) + Convert.ToDouble(txtInicial.Text);
                                lblCuotas.Text = "Pagos pendientes: " + CuotaFinal + "$\n Total a pagar: " + MontoFinal + "$";
                                Navigation.PushAsync(new resumen(this.user, txtNombre.Text, lblCuotas.Text));
                            }
                            else
                            {

                                DisplayAlert("Aviso", "No debe pasar de 1800$", "OK");

                            }
                        }


                    }
                }
            }
            catch (Exception)
            {



            }
        }
    }
}