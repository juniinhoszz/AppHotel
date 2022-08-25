﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHotel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        App PropriedadeApp;
        public Login()
        {
            InitializeComponent();

            PropriedadeApp = (App)Application.Current;
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            string user_digitado = txtUser.Text;
            string senha_digitada = txtSenha.Text;

            try
            {
                if (PropriedadeApp.lista_usuarios.Any(i => (i.Usuario == user_digitado && i.Senha == senha_digitada)))
                {
                    App.Current.Properties.Add("usuario_logado", user_digitado);

                    App.Current.MainPage = new CadastroHospedagem();
                }
                else
                    throw new Exception("Usuário ou senha incorretos.");
                              txtSenha.Text = "";

            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}