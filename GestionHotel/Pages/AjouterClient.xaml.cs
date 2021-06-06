using ClassLibraryGestionHotel.Clients;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionHotel.Pages
{
    /// <summary>
    /// Interaction logic for AjouterClient.xaml
    /// </summary>
    public partial class AjouterClient : Page
    {
        public AjouterClient()
        {
            InitializeComponent();
        }

        //public void EnregistrerCLient()
        //{ 
        //    ClientDataAccessLayer clientDataAccessLayer = new ClientDataAccessLayer();
        //    ClientModel clientModel = new ClientModel();

        //    clientModel.NomClient = NomClient_txt.Text;
        //    clientModel.PostnomClient = PostnomClient_txt.Text;
        //    clientModel.PrenomClient = PrenomClient_txt.Text;
        //    clientModel.TelephoneClient = TelephoneClient_txt.Text;
        //    clientModel.EmailClient = EmailClient_txt.Text;
        //    clientModel.CompteClient = "compte";

        //    int insertion = clientDataAccessLayer.SaveClient(clientModel);

        //    if (insertion == 1)
        //    {
        //        MessageBox.Show("Client enregistré avec succès");

        //        NomClient_txt.Text = "";
        //        PostnomClient_txt.Text = "";
        //        PrenomClient_txt.Text = "";
        //        TelephoneClient_txt.Text = "";
        //        EmailClient_txt.Text = "";

        //    }
        //    else
        //    {
        //        MessageBox.Show("Echec d'enregistrement");
        //    }
        //}

        private void Berengistrement_Click(object sender, RoutedEventArgs e)
        {

        }

        private void enregistrer_client_Click(object sender, RoutedEventArgs e)
        {
            //EnregistrerCLient();
        }
    }
}
