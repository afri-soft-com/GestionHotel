using ClassLibraryGestionHotel.Clients;
using GestionHotel.Windows.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionHotel.Windows
{
    /// <summary>
    /// Interaction logic for WindowAjouterClient.xaml
    /// </summary>
    public partial class WindowAjouterClient : Window
    {
        int position = -1;
        string code_client = "";
        IEnumerable<ClientModel> liste_clients;
        public WindowAjouterClient()
        {
            InitializeComponent();
            ChargerListeDesClients();
        }


        public void EnregistrerCLient()
        {
            ClientDataAccessLayer clientDataAccessLayer = new ClientDataAccessLayer();
            ClientModel clientModel = new ClientModel();

            clientModel.NomClient = NomClient_txt.Text;
            clientModel.PostnomClient = PostnomClient_txt.Text;
            clientModel.PrenomClient = PrenomClient_txt.Text;
            clientModel.TelephoneClient = TelephoneClient_txt.Text;
            clientModel.EmailClient = EmailClient_txt.Text;
            clientModel.CompteClient = "compte";

            int insertion = clientDataAccessLayer.SaveClient(clientModel);

            if (insertion == 1)
            {
                MessageBox.Show("Client enregistré avec succès");

                NomClient_txt.Text = "";
                PostnomClient_txt.Text = "";
                PrenomClient_txt.Text = "";
                TelephoneClient_txt.Text = "";
                EmailClient_txt.Text = "";

            }
            else
            {
                MessageBox.Show("Echec d'enregistrement");
            }
        }

        public void ChargerListeDesClients()
        {
            ClientDataAccessLayer chambreDataAccessLayer = new ClientDataAccessLayer();
            liste_clients = chambreDataAccessLayer.GetListeClient();
            listeview_clients.ItemsSource = liste_clients;
            listeview_clients.Items.Refresh();

        }

        private void enregistrer_client_Click(object sender, RoutedEventArgs e)
        {
            EnregistrerCLient();
        }

        private void fermerWindowClient_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listeview_clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (listeview_clients.SelectedItems.Count > 0)
            {
                position = listeview_clients.Items.IndexOf(listeview_clients.SelectedItems[0]);

                ClientModel client_selectionne = liste_clients.ToList()[position];

                code_client = client_selectionne.CodeClient;
            }

            WindowAffectation windowAffectation = new WindowAffectation();
            windowAffectation.txt_displayCodeClient.Text = code_client;
            windowAffectation.Show();
        }
    }
}
