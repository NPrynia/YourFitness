﻿#pragma checksum "..\..\..\..\Pages\ResitrationPage1.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BA531B59C5DAE2DD57BB4FCA9D5888CE9A294203"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Expression.Media;
using HandyControl.Expression.Shapes;
using HandyControl.Interactivity;
using HandyControl.Media.Animation;
using HandyControl.Media.Effects;
using HandyControl.Properties.Langs;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl.Tools.Converter;
using HandyControl.Tools.Extension;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using YourFitness.Pages;


namespace YourFitness.Pages {
    
    
    /// <summary>
    /// ResitrationPage1
    /// </summary>
    public partial class ResitrationPage1 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 94 "..\..\..\..\Pages\ResitrationPage1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFname;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\Pages\ResitrationPage1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSurname;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\Pages\ResitrationPage1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock weightTB;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\Pages\ResitrationPage1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.PreviewSlider weightSlider;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\Pages\ResitrationPage1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock heightTB;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\..\Pages\ResitrationPage1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.PreviewSlider heightSlider;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\Pages\ResitrationPage1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnContinue;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/YourFitness;component/pages/resitrationpage1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\ResitrationPage1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbFname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbSurname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.weightTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.weightSlider = ((HandyControl.Controls.PreviewSlider)(target));
            
            #line 108 "..\..\..\..\Pages\ResitrationPage1.xaml"
            this.weightSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.weightSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.heightTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.heightSlider = ((HandyControl.Controls.PreviewSlider)(target));
            
            #line 122 "..\..\..\..\Pages\ResitrationPage1.xaml"
            this.heightSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.heightSlider_ValueChanged_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnContinue = ((System.Windows.Controls.Button)(target));
            
            #line 151 "..\..\..\..\Pages\ResitrationPage1.xaml"
            this.btnContinue.Click += new System.Windows.RoutedEventHandler(this.btnContinue_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

