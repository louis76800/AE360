using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace pb360.components.Administration.Gestion_salarie
{
    /// <summary>
    /// Logique d'interaction pour Page_gestion_salarie.xaml
    /// </summary>
    public partial class Page_gestion_salarie : Page
    {
        public string Id_delete { get; set; }
        public MySqlConnection Connexion { get; set; }

        public string Role_bdd { get; }
        public Page_gestion_salarie(string role_bdd, MySqlConnection connexion_new)
        {
            InitializeComponent();
            Role_bdd = role_bdd;
            Connexion = connexion_new;

            ActualiserDataGrid();





        }

        public class TabStock_accueil
        {
            public string Id { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Telfix { get; set; }
            public string Telport { get; set; }
            public string Email { get; set; }
            public string Service { get; set; }
            public string Ville { get; set; }
            public string Pays { get; set; }
            public override string ToString()
            {
                return this.Id + ";" + this.Nom + ";" + this.Prenom + ";" + this.Telfix + ";" + this.Telport + ";" + this.Email + ";" + this.Service + ";" + this.Ville + ";" + this.Pays;
            }
        }
        public void ActualiserDataGrid()
        {
            MySqlConnection connexion = Connexion;
            try
            {
                connexion.Open();
                MySqlCommand cmd = connexion.CreateCommand();
                cmd.CommandText = " SELECT id,nom,prenom,tel_fix,tel_portable,email,libelle_service,ville,pays FROM t_salarie INNER JOIN t_service ON id_service = service_id INNER JOIN t_site ON id_site = site_id ";
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<TabStock_accueil> Items = new List<TabStock_accueil>();

                    while (reader.Read())
                    {
                        var id = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                        var nom = reader.GetString(1); //The 1 stands for "the 1'th column", so the seconde column of the result.
                        var prenom = reader.GetString(2); //The 1 stands for "the 1'th column", so the seconde column of the result.
                        var telfix = reader.GetString(3); //The 1 stands for "the 1'th column", so the seconde column of the result.
                        var telport = reader.GetString(4); //The 1 stands for "the 1'th column", so the seconde column of the result.
                        var email = reader.GetString(5); //The 1 stands for "the 1'th column", so the seconde column of the result.
                        var service = reader.GetString(6); //The 1 stands for "the 1'th column", so the seconde column of the result.
                        var ville = reader.GetString(7); //The 1 stands for "the 1'th column", so the seconde column of the result.
                        var pays = reader.GetString(8); //The 1 stands for "the 1'th column", so the seconde column of the result.

                        Items.Add(new TabStock_accueil()
                        {
                            Id = id,
                            Nom = nom,
                            Prenom = prenom,
                            Telfix = "0" + telfix,
                            Telport = "0" + telport,
                            Email = email,
                            Service = service,
                            Ville = ville,
                            Pays = pays
                        });

                    }
                    connexion.Close();
                    listDataBiding_client.ItemsSource = Items;
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro" + erro);
                    connexion.Close();
                }
            }
            catch (Exception erro)
            {
                connexion.Close();

                MessageBox.Show(" non connecté");
                MessageBox.Show("" + erro);

            }
        }




        private void recherche_TextChanged(object sender, TextChangedEventArgs e)
        {


            if (recherche.Text.Length >= 4)
            {
                if (Regex.IsMatch(recherche.Text, "[^a-zA-Z0-9À-ȕ&._-]", RegexOptions.IgnoreCase))
                {
                    recherche.Text = "";
                    MessageBox.Show("Merci de ne saisir que lettre pour la recherche", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MySqlConnection connexion = Connexion;
                    try
                    {
                        connexion.Open();
                        MySqlCommand cmd = connexion.CreateCommand();
                        cmd.CommandText = " SELECT id,nom,prenom,tel_fix,tel_portable,email,libelle_service,ville,pays FROM t_salarie INNER JOIN t_service ON id_service = service_id INNER JOIN t_site ON id_site = site_id where " +
                            " nom like'%" + recherche.Text + "%' or nom like'%" + recherche.Text + "%' or prenom like'%" + recherche.Text + "%' or tel_fix like'%" + recherche.Text + "%' or tel_portable like'%" + recherche.Text + "%' or email like'%" + recherche.Text + "%' or libelle_service like'%" + recherche.Text + "%' or ville like'%" + recherche.Text + "%' or pays ";
                        try
                        {
                            MySqlDataReader reader = cmd.ExecuteReader();
                            List<TabStock_accueil> Items = new List<TabStock_accueil>();

                            while (reader.Read())
                            {
                                var id = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                                var nom = reader.GetString(1); //The 1 stands for "the 1'th column", so the seconde column of the result.
                                var prenom = reader.GetString(2); //The 1 stands for "the 1'th column", so the seconde column of the result.
                                var telfix = reader.GetString(3); //The 1 stands for "the 1'th column", so the seconde column of the result.
                                var telport = reader.GetString(4); //The 1 stands for "the 1'th column", so the seconde column of the result.
                                var email = reader.GetString(5); //The 1 stands for "the 1'th column", so the seconde column of the result.
                                var service = reader.GetString(6); //The 1 stands for "the 1'th column", so the seconde column of the result.
                                var ville = reader.GetString(7); //The 1 stands for "the 1'th column", so the seconde column of the result.
                                var pays = reader.GetString(8); //The 1 stands for "the 1'th column", so the seconde column of the result.

                                Items.Add(new TabStock_accueil()
                                {
                                    Id = id,
                                    Nom = nom,
                                    Prenom = prenom,
                                    Telfix = "0" + telfix,
                                    Telport = "0" + telport,
                                    Email = email,
                                    Service = service,
                                    Ville = ville,
                                    Pays = pays
                                });

                            }
                            connexion.Close();

                            listDataBiding_client.ItemsSource = Items;
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
                        MessageBox.Show(" non connecté");


                    }
                }
            }

            else if (recherche.Text.Length == 0)
            {
                MySqlConnection connexion = Connexion;
                try
                {
                    connexion.Open();
                    MySqlCommand cmd = connexion.CreateCommand();
                    cmd.CommandText = " SELECT id,nom,prenom,tel_fix,tel_portable,email,libelle_service,ville,pays FROM t_salarie INNER JOIN t_service ON id_service = service_id INNER JOIN t_site ON id_site = site_id where " +
                        " nom like'%" + recherche.Text + "%' or nom like'%" + recherche.Text + "%' or prenom like'%" + recherche.Text + "%' or tel_fix like'%" + recherche.Text + "%' or tel_portable like'%" + recherche.Text + "%' or email like'%" + recherche.Text + "%' or libelle_service like'%" + recherche.Text + "%' or ville like'%" + recherche.Text + "%' or pays ";
                    try
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        List<TabStock_accueil> Items = new List<TabStock_accueil>();

                        while (reader.Read())
                        {
                            var id = reader.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                            var nom = reader.GetString(1); //The 1 stands for "the 1'th column", so the seconde column of the result.
                            var prenom = reader.GetString(2); //The 1 stands for "the 1'th column", so the seconde column of the result.
                            var telfix = reader.GetString(3); //The 1 stands for "the 1'th column", so the seconde column of the result.
                            var telport = reader.GetString(4); //The 1 stands for "the 1'th column", so the seconde column of the result.
                            var email = reader.GetString(5); //The 1 stands for "the 1'th column", so the seconde column of the result.
                            var service = reader.GetString(6); //The 1 stands for "the 1'th column", so the seconde column of the result.
                            var ville = reader.GetString(7); //The 1 stands for "the 1'th column", so the seconde column of the result.
                            var pays = reader.GetString(8); //The 1 stands for "the 1'th column", so the seconde column of the result.

                            Items.Add(new TabStock_accueil()
                            {
                                Id = id,
                                Nom = nom,
                                Prenom = prenom,
                                Telfix = "0" + telfix,
                                Telport = "0" + telport,
                                Email = email,
                                Service = service,
                                Ville = ville,
                                Pays = pays
                            });

                        }
                        connexion.Close();

                        listDataBiding_client.ItemsSource = Items;
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
                    connexion.Close();
                }
            }
            }

            private void Button_Click_Supprimer(object sender, RoutedEventArgs e)
            {

                var sender_context = sender as System.Windows.Controls.Button;
                var context = sender_context.DataContext as TabStock_accueil;

                Id_delete = context.Id;
                var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ?", "Confirmer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                { //suppression après validation
                    MySqlConnection connexion = Connexion;
                    try
                    {
                        connexion.Open();
                        MySqlCommand cmd = connexion.CreateCommand();
                        cmd.CommandText = "DELETE FROM t_salarie where id ='" + Id_delete + "' ";
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
                    catch (Exception erro)
                    {
                        MessageBox.Show("Erro" + erro);
                        connexion.Close();
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

                    var sender_context = sender as System.Windows.Controls.Button;
                    var context = sender_context.DataContext as TabStock_accueil;

                    Contents_gestion_salarie.Content = new Page_modifier_salarie(context.Email, context.Nom, context.Prenom, context.Pays, context.Service, context.Telfix, context.Telport, context.Id, context.Ville, Connexion);
                    Contents_gestion_salarie.Opacity = 100;
                    Canvas.SetZIndex(Contents_gestion_salarie, 1);
                }
                else
                {
                    MessageBox.Show("Veuillez choisir un fournisseur !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
        }
    }