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
    public partial class ConsultarDataDados : PhoneApplicationPage
    {
        private SQLiteConnection dbConn = new SQLiteConnection(Home.DB_PATH);
        string tanque;
        int idTanque;
        List<Dados> listaDados;

        public ConsultarDataDados()
        {
            InitializeComponent();
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mylistbox.Items.Clear();
            if (NavigationContext.QueryString["nomeTanque"] != null)
            {
                tanque = NavigationContext.QueryString["nomeTanque"];
                idTanque = Convert.ToInt32(NavigationContext.QueryString["idTanque"]);
                nomeTanque.Text = tanque;
                ListarBanco();
            }

            foreach (var t in listaDados)
            {
                mylistbox.Items.Add(t);
                
            }

            base.OnNavigatedTo(e);
        }


        private void Marks_button_click(object sender, RoutedEventArgs e)
        {
            //Get the data object that represents the current selected item
            Dados myobject = (sender as Button).DataContext as Dados;

            //Get the selected ListBoxItem container instance of the item whose marks button is pressed
            ListBoxItem pressedItem = this.mylistbox.ItemContainerGenerator.ContainerFromItem(myobject) as ListBoxItem;

            //Checks whether it is not null
            if (pressedItem != null)
            {
               string dataSelecionada = myobject.Data;
               string uri = string.Format("/DadosConsultados.xaml?dataSelecionada={0}&nomeTanque={1}&idTanque={2}", dataSelecionada, tanque, idTanque);
                NavigationService.Navigate(new Uri(uri, UriKind.Relative));
            }
        }

        private void ListarBanco()
        {
            var query = dbConn.Table<Dados>().Where(x => x.IdTanque == idTanque);
            var result = query.ToList();
            listaDados = result.ToList();
        }
    }

}