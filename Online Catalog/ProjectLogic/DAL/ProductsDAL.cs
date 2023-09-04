using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using ProjectLogic.BLL.Entities;


namespace ProjectLogic.DAL
{
    public class ProductsDAL
    {
        private  SqlConnection _connection;
        private readonly DbSqlConnetion _context;
        public ProductsDAL(DbSqlConnetion context)
        {
            _context = context;
            _connection = context.GetConnection();
        }

        public List<dtProducts> GetProducts()
        {
            SqlCommand command = new SqlCommand("sp_GetProducts", _connection);
            command.CommandType = CommandType.StoredProcedure;

            return ReturnsProducts(command);
        }

        public bool AddProduct(dtProducts product)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("sp_AddProduct", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Stock", product.Stock);
                command.Parameters.AddWithValue("@Status", product.Status);
                command.Parameters.AddWithValue("@Autor", product.Author);
                command.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                command.Parameters.AddWithValue("@IdCategory", product.IdCategory);

                int rowsAffected  = command.ExecuteNonQuery();

                return _context.ValidateRowsAffected(rowsAffected);
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar consultar con la base de datos agregando producto");
            }
            catch (Exception)
            {
                throw new Exception("Error agregando producto");
            }
            finally
            {
               _context.FinallyConnection(_connection);
            }            
        }

        public bool UpdateProduct(dtProducts product)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("sp_UpdateProduct", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Stock", product.Stock);
                command.Parameters.AddWithValue("@Status", product.Status);
                command.Parameters.AddWithValue("@Autor", product.Author);
                command.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                command.Parameters.AddWithValue("@IdCategory", product.IdCategory);

                int rowsAffected = command.ExecuteNonQuery();

                return _context.ValidateRowsAffected(rowsAffected);
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar consultar con la base de datos actualzando producto");
            }
            catch (Exception)
            {
                throw new Exception("Error actualzando producto");
            }
            finally
            {
                _context.FinallyConnection(_connection);
            }
        }

        public List<dtProducts> GetProductsByName(string productName)
        {
            SqlCommand command = new SqlCommand("sp_GetProductsByName", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ProductName", productName);

            return ReturnsProducts(command);
        }

        public List<dtProducts> GetProductsByCategoryID(int IdCategory)
        {
            SqlCommand command = new SqlCommand("sp_GetProductsByCategoryID", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdCategory", IdCategory);

            return ReturnsProducts(command);
        }

        public dtProducts GetProductsByID(int productID)
        {
            SqlCommand command = new SqlCommand("sp_GetProductsByID", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", productID);

            return ReturnsProducts(command)[0];
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("sp_DeleteProduct", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", productId);

                int rowsAffected = command.ExecuteNonQuery();

                return _context.ValidateRowsAffected(rowsAffected);
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar consultar con la base de datos eliminando producto");
            }
            catch (Exception)
            {
                throw new Exception("Error eliminando producto");
            }
            finally
            {
                _context.FinallyConnection(_connection);
            }
        }

        public List<dtProducts> ReturnsProducts(SqlCommand command)
        {
            List<dtProducts> listado = new List<dtProducts>();
            try
            {
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listado.Add(new dtProducts
                    {
                        Id = reader.GetInt32(0),
                        ProductCode = reader.GetString(1),
                        ProductName = reader.GetString(2),
                        Stock = reader.GetInt32(3),
                        Status = reader.GetBoolean(4),
                        Author = reader.GetString(5),
                        CreationDate = reader.IsDBNull(6) ? "" : reader.GetDateTime(6).ToString("dd/MM/yyyy"),
                        UpdateDate = reader.IsDBNull(7) ? "" : reader.GetDateTime(7).ToString("dd/MM/yyyy"),
                        IdCategory = reader.GetInt32(8),
                        Category = new dtCategories
                        {
                            CategoryName= reader.GetString(9)
                        }
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
                throw new Exception("Error al intentar listar productos..");
            }
            finally
            {
                _context.FinallyConnection(_connection);
            }  
        }
    }
}
