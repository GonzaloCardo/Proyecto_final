﻿#pragma checksum "..\..\..\..\Paginas\PaginaProcesos.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0F97CE0D985A4F9F05776AE6999CD587BA3BEA5C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas {
    
    
    /// <summary>
    /// PaginaProcesos
    /// </summary>
    public partial class PaginaProcesos : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\Paginas\PaginaProcesos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Vacio;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Paginas\PaginaProcesos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Notas;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Paginas\PaginaProcesos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Toma;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Paginas\PaginaProcesos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Balance;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Proyecto Final Gonzalo Cardo Muñoz;component/paginas/paginaprocesos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Paginas\PaginaProcesos.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Vacio = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 2:
            this.Notas = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 3:
            this.Toma = ((System.Windows.Controls.MenuItem)(target));
            
            #line 38 "..\..\..\..\Paginas\PaginaProcesos.xaml"
            this.Toma.Click += new System.Windows.RoutedEventHandler(this.Toma_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Balance = ((System.Windows.Controls.MenuItem)(target));
            
            #line 43 "..\..\..\..\Paginas\PaginaProcesos.xaml"
            this.Balance.Click += new System.Windows.RoutedEventHandler(this.Balance_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

