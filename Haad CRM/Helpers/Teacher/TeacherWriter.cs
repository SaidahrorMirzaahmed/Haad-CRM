using Haad_CRM.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class TeacherWriter
{
    public void UpdateTeacherList(List<Teacher> newTeacherList)
    {
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Step 1: Delete all records from the Teacher table
            string deleteQuery = "DELETE FROM Teacher";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.ExecuteNonQuery();

            // Step 2: Insert new records from the newTeacherList
            foreach (Teacher teacher in newTeacherList)
            {
                string insertQuery = "INSERT INTO Teacher (FirstName, LastName, Phone, Email, IsDeleted, CreatedAt, UpdatedAt, DeletedAt) " +
                                     "VALUES (@FirstName, @LastName, @Phone, @Email, @IsDeleted, @CreatedAt, @UpdatedAt, @DeletedAt)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@FirstName", teacher.FirstName);
                insertCommand.Parameters.AddWithValue("@LastName", teacher.LastName);
                insertCommand.Parameters.AddWithValue("@Phone", teacher.Phone);
                insertCommand.Parameters.AddWithValue("@Email", teacher.Email);
                // Auditable properties
                insertCommand.Parameters.AddWithValue("@IsDeleted", teacher.IsDeleted);
                insertCommand.Parameters.AddWithValue("@CreatedAt", teacher.CreatAt.ToString());
                insertCommand.Parameters.AddWithValue("@UpdatedAt", teacher.UpdateAt.ToString());
                insertCommand.Parameters.AddWithValue("@DeletedAt", teacher.DeletedAt.ToString());

                insertCommand.ExecuteNonQuery();
            }
        }
    }

}
