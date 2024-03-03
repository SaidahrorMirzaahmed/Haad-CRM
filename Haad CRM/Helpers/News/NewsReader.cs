using Haad_CRM.Models.New;
using System.Data.SqlClient;


public class NewsReader
{
    public List<News> GetNewsList()
    {
        List<News> newsList = new List<News>();

        var connectionString = "Server=34.70.244.16,1433;Database=haad;User Id=sqlserver;Password=23102005;Encrypt=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, StudentId, Title, Content, PublishDate, IsDeleted, CreatedAt, UpdatedAt, DeletedAt FROM News";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                News news = new News
                {
                    Id = reader.GetInt64(0),
                    StudentId = reader.GetInt32(1),
                    Title = reader.GetString(2),
                    Content = reader.GetString(3),
                    PublishDate = DateTime.Parse(reader.GetString(4)),
                    // Auditable properties
                    IsDeleted = reader.GetBoolean(5),
                    CreatAt = DateTime.Parse(reader.GetString(6)),
                    UpdateAt = DateTime.Parse(reader.GetString(7)),
                    DeletedAd = DateTime.Parse(reader.GetString(8))
                };

                newsList.Add(news);
            }

            reader.Close();
        }

        return newsList;
    }

}


