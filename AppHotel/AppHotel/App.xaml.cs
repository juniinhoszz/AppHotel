using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using AppHotel.Model;

namespace AppHotel
{
    public partial class App : Application
    {
        public List<DadosUsuario> lista_usuarios = new List<DadosUsuario>
        {
            new DadosUsuario()
            {
                Usuario = "aluno@etec",
                Nome = "Aluno",
                Senha = "123"
            },
            new DadosUsuario()
            {
                Usuario = "juninho",
                Nome = "Juninho Chiodi",
                Senha = "123"
            },
        };



        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new View.Login()) { BarBackgroundColor = Color.Black };

            if (Properties.ContainsKey("usuario_logado"))
                MainPage = new View.CadastroHospedagem();
            else
                MainPage = new View.Login();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
