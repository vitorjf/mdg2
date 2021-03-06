﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using SQLite;

namespace ColetaDados_Rasp
{
    public partial class Graficos : PhoneApplicationPage
    {
        private SQLiteConnection dbConn = new SQLiteConnection(Home.DB_PATH);
        List<string> meses = new List<string>();
        public Graficos()
        {
            InitializeComponent();
            
        }

        public ObservableCollection<LineChart> Data = new ObservableCollection<LineChart>() {
         //   new BarData() { Category = "Label 1", Value = 30 },
          new LineChart() { Category = "L1", val1=5, val2=15, val3=12},
        new LineChart() { Category = "L2", val1=15.2, val2=1.5, val3=2},
        new LineChart() { Category = "L3", val1=25, val2=5, val3=2}
            
    };

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LineChart1.DataSource = Data;
        }

        public class BarData
        {
            public string Category { get; set; }
            public double Value { get; set; }
        }

        private void listar()
        {
            List<Dados> teste = dbConn.Table<Dados>().ToList<Dados>();
           
            for (int i = 0; i < teste.Count; i++ )
            {
                string[] abc = teste[i].Data.Split(new Char[] {'/'});
                switch (abc[1])
                {
                    case "1":
                        if (!meses.Contains("Janeiro de " + abc[2]))
                        {
                            meses.Add("Janeiro de " + abc[2]);
                        }
                        break;
                    case "2":
                        if (!meses.Contains("Fevereiro de " + abc[2]))
                        {
                            meses.Add("Fevereiro de " + abc[2]);
                        }
                        break;
                    case "3":
                        if(!meses.Contains("Março de " + abc[2]))
                        {
                            meses.Add("Março de " + abc[2]);
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
                        if(!meses.Contains("Dezembro de " + abc[2]))
                        {
                            meses.Add("Dezembro de " + abc[2]);
                        }
                        break;

                }
            }

            
        }

        public class LineChart
        {
            public string Category { get; set; }
            public double val1 { get; set; }
            public double val2 { get; set; }
            public decimal val3 { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listar();
            MessageBox.Show(meses[1]);
        }




    }
}