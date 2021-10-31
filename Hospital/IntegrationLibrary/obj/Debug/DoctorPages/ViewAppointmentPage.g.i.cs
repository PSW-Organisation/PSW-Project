﻿#pragma checksum "..\..\..\DoctorPages\ViewAppointmentPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6EF4FE123F2DAAE0FE39FDA5F2E1EF3A9048C5B486983A11B0E2147D9F52CE20"
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
using vezba;


namespace vezba.DoctorPages {
    
    
    /// <summary>
    /// ViewAppointmentPage
    /// </summary>
    public partial class ViewAppointmentPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock IsEmergencyTB;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock startTB;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DurationTB;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DescriptionTB;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock cmbPatients;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock cmbRooms;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock cmbDoctors;
        
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
            System.Uri resourceLocater = new System.Uri("/IntegrationLibrary;component/doctorpages/viewappointmentpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
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
            
            #line 42 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MedicalRecordClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 43 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NewAnamnesisClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 44 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 45 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 46 "..\..\..\DoctorPages\ViewAppointmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReturnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.IsEmergencyTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.startTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.DurationTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.DescriptionTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.cmbPatients = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.cmbRooms = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.cmbDoctors = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

