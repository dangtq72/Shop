﻿#pragma checksum "..\..\..\..\Control\User\User_Rights.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E7DFF9B41CF841AFE03803E77BD0088B"
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


namespace NangShop.User {
    
    
    /// <summary>
    /// User_Rights
    /// </summary>
    public partial class User_Rights : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 70 "..\..\..\..\Control\User\User_Rights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Control\User\User_Rights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\Control\User\User_Rights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grUser_Rights;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\..\Control\User\User_Rights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkCheckAll;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\..\Control\User\User_Rights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdButton;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\..\..\Control\User\User_Rights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnChapNhan;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\..\..\Control\User\User_Rights.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHuy;
        
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
            System.Uri resourceLocater = new System.Uri("/NangShop;component/control/user/user_rights.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Control\User\User_Rights.xaml"
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
            
            #line 4 "..\..\..\..\Control\User\User_Rights.xaml"
            ((NangShop.User.User_Rights)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\..\Control\User\User_Rights.xaml"
            ((NangShop.User.User_Rights)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 70 "..\..\..\..\Control\User\User_Rights.xaml"
            this.txtSearch.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.txtSearch_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\..\Control\User\User_Rights.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.grUser_Rights = ((System.Windows.Controls.DataGrid)(target));
            
            #line 96 "..\..\..\..\Control\User\User_Rights.xaml"
            this.grUser_Rights.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.grUser_Rights_LoadingRow);
            
            #line default
            #line hidden
            
            #line 97 "..\..\..\..\Control\User\User_Rights.xaml"
            this.grUser_Rights.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.grUser_Rights_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 19:
            this.chkCheckAll = ((System.Windows.Controls.CheckBox)(target));
            
            #line 178 "..\..\..\..\Control\User\User_Rights.xaml"
            this.chkCheckAll.Click += new System.Windows.RoutedEventHandler(this.chkCheckAll_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.grdButton = ((System.Windows.Controls.Grid)(target));
            return;
            case 21:
            this.btnChapNhan = ((System.Windows.Controls.Button)(target));
            
            #line 197 "..\..\..\..\Control\User\User_Rights.xaml"
            this.btnChapNhan.Click += new System.Windows.RoutedEventHandler(this.btnChapNhan_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            this.btnHuy = ((System.Windows.Controls.Button)(target));
            
            #line 198 "..\..\..\..\Control\User\User_Rights.xaml"
            this.btnHuy.Click += new System.Windows.RoutedEventHandler(this.btnHuy_Click);
            
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
            case 2:
            
            #line 17 "..\..\..\..\Control\User\User_Rights.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.Use_Right_Click);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 23 "..\..\..\..\Control\User\User_Rights.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.view_right_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 29 "..\..\..\..\Control\User\User_Rights.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.insert_right_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 35 "..\..\..\..\Control\User\User_Rights.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.update_right_Click);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 41 "..\..\..\..\Control\User\User_Rights.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.delete_right_Click);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 47 "..\..\..\..\Control\User\User_Rights.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.approveInfo_right_Click);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 53 "..\..\..\..\Control\User\User_Rights.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.Full_Right_Click);
            
            #line default
            #line hidden
            break;
            case 12:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewKeyDownEvent;
            
            #line 111 "..\..\..\..\Control\User\User_Rights.xaml"
            eventSetter.Handler = new System.Windows.Input.KeyEventHandler(this.Use_Right_PreviewKeyDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 13:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewKeyDownEvent;
            
            #line 122 "..\..\..\..\Control\User\User_Rights.xaml"
            eventSetter.Handler = new System.Windows.Input.KeyEventHandler(this.view_right_PreviewKeyDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 14:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewKeyDownEvent;
            
            #line 133 "..\..\..\..\Control\User\User_Rights.xaml"
            eventSetter.Handler = new System.Windows.Input.KeyEventHandler(this.insert_right_PreviewKeyDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 15:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewKeyDownEvent;
            
            #line 144 "..\..\..\..\Control\User\User_Rights.xaml"
            eventSetter.Handler = new System.Windows.Input.KeyEventHandler(this.update_right_PreviewKeyDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 16:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewKeyDownEvent;
            
            #line 155 "..\..\..\..\Control\User\User_Rights.xaml"
            eventSetter.Handler = new System.Windows.Input.KeyEventHandler(this.delete_right_PreviewKeyDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 17:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewKeyDownEvent;
            
            #line 166 "..\..\..\..\Control\User\User_Rights.xaml"
            eventSetter.Handler = new System.Windows.Input.KeyEventHandler(this.approveInfo_right_PreviewKeyDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 18:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewKeyDownEvent;
            
            #line 174 "..\..\..\..\Control\User\User_Rights.xaml"
            eventSetter.Handler = new System.Windows.Input.KeyEventHandler(this.Full_Right_PreviewKeyDown);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

