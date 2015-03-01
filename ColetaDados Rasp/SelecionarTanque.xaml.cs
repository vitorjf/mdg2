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
using SQLite;
using Windows.Storage;
using System.Threading.Tasks;

namespace ColetaDados_Rasp
{
    public partial class SelecionarTanque : PhoneApplicationPage
    {
        
        public SelecionarTanque()
        {
            InitializeComponent();
            salvarDados();
        }

        //Array responsável por guardar os valores extraídos do arquivo baixado
        String[] linhas = new String[10000];
        String[] valores;
        private SQLiteConnection dbConn = new SQLiteConnection(Home.DB_PATH);

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mylistbox.Items.Clear();
            /// Traz uma lista de tanques do banco de dados
            List<Tanques> listaTanques = dbConn.Table<Tanques>().ToList<Tanques>();
            foreach (var t in listaTanques)
            {
                mylistbox.Items.Add(t);
            }
        }

        private void Marks_button_click(object sender, RoutedEventArgs e)
        {
            Tanques myobject = (sender as Button).DataContext as Tanques;

            ListBoxItem pressedItem = this.mylistbox.ItemContainerGenerator.ContainerFromItem(myobject) as ListBoxItem;

            if (valores[5] == null || valores[5].Equals(""))
            {
                MessageBox.Show("Problemas encontrados na conexão");
            }
            else
            {
                if (pressedItem != null)
                {
                    int idTanque = myobject.Id;
                    string uri = string.Format("/DadosDaLeitura.xaml?nomeTanque={0}&data={1}&hora={2}&turbidez={3}&ph={4}&temperatura={5}&oxigenio={6}&idTanque={7}",
                       myobject.Nome, valores[0], valores[1], valores[2], valores[3], valores[4], valores[5], idTanque);
                    NavigationService.Navigate(new Uri(uri, UriKind.Relative));
                }
            }
        }

        //Método responsável pela leitura do arquivo baixado e extração das informações do mesmo salvando-os em um Array
        private void salvarDados()
        {
            IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
            StreamReader sr = null;
            if (fileStorage.FileExists("teste.txt"))
            {
            sr = new StreamReader(new IsolatedStorageFileStream("teste.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite, fileStorage));

            int i = 1;
            while ((linhas[i] = sr.ReadLine()) != null)
            {
                i++;
            }
            i--;
            i--;
            valores = linhas[i].Split(new Char [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            sr.Close();

            fileStorage.DeleteFile("teste.txt");
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
}