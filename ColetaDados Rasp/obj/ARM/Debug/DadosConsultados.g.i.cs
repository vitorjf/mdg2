﻿#pragma checksum "C:\Users\arley\Documents\Visual Studio 2013\Projects\ColetaDados Git\ColetaDados Rasp\DadosConsultados.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F94FEA33BE513900598EA5B457705702"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ColetaDados_Rasp {
    
    
    public partial class DadosConsultados : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock txtNomeTanque;
        
        internal System.Windows.Controls.TextBlock txtData;
        
        internal System.Windows.Controls.TextBlock txtHora;
        
        internal System.Windows.Controls.TextBlock txtTemperatura;
        
        internal System.Windows.Controls.TextBlock txtOxigenio;
        
        internal System.Windows.Controls.TextBlock txtTurbidez;
        
        internal System.Windows.Controls.TextBlock txtPh;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/ColetaDados%20Rasp;component/DadosConsultados.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.txtNomeTanque = ((System.Windows.Controls.TextBlock)(this.FindName("txtNomeTanque")));
            this.txtData = ((System.Windows.Controls.TextBlock)(this.FindName("txtData")));
            this.txtHora = ((System.Windows.Controls.TextBlock)(this.FindName("txtHora")));
            this.txtTemperatura = ((System.Windows.Controls.TextBlock)(this.FindName("txtTemperatura")));
            this.txtOxigenio = ((System.Windows.Controls.TextBlock)(this.FindName("txtOxigenio")));
            this.txtTurbidez = ((System.Windows.Controls.TextBlock)(this.FindName("txtTurbidez")));
            this.txtPh = ((System.Windows.Controls.TextBlock)(this.FindName("txtPh")));
        }
    }
}

