﻿#pragma checksum "..\..\..\..\Control\Search\frmSearch_Customer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6E1C67D6FF3CC168CE5873E230B76F41"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace NangShop.Control.Search {
    
    
    /// <summary>
    /// frmSearch_Customer
    /// </summary>
    public partial class frmSearch_Customer : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 16 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomer_Name;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPhone;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgrProduct;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel grdBtn;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/NangShop;component/control/search/frmsearch_customer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
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
            
            #line 6 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
            ((NangShop.Control.Search.frmSearch_Customer)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 6 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
            ((NangShop.Control.Search.frmSearch_Customer)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtCustomer_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dgrProduct = ((System.Windows.Controls.DataGrid)(target));
            
            #line 24 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
            this.dgrProduct.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.dgrProduct_LoadingRow);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
            this.dgrProduct.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.dgrProduct_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.grdBtn = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 6:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.PreviewMouseDoubleClickEvent;
            
            #line 29 "..\..\..\..\Control\Search\frmSearch_Customer.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.DoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}
