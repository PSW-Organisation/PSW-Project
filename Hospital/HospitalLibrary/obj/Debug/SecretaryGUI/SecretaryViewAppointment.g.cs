﻿#pragma checksum "..\..\..\SecretaryGUI\SecretaryViewAppointment.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1D2B66E0F3D0B660A6E29CDF8D0D0D5060C93260726044E2C5C0D9198579EE0D"
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
    /// SecretaryViewAppointment
    /// </summary>
    public partial class SecretaryViewAppointment : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\SecretaryGUI\SecretaryViewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Patient;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\SecretaryGUI\SecretaryViewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Doctor;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\SecretaryGUI\SecretaryViewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Room;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\SecretaryGUI\SecretaryViewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Date;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\SecretaryGUI\SecretaryViewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Time;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\SecretaryGUI\SecretaryViewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Duration;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\SecretaryGUI\SecretaryViewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Description;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\SecretaryGUI\SecretaryViewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalLibrary;component/secretarygui/secretaryviewappointment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SecretaryGUI\SecretaryViewAppointment.xaml"
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
            
            #line 8 "..\..\..\SecretaryGUI\SecretaryViewAppointment.xaml"
            ((vezba.SecretaryGUI.SecretaryViewAppointment)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.WindowKeyListener);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Patient = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Doctor = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Room = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Date = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Time = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Duration = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Description = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.CloseButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

