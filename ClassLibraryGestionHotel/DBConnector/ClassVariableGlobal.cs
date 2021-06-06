using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryGestionHotel.DBConnector
{
    public class ClassVariableGlobal
    {
        public static string connectionString;

        public static string SetConnection()
        {
            connectionString = "Data Source = 127.0.0.1; Initial Catalog = BaseGestionHotel; User Id = USHINDI; Password = Usher097";

            return connectionString;
        }
    }
}
