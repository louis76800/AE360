#pragma checksum "..\..\..\..\..\components\Administration\Gestion_site\Page_gestion_site.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F8E9D3371497BE22AAD5939C65AA6F547C2D6584D60D649AC38184E5C3B4E9EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using pb360.components.Administration.Gestion_site;


namespace pb360.components.Administration.Gestion_site {
    
    
    /// <summary>
    /// Page_gestion_site
    /// </summary>
    public partial class Page_gestion_site : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 32 "..\..\..\..\..\components\Administration\Gestion_site\Page_gestion_site.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Contents_gestion_salarie;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\components\Administration\Gestion_site\Page_gestion_site.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox recherche;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\components\Administration\Gestion_site\Page_gestion_site.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid listDataBiding_client;
        
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
            System.Uri resourceLocater = new System.Uri("/pb360;component/components/administration/gestion_site/page_gestion_site.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\components\Administration\Gestion_site\Page_gestion_site.xaml"
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
            this.Contents_gestion_salarie = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            
            #line 35 "..\..\..\..\..\components\Administration\Gestion_site\Page_gestion_site.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Ajout);
            
            #line default
            #line hidden
            return;
            case 3:
            this.recherche = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\..\..\components\Administration\Gestion_site\Page_gestion_site.xaml"
            this.recherche.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.recherche_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.listDataBiding_client = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            
            #line 46 "..\..\..\..\..\components\Administration\Gestion_site\Page_gestion_site.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Modifier);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 53 "..\..\..\..\..\components\Administration\Gestion_site\Page_gestion_site.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Supprimer);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

