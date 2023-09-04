using System;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectLogic.DAL
{
    public class DbSqlConnetion
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["connDb"].ConnectionString);
        }
        public bool ValidateRowsAffected(int rowsAffected)
        {
            if (rowsAffected > 0)
            {
                return true; // Operación exitosa
            }
            else
            {
                return false; // Operación sin éxito (no afectó filas)
            }
        }

        public void FinallyConnection(SqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
      
    }
}
