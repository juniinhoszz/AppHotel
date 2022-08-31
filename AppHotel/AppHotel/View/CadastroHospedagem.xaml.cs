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

            string usuario_login = PropriedadeApp.Properties["usuario_logado"].ToString();

            DadosUsuario usuario_logado = PropriedadeApp.lista_usuarios.FirstOrDefault(i => i.Usuario == usuario_login);

            lblBoasVindas.Text = "Bem-vindo(a) " + usuario_logado.Nome;
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
    }
}