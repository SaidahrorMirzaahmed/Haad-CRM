using Haad_CRM.Models.Student;
using System.Data.SqlClient;

namespace Haad_CRM.Helpers;

public class StudentWriter
{
    public void UpdateStudentList(List<Student> newStudentList)
    {
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Step 1: Delete all records from the Student table
            string deleteQuery = "DELETE FROM Student";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.ExecuteNonQuery();

            // Step 2: Insert new records from the newStudentList
            foreach (Student student in newStudentList)
            {
                string insertQuery = "INSERT INTO Student (FirstName, LastName, DateOfBirth, ParentPhoneNumber, Email, CoinId, CourseId, Phone, Address, IsDeleted, CreatedAt, UpdatedAt, DeletedAt) " +
                                     "VALUES (@FirstName, @LastName, @DateOfBirth, @ParentPhoneNumber, @Email, @CoinId, @CourseId, @Phone, @Address, @IsDeleted, @CreatedAt, @UpdatedAt, @DeletedAt)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                insertCommand.Parameters.AddWithValue("@LastName", student.LastName);
                insertCommand.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                insertCommand.Parameters.AddWithValue("@ParentPhoneNumber", student.ParentPhoneNumber);
                insertCommand.Parameters.AddWithValue("@Email", student.Email);
                insertCommand.Parameters.AddWithValue("@CoinId", student.CoinId);
                insertCommand.Parameters.AddWithValue("@CourseId", student.CourseId);
                insertCommand.Parameters.AddWithValue("@Phone", student.Phone);
                insertCommand.Parameters.AddWithValue("@Address", student.Address);
                // Auditable properties
                insertCommand.Parameters.AddWithValue("@IsDeleted", student.IsDeleted);
                insertCommand.Parameters.AddWithValue("@CreatedAt", student.CreatAt.ToString());
                insertCommand.Parameters.AddWithValue("@UpdatedAt", student.UpdateAt.ToString());
                insertCommand.Parameters.AddWithValue("@DeletedAt", student.DeletedAd.ToString());

                insertCommand.ExecuteNonQuery();
            }
        }
    }

}


