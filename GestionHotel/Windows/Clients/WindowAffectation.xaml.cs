using ClassLibraryGestionHotel.Affectation;
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

namespace GestionHotel.Windows.Clients
{
    /// <summary>
    /// Interaction logic for WindowAffectation.xaml
    /// </summary>
    public partial class WindowAffectation : Window
    {
        double tarif_chambre;
        public WindowAffectation()
        {
            InitializeComponent();
            ChargerComboAffectationChambre();
        }

        public void ChargerComboAffectationChambre()
        {
            ChambreDataAccessLayer chambreDataAccessLayer = new ChambreDataAccessLayer();

            IEnumerable<ChambreModel> items = chambreDataAccessLayer.GetListeChambre();

            ObservableCollection<string> list_code_combo_chambre = new ObservableCollection<string>();
            ObservableCollection<string> list_designation_combo_chambre = new ObservableCollection<string>();

            foreach (ChambreModel item in items)
            {
                list_code_combo_chambre.Add(item.CodeChambre);
                list_designation_combo_chambre.Add(item.DesignationChambre);
            }

            code_chambre_combo.ItemsSource = list_code_combo_chambre;
            designation_chambre_combo.ItemsSource = list_designation_combo_chambre;
        }

        private void btnValiderAffectation_Click(object sender, RoutedEventArgs e)
        {
            SaveAffectation();
        }

        private void btnAnnulerAffectation_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void code_chambre_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            designation_chambre_combo.SelectedIndex = code_chambre_combo.SelectedIndex;

            ChambreDataAccessLayer chambreDataAccessLayer = new ChambreDataAccessLayer();

            IEnumerable<ChambreModel> items = chambreDataAccessLayer.GetTarifChambre(code_chambre_combo.SelectedItem.ToString());

           

            foreach (ChambreModel item in items)
            {
                display_tarif_chambre.Text = item.TarifChambre.ToString();
            }

        }

        private void designation_chambre_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            code_chambre_combo.SelectedIndex = designation_chambre_combo.SelectedIndex;
        }

        public void SaveAffectation()
        {
            AffectationDataAccessLayer clientDataAccessLayer = new AffectationDataAccessLayer();
            AffectationModel affectationModel = new AffectationModel();


            affectationModel.CodeClient = txt_displayCodeClient.Text;
            affectationModel.CodeChambre = code_chambre_combo.SelectedItem.ToString();
            affectationModel.TarifChambre = double.Parse(display_tarif_chambre.Text);

            int insertion = clientDataAccessLayer.SaveAffecterClient(affectationModel);

            if (insertion == 1)
            {
                MessageBox.Show("Client affecté avec succès");

            }
            else
            {
                MessageBox.Show("Echec d'affectation");
            }
        }
    }
}
