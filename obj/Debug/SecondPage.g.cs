﻿#pragma checksum "..\..\SecondPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C5CFADCBDF4EA6D6951C8921FBEFC1F3E7FA4E8B71B366EF0C5065903BF804F0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FinalWPF;
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


namespace FinalWPF {
    
    
    /// <summary>
    /// SecondPage
    /// </summary>
    public partial class SecondPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\SecondPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridDB;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\SecondPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Quantity;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\SecondPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BeerIDBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\SecondPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox IngredientIDBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\SecondPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\SecondPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/FinalWPF;component/secondpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SecondPage.xaml"
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
            this.DataGridDB = ((System.Windows.Controls.DataGrid)(target));
            
            #line 26 "..\..\SecondPage.xaml"
            this.DataGridDB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridDB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Quantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BeerIDBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\SecondPage.xaml"
            this.BeerIDBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.BeerIDBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.IngredientIDBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\SecondPage.xaml"
            this.IngredientIDBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.IngredientIDBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\SecondPage.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EditBtn = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\SecondPage.xaml"
            this.EditBtn.Click += new System.Windows.RoutedEventHandler(this.EditBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

