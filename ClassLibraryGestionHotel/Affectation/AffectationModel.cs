using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryGestionHotel.Affectation
{
    public class AffectationModel
    {
        public int IdAffectation { get; set; }
        public string NumAffectation { get; set; }
        public DateTime DateAffectation { get; set; }
        public string EtatAffectation { get; set; }
        public string CodeClient { get; set; }
        public string CodeChambre { get; set; }
        public double TarifChambre { get; set; }
    }
}
