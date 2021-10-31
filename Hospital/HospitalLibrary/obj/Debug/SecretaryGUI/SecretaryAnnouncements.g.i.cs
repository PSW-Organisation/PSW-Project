﻿#pragma checksum "..\..\..\SecretaryGUI\SecretaryAnnouncements.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "243A32EE7D8B9985A3A8C5E41B1683A9258F002F5A5F82EB368A9E81E647F48F"
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
using vezba.SecretaryGUI;


namespace vezba.SecretaryGUI {
    
    
    /// <summary>
    /// SecretaryAnnouncements
    /// </summary>
    public partial class SecretaryAnnouncements : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\SecretaryGUI\SecretaryAnnouncements.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid announcementTable;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\SecretaryGUI\SecretaryAnnouncements.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewAnnouncementButton;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\SecretaryGUI\SecretaryAnnouncements.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ViewAnnouncementButton;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\SecretaryGUI\SecretaryAnnouncements.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditAnnouncementButton;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\SecretaryGUI\SecretaryAnnouncements.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteAnnouncementButton;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalLibrary;component/secretarygui/secretaryannouncements.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SecretaryGUI\SecretaryAnnouncements.xaml"
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
            this.announcementTable = ((System.Windows.Controls.DataGrid)(target));
            
            #line 36 "..\..\..\SecretaryGUI\SecretaryAnnouncements.xaml"
            this.announcementTable.KeyDown += new System.Windows.Input.KeyEventHandler(this.OnKeyDownDataGridHandler);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NewAnnouncementButton = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\SecretaryGUI\SecretaryAnnouncements.xaml"
            this.NewAnnouncementButton.Click += new System.Windows.RoutedEventHandler(this.NewAnnouncementButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ViewAnnouncementButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\SecretaryGUI\SecretaryAnnouncements.xaml"
            this.ViewAnnouncementButton.Click += new System.Windows.RoutedEventHandler(this.ViewAnnouncementButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EditAnnouncementButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\SecretaryGUI\SecretaryAnnouncements.xaml"
            this.EditAnnouncementButton.Click += new System.Windows.RoutedEventHandler(this.EditAnnouncementButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DeleteAnnouncementButton = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\SecretaryGUI\SecretaryAnnouncements.xaml"
            this.DeleteAnnouncementButton.Click += new System.Windows.RoutedEventHandler(this.DeleteAnnouncementButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

