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
using Windows.Phone.UI.Input;

namespace ColetaDados_Rasp.CRUD_Tanques
{
    public partial class ExcluirTanques : PhoneApplicationPage
    {
        
        public ExcluirTanques()
        {
            InitializeComponent();
        }

        private SQLiteConnection dbConn = new SQLiteConnection(Home.DB_PATH);

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            listarTanques(); 
        }

        private void Button_alterar(object sender, RoutedEventArgs e) {
            Tanques myobject = (sender as Button).DataContext as Tanques;
            ListBoxItem pressedItem = this.mylistbox.ItemContainerGenerator.ContainerFromItem(myobject) as ListBoxItem;

            if (pressedItem != null)
            {
                string uri = string.Format("/CRUD Tanques/CadastrarTanque.xaml?nomeTanque={0}&informacoesAdicionais={1}&objeto={2}&possuiValor={3}",
                                   myobject.Nome, myobject.InformacoesAdicionais, myobject.Id, "OK");
                NavigationService.Navigate(new Uri(uri, UriKind.Relative));

            }
        }   

        private void Button_excluir(object sender, RoutedEventArgs e)
        {

            Tanques myobject = (sender as Button).DataContext as Tanques;
            ListBoxItem pressedItem = this.mylistbox.ItemContainerGenerator.ContainerFromItem(myobject) as ListBoxItem;

            //Checks whether it is not null
            if (pressedItem != null)
            {
                MessageBoxResult resultado = MessageBox.Show("Você realmente deseja excluir esse Tanque?",
                "Excluir Tanque", MessageBoxButton.OKCancel);
                if (resultado == MessageBoxResult.OK)
                {
                    excluir(myobject);
                    listarTanques();
                }
                           
            }
        }

        private void listarTanques()
        {
            mylistbox.Items.Clear();
            /// Traz uma lista de tanques do banco de dados
            List<Tanques> listaTanques = dbConn.Table<Tanques>().ToList<Tanques>();
            foreach (var t in listaTanques)
            {
                mylistbox.Items.Add(t);
            }
        }

        private void excluir(Tanques tanque)
        {
            var query2 = dbConn.Table<Dados>().Where(x => x.IdTanque == tanque.Id);
            Dados resultado = query2.FirstOrDefault();
            if (resultado == null)
            {
                dbConn.Delete(tanque);
            }
            else
            {
                MessageBox.Show("Não é possível excluir, este tanque possui registros");
            }
        }


        //protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        //{
        //    MessageBoxResult result = MessageBox.Show("Deseja realmente sair?", "Atenção!", MessageBoxButton.OKCancel); //Exibe um MessageBox com uma mensagem e duas opções ("ok" e "Cancel")

        //    if (result == MessageBoxResult.OK) //se o usuário tocar "OK"
        //    {
        //        NavigationService.Navigate(new Uri("Home.xaml", UriKind.Relative));
        //        base.OnBackKeyPress(e); //voltar página
        //    }

        //    else
        //    {

        //        e.Cancel = true; //Senão, cancelar ação (nada acontece)

        //    }

        //}


        void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            e.Handled = true;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            NavigationService.Navigate(new Uri("Home.xaml", UriKind.Relative));
        }
    }
}