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
    public partial class Page1 : PhoneApplicationPage
    {
        private SQLiteConnection dbConn = new SQLiteConnection(Home.DB_PATH);

        public Page1()
        {
            InitializeComponent();
        }

        String temperatura, oxigenio, turbidez, ph, tanque, data , hora;
        int idDoTanque;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dbConn.CreateTable<Dados>();
            recuperaDadosTelaAnterior();
            setaDadosNaTela();
            base.OnNavigatedTo(e);

        }

        private void recuperaDadosTelaAnterior()
        {
            if (NavigationContext.QueryString["nomeTanque"] != null)
            {
                tanque = NavigationContext.QueryString["nomeTanque"];
                data = NavigationContext.QueryString["data"];
                hora = NavigationContext.QueryString["hora"];
                temperatura = NavigationContext.QueryString["temperatura"];
                oxigenio = NavigationContext.QueryString["oxigenio"];
                turbidez = NavigationContext.QueryString["turbidez"];
                ph = NavigationContext.QueryString["ph"];
                idDoTanque = Convert.ToInt32(NavigationContext.QueryString["idTanque"]);
            }

        }

        private void setaDadosNaTela()
        {
            txtData.Text = data;
            txtHora.Text = hora;
            txtNomeTanque.Text = tanque;
            txtTemperatura.Text = temperatura + " (°C)";
            txtOxigenio.Text = oxigenio + " (mg/L)";
            txtTurbidez.Text = turbidez + " (mV)";
            txtPh.Text = ph + " (pH)";
        }
        private void Cadastrar(object sender, RoutedEventArgs e)
        {
            

            // Cria um novo conjunto de Dados
            Dados dados = new Dados()
            {
                Temperatura = temperatura,
                Oxigenio = oxigenio,
                Turbidez = turbidez,
                Ph = ph,
                TanqueNome = tanque,
                Data = data,
                Hora = hora,
                IdTanque = idDoTanque
                
            };

            

            var query = dbConn.Table<Dados>().Where(x => x.IdTanque == idDoTanque && x.Data == data);
            Dados resultado = query.FirstOrDefault();
            if(resultado != null ){
                dbConn.Delete(resultado);
            }


            /// Insere os dados na tabela Dados.
            dbConn.Insert(dados);
            MessageBox.Show("Dados Cadastrados com sucesso");
           
        }

    }
    public sealed class Dados
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Data { get; set; }

        public string Hora { get; set; }

        public string Temperatura { get; set; }

        public string Oxigenio { get; set; }

        public string Turbidez { get; set; }

        public string Ph { get; set; }

        public string TanqueNome { get; set; }

        public int IdTanque { get; set; }

    }
}