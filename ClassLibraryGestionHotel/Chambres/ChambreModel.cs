using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryGestionHotel.Chambres
{
    public class ChambreModel
    {
        public int IdChambre { get; set; }
        public string CodeChambre { get; set; }
        public string DesignationChambre { get; set; }
        public string CategorieChambre { get; set; }
        public double TarifChambre { get; set; }
    }
}
