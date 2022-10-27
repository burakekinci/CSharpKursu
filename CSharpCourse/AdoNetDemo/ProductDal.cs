using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    //ProductDal veya ProductDao
    //Data Access Layer -- Data Access Object
    public class ProductDal
    {
        //integrated security windows uzerindeki sqlserverda windows auth olsun mu demek
        static string _connectionString = @"server=(localdb)\MSSQLLocalDB;initial catalog=ETrade;integrated security=true";
        SqlConnection _connection = new SqlConnection(_connectionString);

        public List<Product> GetAll()
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("SELECT * FROM Products", _connection);
            SqlDataReader reader = command.ExecuteReader();//select sorgusu liste doneceginden bir datareadera ihtiyac var 

            //DataTable kullanmak masrafli bir islem o yuzden bu sekilde list kullanmak daha iyi
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    UnitPrice = Convert.ToInt32(reader["UnitPrice"]),
                    StockAmount = Convert.ToInt32(reader["StockAmount"])
                };
                products.Add(product);
            }
            reader.Close();
            _connection.Close();
            return products;

        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public DataTable GetAll2()
        {

            ConnectionControl();
            
            SqlCommand command = new SqlCommand("SELECT * FROM Products", _connection);
            SqlDataReader reader = command.ExecuteReader();//select sorgusu liste doneceginden bir datareadera ihtiyac var 

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            _connection.Close();
            return dataTable;

        }
    
        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = 
                new SqlCommand("INSERT INTO Products VALUES(@name,@unitPrice,@stockAmount)", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = 
                new SqlCommand("UPDATE Products SET Name=@name,UnitPrice=@unitPrice,StockAmount=@stockAmount WHERE Id=@id", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@id", product.Id);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command =
                new SqlCommand("DELETE FROM Products WHERE Id=@id", _connection);
            
            command.Parameters.AddWithValue("@id",id);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
