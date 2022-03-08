using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
namespace pb360.components.Administration.Gestion_service
{
    public partial class Page_modifier_service : Page
    {
        // innitialisation des variables
        public string Id_modifier { get; set; }
        public string Id { get; set; }
        public string Service { get; set; }
        public MySqlConnection Connexion { get; set; }

        public Page_modifier_service(string service_mod, string id_mod, MySqlConnection connexion_new)

        {
            InitializeComponent();
            //récupération des ids + connection
            Id_modifier = id_mod;
            Service = service_mod;
            Connexion = connexion_new;
            service.Text = Service;

        }
        private void Button_Click_inscription(object sender, RoutedEventArgs e)
        {
            //création de variable vérification des informations de l'utilisateur
            Service= service.Text;

            //vérification de la variable service
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
                        cmd.CommandText = "UPDATE t_service SET  libelle_service = '" + Service + "' WHERE id_service = '" + Id_modifier + "'";
                        try
                        {
                            //execution de la requete
                            MySqlDataReader reader = cmd.ExecuteReader();
                            _ = MessageBox.Show("La modification à été effectué", "Modification", MessageBoxButton.OK, MessageBoxImage.Information);
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
