using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MyContactsBL;

namespace MyContactsDB
{
    public class Broker
    {
        private SqlConnection connection;
        private SqlConnectionStringBuilder connectionStringBuilder;

        void ConnectToDataBase()
        {
            //Data Source=DESKTOP-KRLBG0Q\SQLEXPRESS;Initial Catalog=Contacts;Integrated Security=True

            connectionStringBuilder=new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = @"DESKTOP-KRLBG0Q\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "Contacts";
            connectionStringBuilder.IntegratedSecurity = true;

            connection = new SqlConnection(connectionStringBuilder.ToString());


        }

        public Broker()
        {
            ConnectToDataBase();
        }

        public void Insert(Person person)
        {
            try
            {
                string commandText = "INSERT INTO dbo.PersonsTable(FirstName,LastName,Email,Number)" +
                                     " VALUES(@FirstName,@LastName,@Email,@Number)";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@FirstName", person.FirstName);
                command.Parameters.AddWithValue("@LastName", person.LastName);
                command.Parameters.AddWithValue("@Email", person.EmailAddress);
                command.Parameters.AddWithValue("@Number", person.Number);
                connection.Open();
                command.ExecuteNonQuery();

                

                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public ObservableCollection<IContact> RetrievePersons()
        {
            ObservableCollection<IContact> contactsList = new ObservableCollection<IContact>();

            try
            {
                string commandText = "SELECT * FROM dbo.PersonsTable";

                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Person person = new Person();
                    person.ID = Int32.Parse(reader["ID"].ToString());
                    person.FirstName = reader["FirstName"].ToString();
                    person.LastName = reader["LastName"].ToString();
                    person.EmailAddress = reader["Email"].ToString();
                    person.Number = reader["Number"].ToString();
                    person.Address = reader["Address"].ToString();
                    person.City = reader["City"].ToString();
                    person.Company = reader["Company"].ToString();

                    contactsList.Add(person);
                }
                
                return contactsList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
                
            }
        }

        public void Delete(Person person)
        {
            try
            {
                string commandText = "DELETE FROM dbo.PersonsTable WHERE ID=@ID";

                SqlCommand command = new SqlCommand(commandText,connection);
                command.Parameters.AddWithValue("@ID", person.ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
                
            }
        }

       


    }
}
