using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace pb360.components.Administration.Gestion_site
{
    /// <summary>
    /// Logique d'interaction pour Page_modifier_site.xaml
    /// </summary>
    public partial class Page_modifier_site : Page
    {
        //innitialisation des variables
        public string Id_modifier { get; set; }
        public string Id { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public MySqlConnection Connexion { get; set; }


        public Page_modifier_site(string ville_mod, string pays_mod, string id_mod, MySqlConnection connexion_new)
        {
            InitializeComponent();
            //récupération de la connection 
            Connexion = connexion_new;

            //Récupération desvariables recus
            Id_modifier = id_mod;
            Ville = ville_mod;
            Pays = pays_mod;
            ville.Text = Ville;
            pays.Text = Pays;
        }
        private void Button_Click_inscription(object sender, RoutedEventArgs e)
        {
            //création de variable vérification des informations de l'utilisateur

            if (Ville == "" || Pays == "" || Ville == null || Pays == null)
            {
                MessageBox.Show("Merci de remplir tous les champs", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Regex.IsMatch(ville.Text, "[^a-zA-Z0-9À-ȕ&._-]", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Merci de ne saisir que lettre pour la ville", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (Regex.IsMatch(pays.Text, "[^a-zA-Z0-9À-ȕ&._-]", RegexOptions.IgnoreCase))
                    {
                        MessageBox.Show("Merci de ne saisir que lettre pour le pays", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {

                        MySqlConnection connexion = Connexion;
                        try
                        {
                            connexion.Open();
                            MySqlCommand cmd = connexion.CreateCommand();
                            cmd.CommandText = "UPDATE t_site SET  ville = '" + ville.Text + "', pays = '" + pays.Text + "' WHERE id_site = '" + Id_modifier + "'";
                            try
                            {
                                MySqlDataReader reader = cmd.ExecuteReader();
                                MessageBox.Show("La modification à été effectué", "Modification", MessageBoxButton.OK, MessageBoxImage.Information);
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
                            MessageBox.Show("Non connecté à la base de donnée");
                            connexion.Close();

                        }
                    }
                }
            }
        }
    }
}
