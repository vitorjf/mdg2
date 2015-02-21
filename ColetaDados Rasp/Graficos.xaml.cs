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
            BarChart.DataSource = Data;
        }

        public ObservableCollection<BarData> Data = new ObservableCollection<BarData>() {
            new BarData() { Category = "Label 1", Value = 30 },
            new BarData() { Category = "Label 2", Value = 50 },
            new BarData() { Category = "Label 3", Value = 70 },
            new BarData() { Category = "Label 4", Value = 90 },
            new BarData() { Category = "Label 5", Value = 100 },
            
    };



        public class BarData
        {
            public string Category { get; set; }
            public double Value { get; set; }
        }


    }
}