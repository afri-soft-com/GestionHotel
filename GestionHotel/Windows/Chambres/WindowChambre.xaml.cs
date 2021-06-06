using ClassLibraryGestionHotel.Chambres;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionHotel.Windows.Chambres
{
    /// <summary>
    /// Interaction logic for WindowChambre.xaml
    /// </summary>
    public partial class WindowChambre : Window
    {
        IEnumerable<ChambreModel> liste_chambres;

        public WindowChambre()
        {
            InitializeComponent();
            ChargerComboCategorieChambre();
            ChargerListeDesChambres();
        }

        public void EnregistrerChambre()
        {
            ChambreDataAccessLayer chambreDataAccess = new ChambreDataAccessLayer();
            ChambreModel chambreModel = new ChambreModel();

            chambreModel.DesignationChambre = DesignationChambre_txt.Text;
            chambreModel.CategorieChambre = categorie_chambre_combo.SelectedItem.ToString();
            chambreModel.TarifChambre = Convert.ToDouble(TarifChambre_txt.Text);

            int insertion = chambreDataAccess.SaveChambre(chambreModel);

            if (insertion == 1)
            {
                MessageBox.Show("Enregistrement effectué avec succès");

                DesignationChambre_txt.Text = "";
                TarifChambre_txt.Text = "";

            }
            else
            {
                MessageBox.Show("Echec d'enregistrement");
            }
        }

        public void ChargerListeDesChambres()
        {
            ChambreDataAccessLayer chambreDataAccessLayer = new ChambreDataAccessLayer();
            liste_chambres = chambreDataAccessLayer.GetListeChambre();
            listeview_chambres.ItemsSource = liste_chambres;
            listeview_chambres.Items.Refresh();

        }

        public void ChargerComboCategorieChambre()
        {
            CategorieChambreDataAccessLayer categorieChambreDataAccessLayer = new CategorieChambreDataAccessLayer();

            IEnumerable<CategorieChambreModel> items = categorieChambreDataAccessLayer.GetListeCategorieChambre();

            ObservableCollection<string> list_combo_categorie_chambre = new ObservableCollection<string>();

            foreach (CategorieChambreModel item in items)
            {
                list_combo_categorie_chambre.Add(item.DesignationCategorieChambre);
            }

            categorie_chambre_combo.ItemsSource = list_combo_categorie_chambre;
        }

        private void fermer_chambres_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void categorie_chambre_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEnregistrer_chambre_Click(object sender, RoutedEventArgs e)
        {
            EnregistrerChambre();
        }
    }
}
