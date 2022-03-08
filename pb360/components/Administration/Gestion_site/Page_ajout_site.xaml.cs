using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace pb360.components.Administration.Gestion_site
{
    public partial class Page_ajout_site : Page
    {
        public string Id_modifier { get; set; }
        public string Id { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public MySqlConnection Connexion { get; set; }
        public Page_ajout_site(MySqlConnection connexion_new)
        {
            InitializeComponent();
            //récupération de la connection à la bdd
            Connexion = connexion_new;
        }
        private void Button_Click_inscription(object sender, RoutedEventArgs e)
        {
            //création de variable vérification des informations de l'utilisateur
            Ville = ville.Text;
            Pays = pays.Text;
            //vérification du contenu des variable avant insertion en base
            if (Ville == "" || Pays == "" || Ville == null || Pays == null)
            {
                _ = MessageBox.Show("Merci de remplir tous les champs", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Regex.IsMatch(Ville, "[^a-zA-Z0-9À-ȕ&._-]", RegexOptions.IgnoreCase))
                {
                    _ = MessageBox.Show("Merci de ne saisir que lettre pour la Ville", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (Regex.IsMatch(Pays, "[^a-zA-Z0-9À-ȕ&._-]", RegexOptions.IgnoreCase))
                    {
                        _ = MessageBox.Show("Merci de ne saisir que lettre pour le Pays", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MySqlConnection connexion = Connexion;
                        try
                        {
                            connexion.Open();
                            MySqlCommand cmd = connexion.CreateCommand();
                            cmd.CommandText = "INSERT INTO t_site (ville,pays) values ( '" + ville.Text + "',  '" + pays.Text + "')";
                            try
                            {
                                MySqlDataReader reader = cmd.ExecuteReader();
                                _ = MessageBox.Show("La création à été effectué", "Modification", MessageBoxButton.OK, MessageBoxImage.Information);
                                connexion.Close();
                            }
                            catch (Exception erro)
                            {
                                _ = MessageBox.Show("Erro" + erro);
                                connexion.Close();
                            }
                        }
                        catch
                        {
                            _ = MessageBox.Show("Non connecté à la base de donnée");
                            connexion.Close();
                        }
                    }
                }
            }
        }
    }
}
