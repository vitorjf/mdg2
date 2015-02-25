using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.IO;
using Windows.Storage;
using SQLite;

namespace ColetaDados_Rasp
{
    public partial class Home : PhoneApplicationPage
    {
        public static string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "sample.sqlite"));
        private SQLiteConnection dbConn = new SQLiteConnection(Home.DB_PATH);
        public Home()
        {
            InitializeComponent();
            
            
        }
        WebClient wc;
        
        private void btnObterDados(object sender, RoutedEventArgs e)
        {
            
            //No clique do botão cria-se um objeto da classe WebClient e então é feita a leitura através da URL
            
            wc = new WebClient();
            wc.Headers[HttpRequestHeader.IfModifiedSince] = DateTime.UtcNow.ToString("o");
            wc.OpenReadCompleted += wc_OpenReadCompleted; //Esse método será chamado após o término do download
//            wc.OpenReadAsync(new Uri("http://192.168.42.1/dados.txt", UriKind.Absolute)); //Identifica o endereço do arquivo para download
            wc.OpenReadAsync(new Uri("http://172.22.10.41/dados.txt", UriKind.Absolute)); //Identifica o endereço do arquivo para download
            
            
     
        }

        private void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            //O resultado do download chega através do argumento "e" recepcionado por esse método
            if (!e.Cancelled && e.Error == null)
            {
                byte[] arquivoBytes = new byte[e.Result.Length];
                e.Result.Read(arquivoBytes, 0, arquivoBytes.Length);

                using (IsolatedStorageFile isoStore =
                  IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream isoStream =
                      isoStore.CreateFile("teste.txt"))
                    {
                        isoStream.Write(arquivoBytes, 0, arquivoBytes.Length);
                        isoStream.Close();
                    }

                    resolveVisibilidade();

                }
                MessageBox.Show("Conectado");
            }
            else
            {
                MessageBox.Show("Erro na conexão");
            }
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            resolveVisibilidade();
            dbConn.CreateTable<Dados>();
        }

        private void resolveVisibilidade()
        {
            dbConn.CreateTable<Tanques>();
            var query = dbConn.Table<Tanques>().ToList();
            Tanques resultado = query.FirstOrDefault();

            IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
            btConectar.IsEnabled = true;
            btRealizar.IsEnabled = true;
            if (!fileStorage.FileExists("teste.txt") )
            {
                btRealizar.IsEnabled = false;
            }
            else
            {
                btRealizar.IsEnabled = true;
            }

            if(resultado == null){
                btConsultar.IsEnabled = false;
                btConectar.IsEnabled = false;
                btExcluit.IsEnabled = false;
            }
            else
            {
                btConsultar.IsEnabled = true;
                btConectar.IsEnabled = true;
                btExcluit.IsEnabled = true; ;
            }
        }

        private void Button_cadastrar(object sender, RoutedEventArgs e)
        {
            string uri = string.Format("/CRUD Tanques/CadastrarTanque.xaml?possuiValor={0}", "Cancel");
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

    }
}