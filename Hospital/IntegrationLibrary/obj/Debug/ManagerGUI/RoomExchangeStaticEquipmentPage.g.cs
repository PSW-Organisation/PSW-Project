﻿#pragma checksum "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C95CF8CBAB1B6D42EB8C979E130438D8319EB1818F6309E31CEDF235AA601BEE"
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
    /// RoomExchangeStaticEquipmentPage
    /// </summary>
    public partial class RoomExchangeStaticEquipmentPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 93 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OkButton;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Količina;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RoomToMerge;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date;
        
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
            System.Uri resourceLocater = new System.Uri("/IntegrationLibrary;component/managergui/roomexchangestaticequipmentpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
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
            
            #line 31 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonMainClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 38 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonRoomsClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 45 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonInventoryClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 73 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonMedicineClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.OkButton = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
            this.OkButton.Click += new System.Windows.RoutedEventHandler(this.OkButtonClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButtonClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Količina = ((System.Windows.Controls.TextBox)(target));
            
            #line 112 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
            this.Količina.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Količina_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RoomToMerge = ((System.Windows.Controls.ComboBox)(target));
            
            #line 135 "..\..\..\ManagerGUI\RoomExchangeStaticEquipmentPage.xaml"
            this.RoomToMerge.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RoomToMerge_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Date = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

