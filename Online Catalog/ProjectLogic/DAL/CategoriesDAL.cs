using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ProjectLogic.BLL.Entities;

namespace ProjectLogic.DAL
{
    public class CategoriesDAL
    {
        private SqlConnection _connection;
        private readonly DbSqlConnetion _context;
        public CategoriesDAL(DbSqlConnetion context)
        {
            _context = context;
            _connection = context.GetConnection();
        }

        public List<dtCategories> GetCategories()
        {
            SqlCommand command = new SqlCommand("sp_GetCategories", _connection);
            command.CommandType = CommandType.StoredProcedure;

            return ReturnsCategories(command);
        }
        public dtCategories GetCategoriesByID(int categoryId)
        {
            SqlCommand command = new SqlCommand("sp_GetCategoriesByID", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", categoryId);

            return ReturnsCategories(command)[0];
        }
        public List<dtCategories> ReturnsCategories(SqlCommand command)
        {
            List<dtCategories> listado = new List<dtCategories>();
            try
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listado.Add(new dtCategories()
                    {
                        Id = reader.GetInt32(0),
                        CategoryCode = reader.GetString(1),
                        CategoryName = reader.GetString(2),
                        Descriptions = reader.GetString(3),
                        Author = reader.GetString(4),
                        CreationDate = reader.IsDBNull(5) ? "" : reader.GetDateTime(5).ToString("dd/MM/yyyy"),
                        UpdateDate = reader.IsDBNull(6) ? "" : reader.GetDateTime(6).ToString("dd/MM/yyyy"),
                    });
                }
                reader.Close();

                return listado;
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar consultar con la base de datos");
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar listar categorias.."); ;
            }
            finally
            {
                _context.FinallyConnection(_connection);
            }
        }

        public bool AddCategories(dtCategories category)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("sp_AddCategory", _connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryCode", category.CategoryCode);
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                command.Parameters.AddWithValue("@Descriptions", category.Descriptions);
                command.Parameters.AddWithValue("@Status", category.Status);
                command.Parameters.AddWithValue("@Author", category.Author);
                command.Parameters.AddWithValue("@CreationDate", DateTime.Now);

                int rowsAffected = command.ExecuteNonQuery();

                return _context.ValidateRowsAffected(rowsAffected);
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar consultar con la base de datos agregar categorias");
            }
            catch (Exception)
            {
                throw new Exception("Error agregar categorias");
            }
            finally
            {
                _context.FinallyConnection(_connection);
            }
        }

        public bool UpdateCategories(dtCategories category)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("sp_UpdateCategory", _connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", category.Id);
                command.Parameters.AddWithValue("@CategoryCode", category.CategoryCode);
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                command.Parameters.AddWithValue("@Descriptions", category.Descriptions);
                command.Parameters.AddWithValue("@Status", category.Status);
                command.Parameters.AddWithValue("@Author", category.Author);
                command.Parameters.AddWithValue("@UpdateDate", DateTime.Now);

                int rowsAffected = command.ExecuteNonQuery();

                return _context.ValidateRowsAffected(rowsAffected);
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar consultar con la base de datos actualizar categorias");
            }
            catch (Exception)
            {
                throw new Exception("Error actualizar categorias");
            }
            finally
            {
                _context.FinallyConnection(_connection);
            }
        }

        public bool DeleteCategories(int categoryId)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("sp_DeleteCategory", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", categoryId);

                SqlParameter productExistsParameter = new SqlParameter("@productexists", SqlDbType.Bit);
                productExistsParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(productExistsParameter);

                int rowsAffected = command.ExecuteNonQuery();
                if (_context.ValidateRowsAffected(rowsAffected) == false)
                {
                    throw new Exception("Error al hacer la consulta a la base de datos");
                }

                bool productExists = (bool)command.Parameters["@productexists"].Value;

                return productExists;
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar consultar con la base de datos eliminar categorias");
            }
            catch (Exception)
            {
                throw new Exception("Error eliminar categorias");
            }
            finally
            {
                _context.FinallyConnection(_connection);
            }
        }
    }
}
