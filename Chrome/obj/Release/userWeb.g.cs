﻿#pragma checksum "..\..\userWeb.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E04DEBE08C898EB0D8E1E60B4AF18B5E93BF7C5A"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Chrome;
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


namespace Chrome {
    
    
    /// <summary>
    /// userWeb
    /// </summary>
    public partial class userWeb : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\userWeb.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Refresh;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\userWeb.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Url;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\userWeb.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_shoucang;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\userWeb.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\userWeb.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel shoucang;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\userWeb.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser web;
        
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
            System.Uri resourceLocater = new System.Uri("/Chrome;component/userweb.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\userWeb.xaml"
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
            
            #line 21 "..\..\userWeb.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 24 "..\..\userWeb.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ForwardButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Refresh = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\userWeb.xaml"
            this.Refresh.Click += new System.Windows.RoutedEventHandler(this.RefreshButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Url = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\userWeb.xaml"
            this.Url.KeyDown += new System.Windows.Input.KeyEventHandler(this.Url_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_shoucang = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\userWeb.xaml"
            this.btn_shoucang.Click += new System.Windows.RoutedEventHandler(this.Btn_shoucang);
            
            #line default
            #line hidden
            return;
            case 6:
            this.border = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.shoucang = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.web = ((System.Windows.Controls.WebBrowser)(target));
            
            #line 62 "..\..\userWeb.xaml"
            this.web.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(this.Web_LoadCompleted);
            
            #line default
            #line hidden
            
            #line 62 "..\..\userWeb.xaml"
            this.web.Navigated += new System.Windows.Navigation.NavigatedEventHandler(this.BrowserControl_Navigated);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

