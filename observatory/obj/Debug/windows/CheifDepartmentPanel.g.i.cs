﻿#pragma checksum "..\..\..\windows\CheifDepartmentPanel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2C85EA96429074B904FDED434D5ED77B66B69604CEE0FD10FEC257E367E37501"
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
    /// CheifDepartmentPanel
    /// </summary>
    public partial class CheifDepartmentPanel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\windows\CheifDepartmentPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button programmExitBtn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\windows\CheifDepartmentPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid taskDG;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\windows\CheifDepartmentPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox attachment;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\windows\CheifDepartmentPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox description;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\windows\CheifDepartmentPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editReport;
        
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
            System.Uri resourceLocater = new System.Uri("/observatory;component/windows/cheifdepartmentpanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\windows\CheifDepartmentPanel.xaml"
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
            this.programmExitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\windows\CheifDepartmentPanel.xaml"
            this.programmExitBtn.Click += new System.Windows.RoutedEventHandler(this.programmExitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.taskDG = ((System.Windows.Controls.DataGrid)(target));
            
            #line 25 "..\..\..\windows\CheifDepartmentPanel.xaml"
            this.taskDG.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.taskDG_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.attachment = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 54 "..\..\..\windows\CheifDepartmentPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AttachReport_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.editReport = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\windows\CheifDepartmentPanel.xaml"
            this.editReport.Click += new System.Windows.RoutedEventHandler(this.EditReport_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 56 "..\..\..\windows\CheifDepartmentPanel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ViewNotes_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

