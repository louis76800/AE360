using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
namespace pb360.components.Administration.Gestion_service
{
    public partial class Page_gestion_service : Page
    {
        public string Id_delete { get; set; }
        public string Count_delete { get; set; }
        public string Role_bdd { get; }
        public MySqlConnection Connexion { get; set; }
        public Page_gestion_service(string role_bdd, MySqlConnection connexion_new)
        {
            InitializeComponent();
            Role_bdd = role_bdd;
            Connexion = connexion_new;
            ActualiserDataGrid();
        }
        public class TabStock_service
        {
            public string Id { get; set; }
            public string Service { get; set; }
            public override string ToString()
            {
                return this.Id + ";" + this.Service;
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
                cmd.CommandText = " SELECT id_service,libelle_service FROM t_service  ";
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //execution de la requete
                    List<TabStock_service> Items = new List<TabStock_service>();
                    while (reader.Read())
                    {
                        var id = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                        var service = reader.GetString(1); //The 1 stands for "the 1'th column", so the seconde column of the result.
                        Items.Add(new TabStock_service()
                        {
                            Id = id,
                            Service = service
                        }); ;
                    }
                    //affichage dans la liste
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
            }
        }
        private void recherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (recherche.Text.Length >= 4)
            {

                MySqlConnection connexion = Connexion;
                try
                {
                    if (Regex.IsMatch(recherche.Text, "[^a-zA-Z0-9À-ȕ&._-]", RegexOptions.IgnoreCase))
                    {
                        recherche.Text = "";
                        MessageBox.Show("Merci de ne saisir que lettre pour la recherche", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        connexion.Open();
                        MySqlCommand cmd = connexion.CreateCommand();
                        cmd.CommandText = "  SELECT id_service,libelle_service FROM t_service where libelle_service like'%" + recherche.Text + "%' ";
                        try
                        {
                            MySqlDataReader reader = cmd.ExecuteReader();
                            List<TabStock_service> Items = new List<TabStock_service>();
                            while (reader.Read())
                            {
                                var id = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                                var service = reader.GetString(1); //The 1 stands for "the 1'th column", so the seconde column of the result.
                                Items.Add(new TabStock_service()
                                {
                                    Id = id,
                                    Service = service
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
                }
                catch
                {
                    MessageBox.Show(" non connecté");
                }
            }
            else if (recherche.Text.Length == 0)
            {
                MySqlConnection connexion = Connexion;
                try
                {
                    connexion.Open();
                    MySqlCommand cmd = connexion.CreateCommand();
                    cmd.CommandText = " SELECT id_service,libelle_service FROM t_service  ";
                    try
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        List<TabStock_service> Items = new List<TabStock_service>();
                        while (reader.Read())
                        {
                            var id = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                            var service = reader.GetString(1); //The 1 stands for "the 1'th column", so the seconde column of the result.
                            Items.Add(new TabStock_service()
                            {
                                Id = id,
                                Service = service
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
        private void Button_Click_Supprimer(object sender, RoutedEventArgs e)
        {

            var sender_context = sender as System.Windows.Controls.Button;
            var context = sender_context.DataContext as TabStock_service;

            Id_delete = context.Id;
            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ?", "Confirmer", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            { //suppression après validation

                MySqlConnection connexion = Connexion;

                try
                {
                    connexion.Open();
                    //requete qui compte le nombre de salarié dans le service 
                    MySqlCommand cmd = connexion.CreateCommand();
                    cmd.CommandText = " SELECT COUNT(*) AS count_service FROM t_service INNER JOIN t_salarie ON service_id = id_service WHERE service_id = '" + context.Id + "'  ";
                    try
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        List<TabStock> Items = new List<TabStock>();

                        while (reader.Read())
                        {
                            var count_service = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.

                            Items.Add(new TabStock()
                            {
                                Count = count_service
                            });
                            Count_delete = count_service;
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
                //modification dans le cas ou count != 0 et suppression si c'est egal a 0
                if (Count_delete != "0")
                {
                    try
                    {
                        connexion.Open();
                        MySqlCommand cmd = connexion.CreateCommand();
                        cmd.CommandText = "update t_service set libelle_service = 'Supprimé (anciennement " + context.Service + ")' where id_service ='" + Id_delete + "' ";
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
                else
                {
                    try
                    {
                        connexion.Open();
                        MySqlCommand cmd = connexion.CreateCommand();
                        cmd.CommandText = "DELETE FROM t_service WHERE id_service ='" + Id_delete + "' ";
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
                //récupération du context
                var sender_context = sender as System.Windows.Controls.Button;
                var context = sender_context.DataContext as TabStock_service;
                //envoie du context et de la connection dans la page modifier service
                Contents_gestion_salarie.Content = new Page_modifier_service(context.Service, context.Id, Connexion);

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
            //affichage de la frame d'ajout de service
            Contents_gestion_salarie.Content = new Page_ajout_service(Connexion);
            Contents_gestion_salarie.Opacity = 100;
            Canvas.SetZIndex(Contents_gestion_salarie, 1);
        }
    }
}