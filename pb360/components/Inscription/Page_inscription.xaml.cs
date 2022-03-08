// les librairies utilisé
using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
namespace pb360.components.Inscription
{
    public partial class Page_inscription : Page
    {
        //initialisation de la connection
        public MySqlConnection Connection { get; set; }
        public Page_inscription(MySqlConnection connection_new)
        {
            InitializeComponent();
            //récupération de la connection
            Connection = connection_new;
        }
        //initialisation des variables
        public string Id_service { get; set; }
        public string Id_site { get; set; }
        public int Emailisok { get; set; }
        bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        private void service_Click(object sender, RoutedEventArgs e)
        {
            //ouvre la fenetre de choix
            var win = new Window_choix_service();
            var result = win.ShowDialog();
            if (result == true)
            {
                //recupere le choix
                service.Content = win.Service;
                Id_service = win.Id_service;
            }
        }
        private void site_Click(object sender, RoutedEventArgs e)
        {
            //ouvre la fenetre de choix
            var win = new Window_choix_site();
            var result = win.ShowDialog();
            if (result == true)
            {
                //recupere le choix
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
            if (Name == "" || Firstname == "" || (Phone == "" && Phone_port == "") || Mail == "" || Service == "" || Service == null || Site == null || Site == "")
            {
                MessageBox.Show("Merci de remplir tous les champs", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
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
                                    if (Phone.Length != 10 || Phone_port.Length != 10)
                                    {
                                        MessageBox.Show(" Merci de saisir des numéros de téléphones valides: \r(format: 0123456789)", "Erreur",MessageBoxButton.OK,MessageBoxImage.Error) ;
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
                                                    try
                                                    {
                                                        MySqlConnection connexion = Connection;

                                                        //connection a la bdd pour la vérif de la concordence des ids
                                                        connexion.Open();
                                                        MySqlCommand cmd = connexion.CreateCommand();

                                                        cmd.CommandText = "SELECT count(*) as count FROM t_salarie where email ='" + email.Text + "'";
                                                        try
                                                        {
                                                            MySqlDataReader reader = cmd.ExecuteReader();
                                                            while (reader.Read())
                                                            {
                                                                var emailisok = reader.GetInt32(0); //The 1 stands for "the 1'st column", so the first column of the result.
                                                                Emailisok = emailisok;
                                                            }
                                                            connexion.Close();
                                                        }
                                                        catch (Exception erro)
                                                        {
                                                            MessageBox.Show("Erro" + erro);
                                                        }
                                                    }
                                                    catch { }
                                                    if (Emailisok == 0)
                                                    {
                                                        var result = MessageBox.Show("Confirmation de la création de " + Mail, "Confirmer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                                        if (result == MessageBoxResult.Yes)
                                                        { //modification après validation

                                                            //TODO  vérifier que lemail n'existe pas deja en base 

                                                            MySqlConnection connexion = Connection;
                                                            try
                                                            {

                                                                connexion.Open();
                                                                MySqlCommand cmd = connexion.CreateCommand();
                                                                cmd.CommandText = "" +
                                                                    "INSERT INTO t_salarie (nom,prenom,tel_fix, tel_portable, email, service_id, site_id, PASSWORD,role )" +
                                                                    " VALUES('" + nom.Text + "', '" + prenom.Text + "', '" + tel_fix.Text + "', '" + tel_port.Text + "', '" + email.Text + "', '" + Id_service + "', '" + Id_site + "', MD5( '" + mot_de_passe.Password + "'), 'VISITEUR')";
                                                                try
                                                                {
                                                                    MySqlDataReader reader = cmd.ExecuteReader();
                                                                    MessageBox.Show("Inscription de " + prenom.Text + " " + nom.Text + " à été faite", "Inscription", MessageBoxButton.OK, MessageBoxImage.Information);
                                                                    connexion.Close();

                                                                }
                                                                catch (Exception erro)
                                                                {
                                                                    MessageBox.Show("Erro" + erro);
                                                                    connexion.Close();
                                                                }
                                                            }
                                                            catch
                                                            {
                                                                connexion.Close();
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
                                                        MessageBox.Show("L'Email existe déjà. Contactez votre administrateur si vous avez oublié votre mot de passe", "Problème", MessageBoxButton.OK, MessageBoxImage.Information);
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
    }
}