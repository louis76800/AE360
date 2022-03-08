using MySql.Data.MySqlClient;
using pb360.components.Inscription;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace pb360.components.Administration.Gestion_salarie
{
    /// <summary>
    /// Logique d'interaction pour Page_modifier_salarie.xaml
    /// </summary>
    public partial class Page_modifier_salarie : Page
    {

        public string Id_modifier { get; set; }
        public MySqlConnection Connection { get; set; }
        public string isAdmin { get; set; }
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telfix { get; set; }
        public string Telport { get; set; }
        public string Email { get; set; }
        public string Service { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public Page_modifier_salarie(string email_mod, string nom_mod, string prenom_mod, string pays_mod, string service_mod, string telfix_mod, string telport_mod, string id_mod, string ville_mod, MySqlConnection connection_new)
        {
            InitializeComponent();
            Connection = connection_new;
            Id_modifier = id_mod;
            Nom = nom_mod;
            Prenom = prenom_mod;
            Telfix = telfix_mod;
            Telport = telport_mod;
            Email = email_mod;
            Service = service_mod;
            Ville = ville_mod;
            Pays = pays_mod;
            nom.Text = Nom;
            prenom.Text = Prenom;
            tel_fix.Text = Telfix;
            tel_port.Text = Telport;
            email.Text = Email;
            email.IsEnabled = false;
        }
        public string Id_service { get; set; }
        public string Id_site { get; set; }
        bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        private void service_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window_choix_service();
            var result = win.ShowDialog();
            if (result == true)
            {
                service.Content = win.Service;
                Id_service = win.Id_service;
            }
        }

        private void site_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window_choix_site();
            var result = win.ShowDialog();
            if (result == true)
            {
                site.Content = win.Site;
                Id_site = win.Id_site;
            }
        }
        private void Button_Click_inscription(object sender, RoutedEventArgs e)
        {
            //création de variable vérification des informations de l'utilisateur
            string Name = nom.Text;
            string Firstname = prenom.Text;
            string Phone = tel_fix.Text;
            string Phone_port = tel_port.Text;
            string Mail = email.Text;
            string Service = Id_service;
            string Site = Id_site;
            string Mdp = mot_de_passe.Password;
            if (Name == "" || Firstname == "" || Phone == "" || Mail == "" || Service == "" || Service == null || Site == null || Site == "")
            {
                MessageBox.Show("Merci de remplir tous les champs", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (IsValidEmail(Mail) != true)
            {
                MessageBox.Show("Merci de ne saisir un Email conforme", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Regex.IsMatch(Name, "[^a-zA-Z0-9À-ȕ&._-]", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Merci de ne saisir que lettre pour le nom", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (Regex.IsMatch(Firstname, "[^a-zA-Z0-9À-ȕ&._-]", RegexOptions.IgnoreCase))
                    {
                        MessageBox.Show("Merci de ne saisir que lettre pour le Prénom", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (Regex.IsMatch(Phone, "[^0-9]", RegexOptions.IgnoreCase))
                        {
                            MessageBox.Show("Merci de ne saisir que chiffre pour le numéro de téléphone fixe", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            if (Regex.IsMatch(Phone_port, "[^0-9]", RegexOptions.IgnoreCase))
                            {
                                MessageBox.Show("Merci de ne saisir que chiffre pour le numéro de téléphone", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                if (mot_de_passe.Password.Length < 8)
                                {
                                    MessageBox.Show("Mot de passe trop court", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                else
                                {
                                    if (Regex.IsMatch(mot_de_passe.Password, "[^a-zA-Z0-9À-ȕ&._-]", RegexOptions.IgnoreCase))
                                    {
                                        MessageBox.Show("Merci de ne saisir que lettre pour le mot de passe", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                    else
                                    {
                                        if (confirmation_mot_de_passe.Password == mot_de_passe.Password)
                                        {
                                            var result = MessageBox.Show("Confirmation de la création de " + Mail, "Confirmer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                            if (result == MessageBoxResult.Yes)
                                            { //modification après validation
                                              //TODO  vérifier que lemail n'existe pas deja en base 

                                                MySqlConnection connexion = Connection;
                                                try
                                                {
                                                    if (isadmin.IsChecked == true)
                                                    {
                                                        isAdmin = "ADMINISTRATEUR";
                                                    }
                                                    else
                                                    {
                                                        isAdmin = "VISITEUR";
                                                    }
                                                    connexion.Open();
                                                    MySqlCommand cmd = connexion.CreateCommand();
                                                    cmd.CommandText = "UPDATE t_salarie SET nom = '" + nom.Text + "', prenom = '" + prenom.Text + "', tel_fix = '" + tel_fix.Text + "', tel_portable = '" + tel_port.Text + "' , email = '" + email.Text + "' , service_id = '" + Id_service + "' , site_id = '" + Id_site + "' , PASSWORD = MD5('" + mot_de_passe.Password + "') , role = '" + isAdmin + "' WHERE id = '" + Id_modifier + "'";
                                                    try
                                                    {
                                                        MySqlDataReader reader = cmd.ExecuteReader();
                                                        MessageBox.Show("La modification à été effectué", "Modification", MessageBoxButton.OK, MessageBoxImage.Information);

                                                    }
                                                    catch (Exception erro)
                                                    {
                                                        MessageBox.Show("Erro" + erro);
                                                        connexion.Close();
                                                    }
                                                }
                                                catch
                                                {
                                                    MessageBox.Show("Non connecté à la base de donnée");
                                                }
                                            }
                                            else
                                            { // annulation après vérification
                                                MessageBox.Show("Création annulé", "Création", MessageBoxButton.OK, MessageBoxImage.Information);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("la confirmation du mot de passe n'est pas identique ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
//}