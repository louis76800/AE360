// librairie pour mysql
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
namespace pb360.components.Administration.Gestion_site
{
    public partial class Page_gestion_site : Page
    {
        //innitialisation des variables
        public string Id_delete { get; set; }
        public MySqlConnection Connexion { get; set; }
        public string Count_delete { get; set; }
        public string Role_bdd { get; }
        //récupération de la connection de la page précédente
        public Page_gestion_site(string role_bdd, MySqlConnection connexion_new)
        {
            InitializeComponent();
            Role_bdd = role_bdd;
            Connexion = connexion_new;
            ActualiserDataGrid();
        }
        public class TabStock_site
        {
            public string Id { get; set; }
            public string Ville { get; set; }
            public string Pays { get; set; }
            public override string ToString()
            {
                return this.Id + ";" + this.Ville + ";" + this.Pays;
            }
        }
        public class TabStock
        {
            public string Count { get; set; }
            public override string ToString()
            {
                return this.Count;
            }
        }
        public void ActualiserDataGrid()
        {
            MySqlConnection connexion = Connexion;
            try
            {
                connexion.Open();
                MySqlCommand cmd = connexion.CreateCommand();
                cmd.CommandText = " SELECT id_site,ville,pays FROM t_site  ";
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<TabStock_site> Items = new List<TabStock_site>();
                    while (reader.Read())
                    {
                        var id = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                        var ville = reader.GetString(1); //The 1 stands for "the 1'th column", so the seconde column of the result.
                        var pays = reader.GetString(2); //The 1 stands for "the 1'th column", so the seconde column of the result.
                        Items.Add(new TabStock_site()
                        {
                            Id = id,
                            Ville = ville,
                            Pays = pays
                        });
                    }
                    listDataBiding_client.ItemsSource = Items;
                    connexion.Close();
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
                connexion.Close();
            }
        }
        private void recherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            //recherche si le texte est supérieur ou égal a 4 caractère
            if (recherche.Text.Length >= 4)
            {
                if (Regex.IsMatch(recherche.Text, "[^a-zA-Z0-9À-ȕ&._-]", RegexOptions.IgnoreCase))
                {
                    recherche.Text = "";
                    MessageBox.Show("Merci de ne saisir que lettre pour le nom", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MySqlConnection connexion = Connexion;
                    try
                    {
                        connexion.Open();
                        MySqlCommand cmd = connexion.CreateCommand();
                        cmd.CommandText = "  SELECT id_site,ville,pays FROM t_site where ville like'%" + recherche.Text + "%' or pays like'%" + recherche.Text + "%' ";
                        try
                        {
                            MySqlDataReader reader = cmd.ExecuteReader();
                            List<TabStock_site> Items = new List<TabStock_site>();
                            while (reader.Read())
                            {
                                var id = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                                var ville = reader.GetString(1); //The 1 stands for "the 1'th column", so the seconde column of the result.
                                var pays = reader.GetString(2); //The 1 stands for "the 1'th column", so the seconde column of the result.
                                Items.Add(new TabStock_site()
                                {
                                    Id = id,
                                    Ville = ville,
                                    Pays = pays
                                });
                            }
                            listDataBiding_client.ItemsSource = Items;
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
                        MessageBox.Show(" non connecté");
                        connexion.Close();
                    }
                }
            }
            //recherche si la longueur du texte est égale a 0
            else if (recherche.Text.Length == 0)
            {
                MySqlConnection connexion = Connexion;
                try
                {
                    //ouverture de la connection
                    connexion.Open();
                    MySqlCommand cmd = connexion.CreateCommand();
                    cmd.CommandText = " SELECT id_site,ville,pays FROM t_site  ";
                    try
                    {
                        //execution de la requete
                        MySqlDataReader reader = cmd.ExecuteReader();
                        List<TabStock_site> Items = new List<TabStock_site>();
                        while (reader.Read())
                        {
                            //récupération des données
                            var id = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                            var ville = reader.GetString(1); //The 1 stands for "the 1'th column", so the seconde column of the result.
                            var pays = reader.GetString(2); //The 1 stands for "the 1'th column", so the seconde column of the result.
                            Items.Add(new TabStock_site()
                            {
                                Id = id,
                                Ville = ville,
                                Pays = pays
                            });
                        }
                        //affichage de la liste dans le tableau
                        listDataBiding_client.ItemsSource = Items;
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
                    MessageBox.Show(" non connecté");
                    connexion.Close();
                }
            }
        }
        private void Button_Click_Supprimer(object sender, RoutedEventArgs e)
        {
            //récupération du context
            var sender_context = sender as System.Windows.Controls.Button;
            var context = sender_context.DataContext as TabStock_site;
            Id_delete = context.Id;
            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ?", "Confirmer", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            { //suppression après validation
                MySqlConnection connexion = Connexion;
                try
                {
                    //récupération du nombre d'utilisateur dans le service
                    connexion.Open();
                    MySqlCommand cmd = connexion.CreateCommand();
                    cmd.CommandText = " SELECT COUNT(*) AS count_site FROM t_site INNER JOIN t_salarie ON site_id = id_site WHERE site_id = '" + context.Id + "'  ";
                    try
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        List<TabStock> Items = new List<TabStock>();
                        while (reader.Read())
                        {
                            var count_site = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                            Items.Add(new TabStock()
                            {
                                Count = count_site
                            });
                            Count_delete = count_site;
                        }
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
                    MessageBox.Show(" non connecté");
                    connexion.Close();
                }
                // si le count est différent de 0 on modifie seulement le nom du service
                if (Count_delete != "0")
                {
                    try
                    {
                        connexion.Open();
                        MySqlCommand cmd = connexion.CreateCommand();
                        cmd.CommandText = "update t_site set ville = 'Supprimé (anciennement: " + context.Ville + ")', pays ='Supprimé (anciennement: " + context.Pays + ")' where id_site ='" + Id_delete + "' ";
                        try
                        {
                            MySqlDataReader deleter = cmd.ExecuteReader();
                            connexion.Close();
                            ActualiserDataGrid();
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show("Erro" + erro);
                            connexion.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show(" non connecté");
                        connexion.Close();
                    }
                }
                // si c'est égale a 0 on supprime le site
                else
                {
                    try
                    {
                        connexion.Open();
                        MySqlCommand cmd = connexion.CreateCommand();
                        cmd.CommandText = "DELETE FROM t_site WHERE id_site ='" + Id_delete + "' ";
                        try
                        {
                            MySqlDataReader deleter = cmd.ExecuteReader();
                            connexion.Close();
                            ActualiserDataGrid();
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show("Erro" + erro);
                            connexion.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show(" non connecté");
                        connexion.Close();
                    }
                }
            }
            else
            { // annulation après vérification
                MessageBox.Show("Suppression annulée", "Annulation", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void Button_Click_Modifier(object sender, RoutedEventArgs e)
        {
            if (listDataBiding_client.SelectedItem != null)
            {
                //récupération puis envoie du contexte a la frame de modification du site + envoie connection
                var sender_context = sender as System.Windows.Controls.Button;
                var context = sender_context.DataContext as TabStock_site;
                Contents_gestion_salarie.Content = new Page_modifier_site(context.Ville, context.Pays, context.Id, Connexion);
                Contents_gestion_salarie.Opacity = 100;
                Canvas.SetZIndex(Contents_gestion_salarie, 1);
            }
            else
            {
                MessageBox.Show("Veuillez choisir un fournisseur !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void Button_Click_Ajout(object sender, RoutedEventArgs e)
        {
            // envoie de la connection a la page d'ajout 
            Contents_gestion_salarie.Content = new Page_ajout_site(Connexion);
            Contents_gestion_salarie.Opacity = 100;
            Canvas.SetZIndex(Contents_gestion_salarie, 1);
        }
    }
}