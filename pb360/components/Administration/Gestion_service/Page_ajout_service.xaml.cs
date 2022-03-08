using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace pb360.components.Administration.Gestion_service
{
    public partial class Page_ajout_service : Page
    {
        public string Id_modifier { get; set; }
        public string Id { get; set; }
        public string Service { get; set; }
        public MySqlConnection Connexion { get; set; }

        public Page_ajout_service(MySqlConnection connexion_new)
        {
            Connexion = connexion_new;
            InitializeComponent();
        }
        private void Button_Click_inscription(object sender, RoutedEventArgs e)
        {
            //création de variable vérification des informations de l'utilisateur
            Service = service.Text;
            if (Service == "" || Service == null)
            {
                _ = MessageBox.Show("Merci de remplir tous les champs", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Regex.IsMatch(Service, "[^a-zA-Z0-9À-ȕ&._-]", RegexOptions.IgnoreCase))
                {
                    _ = MessageBox.Show("Merci de ne saisir que lettre pour le service", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MySqlConnection connexion = Connexion;
                    try
                    {
                        connexion.Open();
                        MySqlCommand cmd = connexion.CreateCommand();
                        cmd.CommandText = "INSERT INTO t_service (libelle_service) values ('" + Service + "')";
                        try
                        {
                            //insertion en bdd
                            MySqlDataReader reader = cmd.ExecuteReader();
                            _ = MessageBox.Show("La création à été effectué", "Création", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    }
                }
            }
        }
    }
}
