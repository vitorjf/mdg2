using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLite;
using System.IO;
using Windows.Storage;

namespace ColetaDados_Rasp
{
    public partial class DadosConsultados : PhoneApplicationPage
    {
        private SQLiteConnection dbConn = new SQLiteConnection(Home.DB_PATH);
        private string tanque, dataSelecionada;
        private int idTanque;
        Dados resultado;

        public DadosConsultados()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (NavigationContext.QueryString["dataSelecionada"] != null)
            {
                dataSelecionada = NavigationContext.QueryString["dataSelecionada"];
                tanque = NavigationContext.QueryString["nomeTanque"];
                idTanque = Convert.ToInt32(NavigationContext.QueryString["idTanque"]);
                LerBanco();
            }

            setaDadosNaTela();



            base.OnNavigatedTo(e);
        }


        private void LerBanco()
        {
            var query = dbConn.Table<Dados>().Where(x => x.IdTanque == idTanque && x.Data == dataSelecionada);
            resultado = query.FirstOrDefault();
        }

        private void setaDadosNaTela()
        {
            txtData.Text = resultado.Data;
            txtHora.Text = resultado.Hora;
            txtNomeTanque.Text = tanque;
            txtTemperatura.Text = resultado.Temperatura + " (°C)";
            txtOxigenio.Text = resultado.Oxigenio + " (mg/L)";
            txtTurbidez.Text = resultado.Turbidez + " (mV)";
            txtPh.Text = resultado.Ph + " (pH)";
        }
    }
}