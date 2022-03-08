using MySql.Data.MySqlClient;
using pb360.components;
using pb360.components.acceuil;
using pb360.components.Inscription;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace pb360
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Lemdp { get; set; } // le mot de passe admin
        public string Role_bdd { get; set; } // le role inscrit dans la bdd
        public string Key_admin { get; set; } // le key code pour afficher la popup admin
        public int Connection_admin { get; set; } // le nombre d'admin connecté
        public string Hash { get; set; } // le mot de passe hashé
        public MySqlConnection Connection { get; set; } // la connection a la bdd
        public string E { get; set; } // le key code
        public bool Close_win { get; set; } // le key code
        public MainWindow()
        {
            InitializeComponent();
            //connection au server
            Connection = new MySqlConnection("database=louisbvbdminicha; server=localhost; user id=root; pwd=");
            //mot de passe admin
            Lemdp = "mdpadmin";
            // key code popup admin
            Key_admin = "ADMINIST";
            //style
            deconnectionButton.Opacity = 0;
            retour.Opacity = 0;
            deconnectionButton.IsEnabled = false;
            retour.IsEnabled = false;
        }
        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            Close_function();
            e.Cancel = Close_win;
        }
        private void Button_Click_connection(object sender, RoutedEventArgs e)
        {
            //connection à lapplication
            MySqlConnection connexion = Connection;
            MySqlCommand cmd = connexion.CreateCommand();
            // convertire le mot de passe en mdp hashé 
            if (pass.Password.Length < 8)
            {
                MessageBox.Show("Mot de passe trop court", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Regex.IsMatch(pass.Password, "[^a-zA-Z0-9À-ȕ&._-]", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Merci de ne saisir que lettre pour le mot de passe", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    cmd.CommandText = "SELECT MD5('" + pass.Password + "')AS motpass; ";
                    try
                    {
                        connexion.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string hash = reader.GetString(0); //The 1 stands for "the 1'th column", so the seconde column of the result.
                            Hash = hash;
                        }
                        connexion.Close();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Erro" + erro);
                    }
                }
            }
            //le mot de passe hashé est récupéré
            try
            {
                //connection a la bdd pour la vérif de la concordence des ids
                connexion.Open();
                cmd.CommandText = "SELECT email,PASSWORD,role FROM t_salarie ";
                string confirmation = "";
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var email_bdd = reader.GetString(0); //The 1 stands for "the 1'st column", so the first column of the result.
                        var password_bdd = reader.GetString(1); //The 2 stands for "the 2'nd column", so the seconde column of the result.
                        var role_bdd = reader.GetString(2); //The 3 stands for "the 3'th column", so the third column of the result.
                        if (email.Text == email_bdd.ToString() && Hash == password_bdd.ToString())
                        // si l'email et le mdp concordent
                        {
                            //on ferme la connection 
                            connexion.Close();
                            // on envoie la page d'acceuil avec le role et la connection
                            role_bdd = "VISITEUR";
                            Role_bdd = role_bdd;
                            Contents.Content = new Page_accueil(role_bdd, connexion);
                            Contents.Opacity = 100;
                            deconnectionButton.Opacity = 100;
                            deconnectionButton.IsEnabled = true;
                            retour.IsEnabled = false;
                            Canvas.SetZIndex(Contents, 1);
                            email.Text = "";
                            pass.Password = "";
                            confirmation = "Bienvenu dans PDS360 ";
                            break;
                        }
                        else
                        {
                            confirmation = "Identifiants non reconnu, Merci de réessayer";
                        }
                    }
                    if (confirmation == "Bienvenu dans PDS360 ")
                    {
                        MessageBox.Show(confirmation, "Bienvenu", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(confirmation, "Réessayer", MessageBoxButton.OK, MessageBoxImage.Warning);
                        connexion.Close();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro" + erro);
                }
            }
            catch
            {
                MessageBox.Show("Non connecté à la base de donnée");
            }
        }
        private void deconnectionButton_Click(object sender, RoutedEventArgs e)
        { //se déconnecter
            MessageBox.Show("Vous êtes déconnecté", "Déconnexion", MessageBoxButton.OK, MessageBoxImage.Information);
            Contents.Opacity = 0;
            Canvas.SetZIndex(Contents, -1);
            deconnectionButton.Opacity = 0;
            deconnectionButton.IsEnabled = false;
            if (Role_bdd == "ADMINISTRATEUR")
            {
                MySqlConnection connexion = Connection;
                connexion.Open();
                MySqlCommand cmd = connexion.CreateCommand();
                cmd.CommandText = "UPDATE t_salarie SET connection_admin = '0' WHERE role= 'ADMINISTRATEUR'  ";
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    connexion.Close();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro" + erro);
                }
            }
        }
        public void Close_function()
        {
            var result = MessageBox.Show("Êtes-vous sûr de quitter l'application ?", "Quitter l'application", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (Role_bdd == "ADMINISTRATEUR")
                {
                    MySqlConnection connexion = Connection;
                    connexion.Open();
                    MySqlCommand cmd = connexion.CreateCommand();

                    cmd.CommandText = "UPDATE t_salarie SET connection_admin = '0' WHERE role= 'ADMINISTRATEUR'  ";
                    try
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        connexion.Close();
                        Close_win = false;
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Erro" + erro);
                    }
                }
                else
                {
                    //si l'utilisateur n'est pas admin
                    Close_win = false;
                }
            }
            else
            {
                //si l'utilisateur à répondu non 
                Close_win = true;
            }
        }
        private void Button_Click_inscription(object sender, RoutedEventArgs e)
        { // se connecter
            Contents.Content = new Page_inscription(Connection);
            Contents.Opacity = 100;
            retour.Opacity = 100;
            Canvas.SetZIndex(Contents, 1);
            retour.IsEnabled = true;
        }
        private void Button_Click_retour(object sender, RoutedEventArgs e)
        { // retour (page inscription)
            Contents.Opacity = 0;
            Canvas.SetZIndex(Contents, -1);
            deconnectionButton.Opacity = 0;
            retour.Opacity = 0;
        }
        private void windown_KeyDown(object sender, KeyEventArgs e)
        {
            // connection secrète en mode admin

            // --> mainWindow.xaml( KeyDown="windown_KeyDown")
            // on icrémente  E jusqu'& ce qu'il soit égale a 9 
            E = E + e.Key;

            if (E.Length == Key_admin.Length + 1)
            {
                //si il est égal a 9 on retire le premier caractère de la chaine 
                E = E.Substring(1);
            }
            if (E.Length > Key_admin.Length + 1)
            {
                // si il est supérieur a 9 (pavé numérique) on réinitialise 
                E = " ";
            }
            //si le mdp est bon
            if (E == Key_admin)
            {
                //on ouvre une popup mdp
                var win = new Window_admin();
                var result = win.ShowDialog();
                try
                {
                    MySqlConnection connexion = Connection;
                    //connection a la bdd pour la vérif de la concordence des ids
                    connexion.Open();
                    MySqlCommand cmd = connexion.CreateCommand();
                    cmd.CommandText = "SELECT count(*) as count FROM t_salarie where connection_admin = 1";
                    try
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var connection_admin = reader.GetInt32(0); //The 1 stands for "the 1'st column", so the first column of the result.
                            Connection_admin = connection_admin;
                        }
                        connexion.Close();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Erro" + erro);
                    }
                    if (Connection_admin == 0)
                    {
                        if (win.mdp.Password == Lemdp)
                        {
                            if (result == true)
                            {
                                // on envoie la page d'acceuil avec le role = admin et la connection
                                try
                                {
                                    //connection a la bdd pour la vérif de la concordence des ids
                                    connexion.Open();
                                    cmd.CommandText = "UPDATE t_salarie SET connection_admin = '1' WHERE role= 'ADMINISTRATEUR'  ";
                                    try
                                    {
                                        MySqlDataReader reader = cmd.ExecuteReader();
                                        connexion.Close();
                                        string role_bdd = "ADMINISTRATEUR";
                                        Role_bdd = role_bdd;
                                        Contents.Content = new Page_accueil(role_bdd, Connection);
                                        Contents.Opacity = 100;
                                        deconnectionButton.Opacity = 100;
                                        deconnectionButton.IsEnabled = true;
                                        retour.IsEnabled = false;
                                        Canvas.SetZIndex(Contents, 1);
                                        email.Text = "";
                                        pass.Password = "";
                                    }
                                    catch (Exception erro)
                                    {
                                        MessageBox.Show("Erro" + erro);
                                        connexion.Close();
                                    }
                                }
                                catch (Exception erro)
                                {
                                    MessageBox.Show("Erro" + erro);
                                    MessageBox.Show("Non connecté à la base de donnée");
                                    connexion.Close();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Un administrateur est déja connecté. Merci de réessayer ulterieurment", "Refus", MessageBoxButton.OK, MessageBoxImage.Error);
                        connexion.Close();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro" + erro);
                }
            }
        }
    }
}