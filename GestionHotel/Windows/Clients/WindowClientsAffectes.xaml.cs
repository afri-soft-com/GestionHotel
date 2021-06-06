using ClassLibraryGestionHotel.Affectation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionHotel.Windows.Clients
{
    /// <summary>
    /// Interaction logic for WindowClientsAffectes.xaml
    /// </summary>
    public partial class WindowClientsAffectes : Window
    {
        IEnumerable<AffectationModel> liste_clients_affectes;
        public WindowClientsAffectes()
        {
            InitializeComponent();
            ChargerClientsAffectes();
        }

        public void ChargerClientsAffectes()
        {
            AffectationDataAccessLayer affectationDataAccessLayer = new AffectationDataAccessLayer();
            liste_clients_affectes = affectationDataAccessLayer.GetListeAffectation();
            listeview_clients_affectes.ItemsSource = liste_clients_affectes;
            listeview_clients_affectes.Items.Refresh();
        }
        //les anges

        private void fermerWindowclientaffectes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
