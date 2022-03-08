using MySql.Data.MySqlClient;
using pb360.components.Administration.Gestion_salarie;
using pb360.components.Administration.Gestion_service;
using pb360.components.Administration.Gestion_site;
using pb360.components.Inscription;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace pb360.components.acceuil
{
    /// <summary>
    /// Logique d'interaction pour Page_accueil.xaml
    /// </summary>
    public partial class Page_accueil : Page
    {
        public string Role_bdd { get; }
        public string Id_site { get; set; }
        public string Id_service { get; set; }
        public string Recherche { get; set; }
        public MySqlConnection connexion { get; set; }

        public Page_accueil(string role_bdd, MySqlConnection connexion_new)
        {
            InitializeComponent();
            retour.Opacity = 0;
            Role_bdd = role_bdd;
            if (Role_bdd == "VISITEUR")
            {
                onglet.Opacity = 0;

                onglet_admin.IsEnabled = false;
                onglet_admin.IsHitTestVisible = false;
                onglet.IsHitTestVisible = false;
            }
            connexion = connexion_new;
            ActualiserDataGrid();

            //  onglet.Opacity = 0;

            if (Role_bdd == "ADMINISTRATEUR")
            {
                onglet.Opacity = 100;
            }
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
            try
            {
                connexion.Open();
                MySqlCommand cmd = connexion.CreateCommand();
                cmd.CommandText = " SELECT id,nom,prenom,tel_fix,tel_portable,email,libelle_service,ville,pays FROM t_salarie INNER JOIN t_service ON id_service = service_id INNER JOIN t_site ON id_site = site_id where " +
                    "( nom like'%" + recherche.Text + "%' or nom like'%" + recherche.Text + "%' or prenom like'%" + recherche.Text + "%' or tel_fix like'%" + recherche.Text + "%' or tel_portable like'%" + recherche.Text + "%' or email like'%" + recherche.Text + "%' or libelle_service like'%" + recherche.Text + "%' or ville like'%" + recherche.Text + "%' or pays )";
                if (Id_service == null)
                {
                }
                else
                    cmd.CommandText = cmd.CommandText + " and id_service ='" + Id_service + "'";

                if (Id_site == null)
                {
                }
                else
                    cmd.CommandText = cmd.CommandText + " and id_site ='" + Id_site + "'";
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

        private void Button_Click_salarie(object sender, RoutedEventArgs e)
        {
            Contents_accueil.Content = new Page_gestion_salarie(Role_bdd, connexion);
            Canvas.SetZIndex(Contents_accueil, 1);
            retour.Opacity = 100;
        }
        private void Button_Click_site(object sender, RoutedEventArgs e)
        {
            Contents_accueil.Content = new Page_gestion_site(Role_bdd, connexion);
            Canvas.SetZIndex(Contents_accueil, 1);
            retour.Opacity = 100;
        }
        private void Button_Click_service(object sender, RoutedEventArgs e)
        {
            Contents_accueil.Content = new Page_gestion_service(Role_bdd, connexion);
            Canvas.SetZIndex(Contents_accueil, 1);
            retour.Opacity = 100;
        }
        private void Button_Click_retour(object sender, RoutedEventArgs e)
        {
            Canvas.SetZIndex(Contents_accueil, -1);
            retour.Opacity = 0;
            connexion.Close();
            ActualiserDataGrid();
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
                    Recherche = recherche.Text;
                    ActualiserDataGrid();

                }
            }
            else if (recherche.Text.Length == 0)
            {
                    Recherche = null;
                    ActualiserDataGrid();
            }
        }

        private void Button_Click_choix_site(object sender, RoutedEventArgs e)
        {
            var win = new Window_choix_site();
            var result = win.ShowDialog();
            if (result == true)
            {

                site.Content = win.Site;
                Id_site = win.Id_site;

            }
            ActualiserDataGrid();

        }

        private void Button_Click_choix_service(object sender, RoutedEventArgs e)
        {
            var win = new Window_choix_service();
            var result = win.ShowDialog();
            if (result == true)
            {
                service.Content = win.Service;
                Id_service = win.Id_service;
            }
            ActualiserDataGrid();


        }
        private void Button_Click_reinitialiser(object sender, RoutedEventArgs e)
        {

            service.Content = "Choix service";
            site.Content = "Choix site";
            Id_service = null;
            Id_site = null;
            recherche.Text = "";
            ActualiserDataGrid();


        }

    }
}