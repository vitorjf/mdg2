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

namespace ColetaDados_Rasp
{
    public partial class ConcultaGrafico : PhoneApplicationPage
    {
        private SQLiteConnection dbConn = new SQLiteConnection(Home.DB_PATH);
        List<string> meses = new List<string>();
        List<mes> mesw = new List<mes>();

        public ConcultaGrafico()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mylistbox.Items.Clear();
            /// Traz uma lista de tanques do banco de dados
            List<Dados> teste = dbConn.Table<Dados>().ToList<Dados>();

            for (int i = 0; i < teste.Count; i++)
            {
                string[] abc = teste[i].Data.Split(new Char[] { '/' });
                switch (abc[1])
                {
                    case "1":
                        if (!meses.Contains("Janeiro de " + abc[2]))
                        {
                            meses.Add("Janeiro de " + abc[2]);
                            mesw.Add(new mes { Nome = "Janeiro de " + abc[2] });
                            
                        }
                        break;
                    case "2":
                        if (!meses.Contains("Fevereiro de " + abc[2]))
                        {
                            meses.Add("Fevereiro de " + abc[2]);
                            mesw.Add(new mes { Nome = "Fevereiro de " + abc[2] });
                        }
                        break;
                    case "3":
                        if (!meses.Contains("Março de " + abc[2]))
                        {
                            meses.Add("Março de " + abc[2]);
                            mesw.Add(new mes { Nome = "Março de " + abc[2] });
                        }
                        break;
                    case "4":
                        if (meses.Contains("Abril de " + abc[2]))
                        {
                            meses.Add("Abril de " + abc[2]);
                        }
                        break;
                    case "5":
                        if (!meses.Contains("Maio de " + abc[2]))
                        {
                            meses.Add("Maio de " + abc[2]);
                        }
                        break;
                    case "6":
                        if (!meses.Contains("Junho de " + abc[2]))
                        {
                            meses.Add("Junho de " + abc[2]);
                        }
                        break;
                    case "7":
                        if (!meses.Contains("Julho de " + abc[2]))
                        {
                            meses.Add("Julho de " + abc[2]);
                        }
                        break;
                    case "8":
                        if (!meses.Contains("Agosto de " + abc[2]))
                        {
                            meses.Add("Agosto de " + abc[2]);
                        }
                        break;
                    case "9":
                        if (!meses.Contains("Setembro de " + abc[2]))
                        {
                            meses.Add("Setembro de " + abc[2]);
                        }
                        break;
                    case "10":
                        if (!meses.Contains("Outubro de " + abc[2]))
                        {
                            meses.Add("Outubro de " + abc[2]);
                        }

                        break;
                    case "11":
                        if (!meses.Contains("Novembro de " + abc[2]))
                        {
                            meses.Add("Novembro de " + abc[2]);
                        }
                        break;
                    case "12":
                        if (!meses.Contains("Dezembro de " + abc[2]))
                        {
                            meses.Add("Dezembro de " + abc[2]);
                            mesw.Add(new mes { Nome = "Dezembro de " + abc[2] });
                        }
                        break;

                }
                
            }
            foreach (var t in mesw)
            {
                mylistbox.Items.Add(t);

            }
            MessageBox.Show(mesw.Count().ToString());
        }

        private void ListClick(object sender, RoutedEventArgs e)
        {
            {
                Tanques myobject = (sender as Button).DataContext as Tanques;

                ListBoxItem pressedItem = this.mylistbox.ItemContainerGenerator.ContainerFromItem(myobject) as ListBoxItem;
                    if (pressedItem != null)
                    {
         /*               int idTanque = myobject.Id;
                        string uri = string.Format("/DadosDaLeitura.xaml?nomeTanque={0}&data={1}&hora={2}&turbidez={3}&ph={4}&temperatura={5}&oxigenio={6}&idTanque={7}",
                           myobject.Nome, valores[0], valores[1], valores[2], valores[3], valores[4], valores[5], idTanque);
                        NavigationService.Navigate(new Uri(uri, UriKind.Relative));*/
                    }
                
            }
        }

        protected sealed class mes
        {
            public string Nome { get; set; }
        }
    }
}