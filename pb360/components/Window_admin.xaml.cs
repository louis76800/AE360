using System.Windows;

namespace pb360.components
{
    /// <summary>
    /// Logique d'interaction pour Window_admin.xaml
    /// </summary>
    public partial class Window_admin : Window
    {
        //initialisation de la variable a renvoyer
        public string Mot_passe { get; set; }
        public Window_admin()
        {
            InitializeComponent();
        }
        private void buttonValidation_Click(object sender, RoutedEventArgs e)
        {
            //envoie du mot de passe a la frame
            Mot_passe = mdp.Password;
            DialogResult = true;
        }
    }
}
