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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionHotel.Pages
{
    /// <summary>
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Page
    {
        public AddRoom()
        {
            InitializeComponent();
        }

        //public void EnregistrerChambre()
        //{
        //    ChambreDataAccessLayer chambreDataAccess = new ChambreDataAccessLayer();
        //    ChambreModel chambreModel = new ChambreModel();

        //    chambreModel.DesignationChambre = DesignationChambre_txt.Text;
        //    chambreModel.CategorieChambre = CategorieChambre_txt.Text;
        //    chambreModel.TarifChambre = Convert.ToDouble(TarifChambre_txt.Text);

        //    int insertion = chambreDataAccess.SaveChambre(chambreModel);

        //    if (insertion == 1)
        //    {
        //        MessageBox.Show("Enregistrement effectué avec succès");

        //        DesignationChambre_txt.Text = "";
        //        CategorieChambre_txt.Text = "";
        //        TarifChambre_txt.Text = "";
                
        //    }
        //    else
        //    {
        //        MessageBox.Show("Echec d'enregistrement");
        //    }
        //}

        private void btnEnregistrer_chambre_Click(object sender, RoutedEventArgs e)
        {
            //EnregistrerChambre();
        }


        private void categorie_chambre_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
    }
}
