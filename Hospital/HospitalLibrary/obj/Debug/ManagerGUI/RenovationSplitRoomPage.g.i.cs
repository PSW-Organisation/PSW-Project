﻿#pragma checksum "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ECAB0BEA1D5176EF914ED48B654BD497AEB08F0C46748AE2E808DA010352249C"
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
using vezba.ManagerGUI;
using vezba.ManagerValidation;


namespace vezba.ManagerGUI {
    
    
    /// <summary>
    /// RenovationSplitRoomPage
    /// </summary>
    public partial class RenovationSplitRoomPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 93 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OkButton;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock BrojProstorije;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePicker;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DurationTB;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combo1;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Combo2;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalLibrary;component/managergui/renovationsplitroompage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
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
            
            #line 31 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonMainClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 38 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonRoomsClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 45 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonInventoryClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 73 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonMedicineClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.OkButton = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
            this.OkButton.Click += new System.Windows.RoutedEventHandler(this.OkButtonClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 100 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButtonClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BrojProstorije = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.DatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.DurationTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 117 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
            this.DurationTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Trajanje_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Combo1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 142 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
            this.Combo1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Combo1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Combo2 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 143 "..\..\..\ManagerGUI\RenovationSplitRoomPage.xaml"
            this.Combo2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Combo2_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

