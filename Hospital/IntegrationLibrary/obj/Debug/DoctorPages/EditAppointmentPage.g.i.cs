﻿#pragma checksum "..\..\..\DoctorPages\EditAppointmentPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E1F7CC7FD1DD60E98EA0309853A4206B873F6052E578FF8D501E682E21B52C19"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using vezba;
using vezba.DoctorValidation;


namespace vezba.DoctorPages {
    
    
    /// <summary>
    /// EditAppointmentPage
    /// </summary>
    public partial class EditAppointmentPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OkButton;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DemoButton;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StopDemoButton;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsEmergencyCB;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker StartDatePicker;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TimeTB;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DurationTB;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DescriptionTB;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPatients;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbRooms;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbDoctors;
        
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
            System.Uri resourceLocater = new System.Uri("/IntegrationLibrary;component/doctorpages/editappointmentpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.OkButton = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
            this.OkButton.Click += new System.Windows.RoutedEventHandler(this.OkButtonClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DemoButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
            this.DemoButton.Click += new System.Windows.RoutedEventHandler(this.RunDemoClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.StopDemoButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
            this.StopDemoButton.Click += new System.Windows.RoutedEventHandler(this.CancelDemoClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 69 "..\..\..\DoctorPages\EditAppointmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButtonClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.IsEmergencyCB = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.StartDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.TimeTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.DurationTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.DescriptionTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.cmbPatients = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.cmbRooms = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.cmbDoctors = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

