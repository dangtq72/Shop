﻿#pragma checksum "..\..\..\..\Control\Created\frmCreate_Item.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6368B657831243AB983E5AA07362D99C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
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


namespace NangShop.Control.Created {
    
    
    /// <summary>
    /// frmCreate_Item
    /// </summary>
    public partial class frmCreate_Item : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCount;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboColor;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddColor;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel grdBtn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAccept;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
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
            System.Uri resourceLocater = new System.Uri("/NangShop;component/control/created/frmcreate_item.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
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
            
            #line 5 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
            ((NangShop.Control.Created.frmCreate_Item)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 5 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
            ((NangShop.Control.Created.frmCreate_Item)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtCount = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
            this.txtCount.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtCount_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cboColor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.btnAddColor = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
            this.btnAddColor.Click += new System.Windows.RoutedEventHandler(this.btnAddColor_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.grdBtn = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.btnAccept = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
            this.btnAccept.Click += new System.Windows.RoutedEventHandler(this.btnAccept_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Control\Created\frmCreate_Item.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

