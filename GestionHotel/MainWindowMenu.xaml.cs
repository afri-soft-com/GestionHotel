using GestionHotel.Pages;
using GestionHotel.Windows;
using GestionHotel.Windows.Chambres;
using GestionHotel.Windows.Clients;
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

namespace GestionHotel
{
    /// <summary>
    /// Interaction logic for MainWindowMenu.xaml
    /// </summary>
    public partial class MainWindowMenu : Window
    {
        public MainWindowMenu()
        {
            InitializeComponent();
            Main.Content = new PageHome();
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
        }

        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void AjouterClient_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Main.Content = new AjouterClient();
            WindowAjouterClient windowAjouterClient = new WindowAjouterClient();
            windowAjouterClient.Show();
        }

        private void Dashboard_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Main.Content = new Dashboard();
            WindowDashboard windowDashboard = new WindowDashboard();
            windowDashboard.Show();
        }

        private void chambre_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowChambre windowChambre = new WindowChambre();
            windowChambre.Show();
        }

        private void ListeClient_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowClientsAffectes windowClientsAffectes = new WindowClientsAffectes();
            windowClientsAffectes.Show();
        }
    }
}
