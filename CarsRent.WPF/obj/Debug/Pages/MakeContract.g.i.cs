﻿#pragma checksum "..\..\..\Pages\MakeContract.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "28581132E3E729ED87FA21FFF07ABC783B7BE1F8F4AE8D555C411096F0E03BE6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CarsRent.WPF.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace CarsRent.WPF.Pages {
    
    
    /// <summary>
    /// MakeContract
    /// </summary>
    public partial class MakeContract : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\Pages\MakeContract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbRenter;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\MakeContract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbCar;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Pages\MakeContract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxBeginDate;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Pages\MakeContract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxEndDate;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Pages\MakeContract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxRideType;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Pages\MakeContract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxRidePrice;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Pages\MakeContract.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMakeContract;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CarsRent.WPF;component/pages/makecontract.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\MakeContract.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbRenter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 31 "..\..\..\Pages\MakeContract.xaml"
            this.cbRenter.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.cbRenter_TextChanged));
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbCar = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\..\Pages\MakeContract.xaml"
            this.cbCar.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.cbCar_TextChanged));
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbxBeginDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbxEndDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cbxRideType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.tbxRidePrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnMakeContract = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\Pages\MakeContract.xaml"
            this.btnMakeContract.Click += new System.Windows.RoutedEventHandler(this.btnMakeContract_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

