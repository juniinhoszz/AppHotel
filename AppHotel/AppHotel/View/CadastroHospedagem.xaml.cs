using AppHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHotel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroHospedagem : ContentPage
    {
        App PropriedadeApp;
        public CadastroHospedagem()
        {
            InitializeComponent();
            PropriedadeApp = (App)Application.Current;
            NavigationPage.SetHasNavigationBar(this, false);

            string usuario_login = PropriedadeApp.Properties["usuario_logado"].ToString();

            DadosUsuario usuario_logado = PropriedadeApp.lista_usuarios.FirstOrDefault(i => i.Usuario == usuario_login);

            lblBoasVindas.Text = "Bem-vindo(a) " + usuario_logado.Nome + "!";

            pck_suites.ItemsSource = PropriedadeApp.Suites;

            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(6);

            dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
            dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(6).AddDays(1);
        }

        private async void btn_deslogar_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool confirm = await DisplayAlert("Tem Certeza?", "Vai fazer o logout da sua conta?", "Sim", "Não");

                if (confirm)
                {
                    App.Current.Properties.Remove("usuario_logado");

                    App.Current.MainPage = new Login();
                }
                else throw new Exception("Falha ao fazer logout");


            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void btn_calcular_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new HospedagemCalculada()
                {
                    BindingContext = new Hospedagem()
                    {
                        Qntadultos = Convert.ToInt32(stp_adultos.Value),
                        Qntcriancas = Convert.ToInt32(stp_criancas.Value),
                        Quarto = (Suite)pck_suites.SelectedItem,
                        DataCheckIn = dtpck_checkin.Date,
                        DataCheckOut = dtpck_checkout.Date
                    }
                });
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker element = (DatePicker)sender;

            dtpck_checkout.MinimumDate = element.Date.AddDays(1);
            dtpck_checkout.MaximumDate = element.Date.AddMonths(6);
        }
    }
    

}