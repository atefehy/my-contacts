using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact
{
    class ContactsRepository : IContactsRepository
    {
        private string stringConection = "Data Source=.;Initial Catalog=Contact_DB;Integrated Security=true";
        public bool Delete(int Contact_id)
        {
            SqlConnection connectionn = new SqlConnection(stringConection);

            try
            {
                string query = "Delete From contact_table Where Contact_id=@ID";
                SqlCommand command = new SqlCommand(query, connectionn);
                command.Parameters.AddWithValue("@ID", Contact_id);
                connectionn.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connectionn.Close();
            }
        }

        public bool Insert(string Name, string Family, int Age, string Mobile, string Email)
        {
            SqlConnection connectionn = new SqlConnection(stringConection);

            try
            {
                string query = "Insert Into contact_table(Name,Family,Age,Mobile,Email)values(@Name,@Family,@Age,@Mobile,@Email)";
                SqlCommand command = new SqlCommand(query, connectionn);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Family", Family);
                command.Parameters.AddWithValue("@Age", Age);
                command.Parameters.AddWithValue("@Mobile", Mobile);
                command.Parameters.AddWithValue("@Email", Email);
                connectionn.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connectionn.Close();
            }
        }

        public DataTable Search(string parameters)
        {
            string query = "Select * From contact_table Where Name Like @parameters or Family Like @parameters";
            SqlConnection connection = new SqlConnection(stringConection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameters", "%" + parameters + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "Select * From contact_table";
            SqlConnection connection = new SqlConnection(stringConection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;

        }

        public DataTable SelectRow(int Contact_id)
        {
            string query = "Select * From contact_table Where Contact_id=" + Contact_id;
            SqlConnection connection = new SqlConnection(stringConection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(int Contact_id, string Name, string Family, int Age, string Mobile, string Email)
        {
            SqlConnection connectionn = new SqlConnection(stringConection);

            try
            {
                string query = "Update contact_table Set Name=@Name,Family=@Family,Age=@Age,Mobile=@Mobile,Email=@Email Where Contact_id=@ID";
                SqlCommand command = new SqlCommand(query, connectionn);
                command.Parameters.AddWithValue("@ID", Contact_id);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Family", Family);
                command.Parameters.AddWithValue("@Age", Age);
                command.Parameters.AddWithValue("@Mobile", Mobile);
                command.Parameters.AddWithValue("@Email", Email);
                connectionn.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connectionn.Close();
            }
        }
    }
}
