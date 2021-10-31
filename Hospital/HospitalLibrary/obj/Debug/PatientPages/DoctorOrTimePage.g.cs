﻿#pragma checksum "..\..\..\PatientPages\DoctorOrTimePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7A88259B3BD1F32D08D25C6F10C962293FF10FCAC6D1B0A7E86DD9576A056913"
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
using vezba.PatientPages;


namespace vezba.PatientPages {
    
    
    /// <summary>
    /// DoctorOrTimePage
    /// </summary>
    public partial class DoctorOrTimePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\PatientPages\DoctorOrTimePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton DoctorRadioBtn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\PatientPages\DoctorOrTimePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton TimeRadioBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalLibrary;component/patientpages/doctorortimepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PatientPages\DoctorOrTimePage.xaml"
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
            this.DoctorRadioBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 21 "..\..\..\PatientPages\DoctorOrTimePage.xaml"
            this.DoctorRadioBtn.Checked += new System.Windows.RoutedEventHandler(this.OrderDoctorAppointment);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TimeRadioBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 22 "..\..\..\PatientPages\DoctorOrTimePage.xaml"
            this.TimeRadioBtn.Checked += new System.Windows.RoutedEventHandler(this.OrderTimeAppointment);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

