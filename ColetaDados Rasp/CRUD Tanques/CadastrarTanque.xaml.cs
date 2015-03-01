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
    public partial class Page2 : PhoneApplicationPage
    {
        private SQLiteConnection dbConn;
        private string nomeTanque, informacoes;
        private int id;
        private Tanques tanque;
        public Page2()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString["possuiValor"] == "OK")
            {
                nomeTanque = NavigationContext.QueryString["nomeTanque"];
                informacoes = NavigationContext.QueryString["informacoesAdicionais"];
                id = Convert.ToInt32(NavigationContext.QueryString["objeto"]);
                btnCadastrar.Content = "Alterar";
                txtBoxInfo.Text = informacoes;
                txtBoxNome.Text = nomeTanque;
            } 

                /// Cria a conexão com o banco de dados.
                dbConn = new SQLiteConnection(Home.DB_PATH);
                /// Cria a tabela Tanques, se ela não existir
                dbConn.CreateTable<Tanques>();
                base.OnNavigatedTo(e);
            


            
            
        }

        private void Cadastrar(object sender, RoutedEventArgs e)
        {
            if (nomeTanque != null)
            {
                tanque = dbConn.Table<Tanques>().Where(x => x.Id == id).FirstOrDefault();
                tanque.Nome = txtBoxNome.Text;
                tanque.InformacoesAdicionais = txtBoxInfo.Text;
                dbConn.Update(tanque);
                MessageBox.Show("Tanque Alterado com Sucesso");
                NavigationService.GoBack();

            }
            else if (txtBoxNome.Text.Equals("") || txtBoxNome.Text == null)
                {
                    MessageBox.Show("O nome do tanque é obrigatório");
                }
            else
            {
                    tanque = new Tanques()
                    {
                        Nome = txtBoxNome.Text,
                        InformacoesAdicionais = txtBoxInfo.Text
                    };
                    dbConn.Insert(tanque);
                    txtBoxNome.Text = String.Empty;
                    txtBoxInfo.Text = String.Empty;
                    MessageBox.Show("Tanque Cadastrado com Sucesso");  
            }
           
        }
        
    }



    public sealed class Tanques
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string InformacoesAdicionais { get; set; }

    }
}