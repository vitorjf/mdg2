using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;

namespace ColetaDados_Rasp
{
    public partial class Graficos : PhoneApplicationPage
    {
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


        public class LineChart
        {
            public string Category { get; set; }
            public double val1 { get; set; }
            public double val2 { get; set; }
            public decimal val3 { get; set; }
        }




    }
}