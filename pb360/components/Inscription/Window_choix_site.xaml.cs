//les libraries utilisé
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
namespace pb360.components.Inscription
{
    public partial class Window_choix_site : Window
    {
        public Window_choix_site()
        {
            InitializeComponent();
            ActualiserDataGrid();
        }
        //initialisation des variables qui seront envoyer a la frame
        public string Id_site { get; set; }
        public string Site { get; set; }
        // innitialisation du tableau de donnée
        public class TabStock_accueil
        {
            public string Id { get; set; }
            public string Ville { get; set; }
            public string Pays { get; set; }
            public override string ToString()
            {
                return this.Id + ";" + this.Ville + ";" + this.Pays;
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
                cmd.CommandText = " SELECT id_site,ville,pays FROM t_site";
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<TabStock_accueil> Items = new List<TabStock_accueil>();
                    while (reader.Read())
                    {
                        var id = reader.GetString(0); //The 0 stands for "the 1'st column", so the first column of the result.
                        var ville = reader.GetString(1); //The 1 stands for "the 2'rd column", so the seconde column of the result.
                        var pays = reader.GetString(2); //The 2 stands for "the 3'th column", so the third column of the result.
                        Items.Add(new TabStock_accueil()
                       //a chaque boucle, ajoute une ligne au tableau
                        {
                            Id = id,
                            Ville = ville,
                            Pays = pays
                        });
                    }
                    // envoie des données dans la table de données
                    listDataBiding_site.ItemsSource = Items;
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
        private void buttonValidation_Click(object sender, RoutedEventArgs e)
        {
            //je recupere le context 
            var sender_context = sender as System.Windows.Controls.Button;
            var context = sender_context.DataContext as TabStock_accueil;
            //je recupere le context pour l'envoyer à la frame  id + ville +pays 
            Id_site = context.Id;
            Site = context.Ville + ", "+ context.Pays;
            DialogResult = true;
        }
    }
}
