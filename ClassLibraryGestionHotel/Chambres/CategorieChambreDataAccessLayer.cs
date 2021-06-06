using ClassLibraryGestionHotel.DBConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibraryGestionHotel.Chambres
{
    public class CategorieChambreDataAccessLayer
    {

        // Select les categories des chambres

        public List<CategorieChambreModel> GetListeCategorieChambre()
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();
                    List<CategorieChambreModel> _listecategorieChambre = new List<CategorieChambreModel>();

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();


                    string requette = "SELECT  * FROM tCategorieChambre";

                    SqlCommand objCommand = new SqlCommand(requette, connection);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        CategorieChambreModel objCust = new CategorieChambreModel();

                        objCust.IdCategorieChambre = Convert.ToInt32(_Reader["IdCategorieChambre"].ToString());
                        objCust.DesignationCategorieChambre = _Reader["DesignationCategorieChambre"].ToString();

                        _listecategorieChambre.Add(objCust);
                    }

                    return _listecategorieChambre;
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
