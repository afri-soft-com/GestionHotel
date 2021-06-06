using ClassLibraryGestionHotel.DBConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClassLibraryGestionHotel.Clients
{
    public class ClientDataAccessLayer
    {
        // Saving the client data

        public int SaveClient(ClientModel clientModel)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))
            {
                connection.Open();

                string requette = "INSERT INTO tClient"+
                         "(CodeClient, NomClient, PostnomClient, PrenomClient, TelephoneClient, EmailClient, CompteClient)"+
                         "VALUES(@CodeClient, @NomClient, @PostnomClient, @PrenomClient, @TelephoneClient, @EmailClient, @CompteClient)";

                SqlCommand commande = new SqlCommand(requette, connection);

                string dernierCodeClient = "CL"+GetDernierCodeClient();

                commande.Parameters.AddWithValue("@CodeClient", dernierCodeClient);
                commande.Parameters.AddWithValue("@NomClient", clientModel.NomClient);
                commande.Parameters.AddWithValue("@PostnomClient", clientModel.PostnomClient);
                commande.Parameters.AddWithValue("@PrenomClient", clientModel.PrenomClient);
                commande.Parameters.AddWithValue("@TelephoneClient", clientModel.TelephoneClient);
                commande.Parameters.AddWithValue("@EmailClient", clientModel.EmailClient);
                commande.Parameters.AddWithValue("@CompteClient", clientModel.CompteClient);

                return commande.ExecuteNonQuery();
            }
        }

        //Liste des clients

        public List<ClientModel> GetListeClient()
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();
                    List<ClientModel> _listeClient = new List<ClientModel>();

                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();


                    string requette = "SELECT  * FROM tClient";

                    SqlCommand objCommand = new SqlCommand(requette, connection);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ClientModel objCust = new ClientModel();

                        objCust.IdClient = Convert.ToInt32(_Reader["IdClient"].ToString());
                        objCust.CodeClient = _Reader["CodeClient"].ToString();
                        objCust.NomClient = _Reader["NomClient"].ToString();
                        objCust.PostnomClient = _Reader["PostnomClient"].ToString();
                        objCust.PrenomClient = (_Reader["PrenomClient"].ToString());
                        objCust.TelephoneClient = (_Reader["TelephoneClient"].ToString());
                        objCust.EmailClient = (_Reader["EmailClient"].ToString());

                        _listeClient.Add(objCust);
                    }

                    return _listeClient;
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

        //Get dernier code client

        public int GetDernierCodeClient()
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnection()))

                try
                {
                    connection.Open();


                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();

                    string s = "SELECT MAX(IdClient) AS maxIDClient FROM tClient ";
                    SqlCommand objCommand = new SqlCommand(s, connection);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    int dernier = 0;
                    while (_Reader.Read())
                    {
                        dernier = Convert.ToInt32(_Reader["maxIDClient"]);

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
