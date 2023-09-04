using System.Data;
using System;
using System.Data.SqlClient;
using ProjectLogic.BLL.Entities;

namespace ProjectLogic.DAL
{
    public class UsersDAL
    {
        private SqlConnection _connection;
        private readonly DbSqlConnetion _context;
        public UsersDAL(DbSqlConnetion context)
        {
            _context = context;
            _connection = context.GetConnection();
        }

        public dtUsers Login(dtUsers user)
        {
            SqlCommand command = new SqlCommand("sp_LoginUser", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Pass", user.Pass);

            return GetUsers(command);
        }

        public dtUsers GetUsers(SqlCommand command)
        {
            dtUsers Usuario = new dtUsers();
            try
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Usuario = new dtUsers
                    {
                        Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        UserName = reader.IsDBNull(1) ? "" : reader.GetString(1),
                        LastName = reader.IsDBNull(2) ? "" : reader.GetString(2),
                        Telephone = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        Pass = reader.IsDBNull(5) ? "" : reader.GetString(5),
                        Status = reader.IsDBNull(6) ? false : reader.GetBoolean(6),
                    };
                }
                return Usuario;
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar consultar con la base de datos obteniendo usuario");
            }
            catch (Exception)
            {
                throw new Exception("Error obteniendo usuario");
            }
            finally
            {
                _context.FinallyConnection(_connection);
            }
        }

        public bool AddUser(dtUsers user)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("sp_CreateUser", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Telephone", user.Telephone);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Pass", user.Pass);
                command.Parameters.AddWithValue("@Status", true);
                command.Parameters.AddWithValue("@CreationDate", DateTime.Now);

                int rowsAffected = command.ExecuteNonQuery();

                return _context.ValidateRowsAffected(rowsAffected);
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar consultar con la base de datos agregar usuario");
            }
            catch (Exception)
            {
                throw new Exception("Error agreagar usuario");
            }
            finally
            {
                _context.FinallyConnection(_connection);
            }
        }
        public bool UpdateUser(dtUsers user)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("sp_UpdateUser", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Telephone", user.Telephone);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@UpdateCreation", DateTime.Now);

                int rowsAffected = command.ExecuteNonQuery();

                return _context.ValidateRowsAffected(rowsAffected);
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar consultar con la base de datos actualizar usuario");
            }
            catch (Exception)
            {
                throw new Exception("Error agreagar usuario");
            }
            finally
            {
                _context.FinallyConnection(_connection);
            }
        }
    }
}
