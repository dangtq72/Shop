﻿#pragma checksum "..\..\..\Display\Customer_Display.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7F2454D8B20D56033D9633AE43D2CE53"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AvalonDock;
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


namespace NangShop.Display {
    
    
    /// <summary>
    /// Customer_Display
    /// </summary>
    public partial class Customer_Display : AvalonDock.DockableContent, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 6 "..\..\..\Display\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal NangShop.Display.Customer_Display frmCustomerDisplay;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Display\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgrCustomer;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Display\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInsert;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Display\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Display\Customer_Display.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
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
            System.Uri resourceLocater = new System.Uri("/NangShop;component/display/customer_display.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Display\Customer_Display.xaml"
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
            this.frmCustomerDisplay = ((NangShop.Display.Customer_Display)(target));
            
            #line 6 "..\..\..\Display\Customer_Display.xaml"
            this.frmCustomerDisplay.Loaded += new System.Windows.RoutedEventHandler(this.frmColorDisplay_Loaded);
            
            #line default
            #line hidden
            
            #line 6 "..\..\..\Display\Customer_Display.xaml"
            this.frmCustomerDisplay.KeyDown += new System.Windows.Input.KeyEventHandler(this.frmColorDisplay_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 10 "..\..\..\Display\Customer_Display.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnInsert_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 11 "..\..\..\Display\Customer_Display.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 12 "..\..\..\Display\Customer_Display.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 13 "..\..\..\Display\Customer_Display.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btnView_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dgrCustomer = ((System.Windows.Controls.DataGrid)(target));
            
            #line 25 "..\..\..\Display\Customer_Display.xaml"
            this.dgrCustomer.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.dgrCustomer_LoadingRow);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\Display\Customer_Display.xaml"
            this.dgrCustomer.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.dgrCustomer_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnInsert = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Display\Customer_Display.xaml"
            this.btnInsert.Click += new System.Windows.RoutedEventHandler(this.btnInsert_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\Display\Customer_Display.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Display\Customer_Display.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
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
            case 7:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.PreviewMouseDoubleClickEvent;
            
            #line 29 "..\..\..\Display\Customer_Display.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.DoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}
