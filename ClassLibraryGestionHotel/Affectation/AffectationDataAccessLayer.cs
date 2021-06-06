using ClassLibraryGestionHotel.DBConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibraryGestionHotel.Affectation
{
    public class AffectationDataAccessLayer
    {
        // Enregistrer affectation 

        public int SaveAffecterClient(AffectationModel affectationModel)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))
            {
                connection.Open();
                string numAffectation;
                string requette = "INSERT INTO tAffectation"+
                         "(NumAffectation, DateAffectation, EtatAffectation, CodeClient, CodeChambre, TarifChambre)"+
                          "VALUES(@NumAffectation, @DateAffectation, @EtatAffectation, @CodeClient, @CodeChambre, @TarifChambre)";

                SqlCommand commande = new SqlCommand(requette, connection);

                numAffectation = "AFFEC" + GetDerniereAffectation();

                commande.Parameters.AddWithValue("@NumAffectation", numAffectation);
                commande.Parameters.AddWithValue("@DateAffectation",DateTime.UtcNow.ToString());
                commande.Parameters.AddWithValue("@EtatAffectation", "1");
                commande.Parameters.AddWithValue("@CodeClient", affectationModel.CodeClient);
                commande.Parameters.AddWithValue("@CodeChambre", affectationModel.CodeChambre);
                commande.Parameters.AddWithValue("@TarifChambre", affectationModel.TarifChambre);

                return commande.ExecuteNonQuery();
            }
        }


        //Get liste affectation

        public List<AffectationModel> GetListeAffectation()
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();
                    List<AffectationModel> _listeChambre = new List<AffectationModel>();

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();


                    string requette = "SELECT  * FROM tAffectation";

                    SqlCommand objCommand = new SqlCommand(requette, connection);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        AffectationModel objCust = new AffectationModel();

                        objCust.IdAffectation = Convert.ToInt32(_Reader["IdAffectation"].ToString());
                        objCust.NumAffectation = _Reader["NumAffectation"].ToString();
                        objCust.DateAffectation = Convert.ToDateTime(_Reader["DateAffectation"].ToString());
                        objCust.EtatAffectation = _Reader["EtatAffectation"].ToString();
                        objCust.CodeClient = _Reader["CodeClient"].ToString();
                        objCust.CodeChambre = (_Reader["CodeChambre"].ToString());
                        objCust.TarifChambre = Convert.ToDouble(_Reader["TarifChambre"].ToString());

                        _listeChambre.Add(objCust);
                    }

                    return _listeChambre;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            connection.Dispose();
                        }
                    }
                }

        }


        //Get dernire affectation 

        public int GetDerniereAffectation()
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();


                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();

                    string s = "SELECT MAX(IdAffectation) AS maxIDAffectation FROM tAffectation ";
                    SqlCommand objCommand = new SqlCommand(s, connection);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    int dernier = 0;
                    while (_Reader.Read())
                    {
                        AffectationDataAccessLayer dataAccessLayer = new AffectationDataAccessLayer();
                        dernier = Convert.ToInt32(_Reader["maxIDAffectation"]);

                    }

                    return dernier + 1;
                }
                catch
                {
                    return 1;
                }
                finally
                {
                    if (connection != null)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            connection.Dispose();
                        }
                    }

                }
        }
    }
}
