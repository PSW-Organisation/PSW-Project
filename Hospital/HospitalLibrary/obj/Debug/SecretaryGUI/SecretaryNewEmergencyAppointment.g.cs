﻿#pragma checksum "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D4FC54DE7030A0DEF53E449402A951FE0CB949966CE260FA1B36B28701C95FF0"
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
    /// SecretaryNewEmergencyAppointment
    /// </summary>
    public partial class SecretaryNewEmergencyAppointment : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegisterPatientButton;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Patient;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Speciality;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Room;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Duration;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
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
            System.Uri resourceLocater = new System.Uri("/HospitalLibrary;component/secretarygui/secretarynewemergencyappointment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
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
            
            #line 8 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
            ((vezba.SecretaryGUI.SecretaryNewEmergencyAppointment)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.WindowKeyListener);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RegisterPatientButton = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
            this.RegisterPatientButton.Click += new System.Windows.RoutedEventHandler(this.RegisterPatientButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Patient = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Speciality = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Room = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Duration = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\SecretaryGUI\SecretaryNewEmergencyAppointment.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

