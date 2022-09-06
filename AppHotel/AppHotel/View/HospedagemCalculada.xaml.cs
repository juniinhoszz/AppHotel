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

        private void btn_deslogar_Clicked(object sender, EventArgs e)
        {

        }
    }
}