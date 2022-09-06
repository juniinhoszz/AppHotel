using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using AppHotel.Model;
using System.Threading;
using System.Globalization;

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

        public List<Suite> Suites = new List<Suite>()
        {
            new Suite()
            {
                Descricao = "Super Luxo",
                ValorDiariaAdulto = 95.5,
                ValorDiariaCrianca = 45.5
            },
            new Suite()
            {
                Descricao = "Luxo",
                ValorDiariaAdulto = 80,
                ValorDiariaCrianca = 40
            },
            new Suite()
            {
                Descricao = "Pobre Premium (classe média)",
                ValorDiariaAdulto = 70.5,
                ValorDiariaCrianca = 35.5
            },
            new Suite()
            {
                Descricao = "Pobre Extremo (Tem Iphone de botão)",
                ValorDiariaAdulto = 45.5,
                ValorDiariaCrianca = 20.5
            }
        };



        public App()
        {
            InitializeComponent();

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            //MainPage = new NavigationPage(new View.Login()) { BarBackgroundColor = Color.Black };

            if (Properties.ContainsKey("usuario_logado"))
                MainPage = new NavigationPage(new View.CadastroHospedagem());
            else
                MainPage = new NavigationPage(new View.Login());
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
