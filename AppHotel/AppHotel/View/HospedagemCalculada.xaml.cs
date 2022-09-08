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
    public partial class HospedagemCalculada : ContentPage
    {
        App PropriedadeApp;
        public HospedagemCalculada()
        {
            InitializeComponent();
            PropriedadeApp = (App)Application.Current;
            NavigationPage.SetHasNavigationBar(this, false);

            string usuario_login = PropriedadeApp.Properties["usuario_logado"].ToString();

            DadosUsuario usuario_logado = PropriedadeApp.lista_usuarios.FirstOrDefault(i => i.Usuario == usuario_login);

            lblBoasVindas.Text = "Bem-vindo(a) " + usuario_logado.Nome + "!";

            
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

        private void btn_voltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btn_cancel_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool confirm = await DisplayAlert("Tem Certeza?", "Deseja cancelar sua hospedagem?", "Sim", "Não");

                if (confirm)
                {
                    App.Current.MainPage = new NavigationPage(new CadastroHospedagem());
                }
                else throw new Exception("Falha ao cancelar hospedagem");
            }
            catch
            {

            }
            
        }

        private async void btn_confirm_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool confirm = await DisplayAlert("Tem Certeza?", "Deseja confirmar sua estadia no hotel?", "Sim", "Não");

                if (confirm)
                {
                    await DisplayAlert("Sucesso!", "Sua hospedagem foi realizada!", "OK");

                    App.Current.MainPage = new NavigationPage(new CadastroHospedagem());
                }
                else throw new Exception("Falha ao fazer hospedagem");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        
        }
    }
    
}
