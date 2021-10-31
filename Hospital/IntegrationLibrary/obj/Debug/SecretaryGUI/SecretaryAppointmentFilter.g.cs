﻿#pragma checksum "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "540FC01611E6AF54C683E307DC85072EADC722A8F6565FAC1745DDEB7BD43D70"
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
using vezba.SecretaryGUI.Validation;


namespace vezba.SecretaryGUI {
    
    
    /// <summary>
    /// SecretaryAppointmentFilter
    /// </summary>
    public partial class SecretaryAppointmentFilter : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox From;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox To;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Patient;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Doctor;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Room;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton AllConditions;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton AnyContition;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
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
            System.Uri resourceLocater = new System.Uri("/IntegrationLibrary;component/secretarygui/secretaryappointmentfilter.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
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
            
            #line 9 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
            ((vezba.SecretaryGUI.SecretaryAppointmentFilter)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.WindowKeyListener);
            
            #line default
            #line hidden
            return;
            case 2:
            this.From = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.To = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Patient = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Doctor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Room = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.AllConditions = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.AnyContition = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\SecretaryGUI\SecretaryAppointmentFilter.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

