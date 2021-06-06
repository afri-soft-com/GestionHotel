using ClassLibraryGestionHotel.DBConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibraryGestionHotel.Chambres
{
    public class ChambreDataAccessLayer
    {
        // Methode pour save les chambres

        public int SaveChambre(ChambreModel chambreModel)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))
            {
                connection.Open();

                string requette = "INSERT INTO tChambre"+
                                    "(CodeChambre, DesignationChambre, CategorieChambre, TarifChambre)"+
                                    "VALUES(@CodeChambre, @DesignationChambre, @CategorieChambre, @TarifChambre)";

                SqlCommand commande = new SqlCommand( requette, connection);

                string dernierCodeChambre = "CH"+GetDernierCodeChambre();

                commande.Parameters.AddWithValue("@CodeChambre", dernierCodeChambre);
                commande.Parameters.AddWithValue("@DesignationChambre", chambreModel.DesignationChambre);
                commande.Parameters.AddWithValue("@CategorieChambre", chambreModel.CategorieChambre);
                commande.Parameters.AddWithValue("@TarifChambre", chambreModel.TarifChambre);

                return commande.ExecuteNonQuery();
            }
        }

        //Select les chambres

        public List<ChambreModel> GetListeChambre()
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();
                    List<ChambreModel> _listeChambre = new List<ChambreModel>();

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();


                    string requette = "SELECT  * FROM tChambre";

                    SqlCommand objCommand = new SqlCommand(requette, connection);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ChambreModel objCust = new ChambreModel();

                        objCust.IdChambre = Convert.ToInt32(_Reader["IdChambre"].ToString());
                        objCust.CodeChambre = _Reader["CodeChambre"].ToString();
                        objCust.DesignationChambre = _Reader["DesignationChambre"].ToString();
                        objCust.CategorieChambre = _Reader["CategorieChambre"].ToString();
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

        // Selection derniere chambre

        public int GetDernierCodeChambre()
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();


                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();

                    string s = "SELECT MAX(IdChambre) AS maxIDChambre FROM tChambre ";
                    SqlCommand objCommand = new SqlCommand(s, connection);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    int dernier = 0;
                    while (_Reader.Read())
                    {
                        ChambreDataAccessLayer dataAccessLayer = new ChambreDataAccessLayer();
                        dernier = Convert.ToInt32(_Reader["maxIDChambre"]);

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

        // Select tarif where CodeChambre=?

        public List<ChambreModel> GetTarifChambre( string codeChambre)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();
                    List<ChambreModel> _listeChambre = new List<ChambreModel>();

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();


                    string requette = "SELECT TarifChambre FROM tChambre where (CodeChambre = @codeChambre)";

                    SqlCommand objCommand = new SqlCommand(requette, connection);

                    objCommand.Parameters.AddWithValue("@codeChambre", codeChambre);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ChambreModel objCust = new ChambreModel();

                       
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
    }
}
