using Haad_CRM.Models.Lesson;
using Haad_CRM.Models.New;
using System.Data.SqlClient;


public class NewsWriter
{
    public void UpdateNewsList(List<News> newNewsList)
    {
        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Step 1: Delete all records from the News table
            string deleteQuery = "DELETE FROM News";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.ExecuteNonQuery();

            // Step 2: Insert new records from the newNewsList
            foreach (News news in newNewsList)
            {
                string insertQuery = "INSERT INTO News (StudentId, Title, Content, PublishDate, IsDeleted, CreatedAt, UpdatedAt, DeletedAt) " +
                                     "VALUES (@StudentId, @Title, @Content, @PublishDate, @IsDeleted, @CreatedAt, @UpdatedAt, @DeletedAt)";

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@StudentId", news.StudentId);
                insertCommand.Parameters.AddWithValue("@Title", news.Title);
                insertCommand.Parameters.AddWithValue("@Content", news.Content);
                insertCommand.Parameters.AddWithValue("@PublishDate", news.PublishDate);
                // Auditable properties
                insertCommand.Parameters.AddWithValue("@IsDeleted", news.IsDeleted);
                insertCommand.Parameters.AddWithValue("@CreatedAt", news.CreatAt.ToString());
                insertCommand.Parameters.AddWithValue("@UpdatedAt", news.UpdateAt.ToString());
                insertCommand.Parameters.AddWithValue("@DeletedAt", news.DeletedAt.ToString());

                insertCommand.ExecuteNonQuery();
            }
        }
    }

}


