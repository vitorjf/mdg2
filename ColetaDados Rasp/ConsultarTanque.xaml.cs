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
    public partial class ConsultarDados : PhoneApplicationPage
    {
        public ConsultarDados()
        {
            InitializeComponent();
        }
        SQLiteConnection dbConn = new SQLiteConnection(Home.DB_PATH);

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
            //Get the data object that represents the current selected item
            Tanques myobject = (sender as Button).DataContext as Tanques;

            //Get the selected ListBoxItem container instance of the item whose marks button is pressed
            ListBoxItem pressedItem = this.mylistbox.ItemContainerGenerator.ContainerFromItem(myobject) as ListBoxItem;

            //Checks whether it is not null
            if (pressedItem != null)
            {
                string nomeTanque = myobject.Nome;
                int idTanque = myobject.Id;
                string uri = string.Format("/ConsultarDataDados.xaml?nomeTanque={0}&idTanque={1}", nomeTanque, idTanque);
                NavigationService.Navigate(new Uri(uri, UriKind.Relative));
            }
        }
    }

}