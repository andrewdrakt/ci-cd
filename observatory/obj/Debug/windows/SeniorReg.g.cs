﻿#pragma checksum "..\..\..\windows\SeniorReg.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F195D9B18977F375400E2B496C3DAAE7495DCE9C5E2B7ADB00F4A7C6F9566A76"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using observatory.windows;


namespace observatory.windows {
    
    
    /// <summary>
    /// SeniorReg
    /// </summary>
    public partial class SeniorReg : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\windows\SeniorReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameInput;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\windows\SeniorReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginInput;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\windows\SeniorReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordInput;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\windows\SeniorReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button registrationBtn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\windows\SeniorReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox departmentBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\windows\SeniorReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox roleBox;
        
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
            System.Uri resourceLocater = new System.Uri("/observatory;component/windows/seniorreg.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\windows\SeniorReg.xaml"
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
            this.nameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.loginInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.passwordInput = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.registrationBtn = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\windows\SeniorReg.xaml"
            this.registrationBtn.Click += new System.Windows.RoutedEventHandler(this.registrationBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.departmentBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.roleBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

