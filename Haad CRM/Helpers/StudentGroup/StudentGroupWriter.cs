using Haad_CRM.Models.StudentGroup;
using System.Data.SqlClient;

namespace Haad_CRM.Helpers;

public class StudentGroupWriter
{
    public void UpdateStudentGroupList(List<StudentGroup> newStudentGroupList)
    {
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Step 1: Delete all records from the StudentGroup table
            string deleteQuery = "DELETE FROM StudentGroup";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.ExecuteNonQuery();

            // Step 2: Insert new records from the newStudentGroupList
            foreach (StudentGroup studentGroup in newStudentGroupList)
            {
                string insertQuery = "INSERT INTO StudentGroup (StudentId, GroupId) " +
                                     "VALUES (@StudentId, @GroupId)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@StudentId", studentGroup.StudentId);
                insertCommand.Parameters.AddWithValue("@GroupId", studentGroup.GroupId);

                insertCommand.ExecuteNonQuery();
            }
        }
    }

}


