//les libraries utilisé
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
namespace pb360.components.Inscription
{
    public partial class Window_choix_service : Window
    {
        public Window_choix_service()
        {
            InitializeComponent();
            ActualiserDataGrid();
        }
        //initialisation des variables qui seront envoyer a la frame
        public string Id_service { get; set; }
        public string Service { get; set; }
        // innitialisation du tableau de donnée
        public class TabStock_accueil
        {
            public string Id { get; set; }
            public string Service { get; set; }
            public override string ToString()
            {
                return this.Id + ";" + this.Service ;
            }
        }
        private void buttonValidation_Click(object sender, RoutedEventArgs e)
        {
            if (listDataBiding_service.SelectedItem != null)
            {
                //je recupere le context
                var sender_context = sender as System.Windows.Controls.Button;
                var context = sender_context.DataContext as TabStock_accueil;
                //je recupere le context pour l'envoyer à la frame  id + service 
                Id_service = context.Id;
                Service = context.Service;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Veuillez choisir un fournisseur !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        public void ActualiserDataGrid()
        {
            //fonction d'actualisation du tableau principal
            MySqlConnection connexion = new MySqlConnection("database=louisbvbdminicha; server=localhost; user id=root; pwd=");
            try
            {
                connexion.Open();
                MySqlCommand cmd = connexion.CreateCommand();
                cmd.CommandText = "SELECT id_service,libelle_service FROM t_service";
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<TabStock_accueil> Items = new List<TabStock_accueil>();

                    while (reader.Read())
                    {
                        var id = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                        var service = reader.GetString(1); //The 1 stands for "the 1'th column", so the seconde column of the result.

                        Items.Add(new TabStock_accueil()
                        {
                            Id = id,
                            Service = service,
                        });

                    }

                    listDataBiding_service.ItemsSource = Items;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro" + erro);
                    connexion.Close();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(" non connecté");
                MessageBox.Show("" + erro);

            }
        }
    }
}
