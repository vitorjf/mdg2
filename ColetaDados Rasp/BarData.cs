using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColetaDados_Rasp
{
    class BarData
    {


        public ObservableCollection<PChart> Data = new ObservableCollection<BarData>() {
            new PChart() { title = "Label 1", value = 30 },
            new PChart() { title = "Label 2", value = 40 },
            new PChart() { title = "Label 3", value = 50 },
            new PChart() { title = "Label 4", value = 60 },

    new PChart() { title = "Label 5", value = 70 },

    };



        public class BarData
        {
            public string Category { get; set; }
            public double Value { get; set; }
        }
    }
}
