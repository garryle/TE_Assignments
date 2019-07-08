using Post.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Web.DAL
{
    public class ReviewSqlDAO : IReviewDAO
    {
        private string connectionString;

        public ReviewSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all reviews
        /// </summary>
        /// <returns></returns>
        public IList<Review> GetAllReviews()
        {
            IList<Review> reviews = new List<Review>();

            string sql = "select * from reviews";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Review review = new Review()
                    {
                        Username = Convert.ToString(reader["username"]),
                        Rating = Convert.ToInt32(reader["rating"]),
                        Title = Convert.ToString(reader["review_title"]),
                        Message = Convert.ToString(reader["review_text"]),
                        ReviewDate = Convert.ToDateTime(reader["review_date"])
                    };
                    reviews.Add(review);
                }
            }
            return reviews;
        }

        /// <summary>
        /// Saves a new review to the system.
        /// </summary>
        /// <param name="newReview"></param>
        /// <returns></returns>
        public int SaveReview(Review newReview)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO reviews (username, rating, review_title, review_text, review_date) VALUES (@username, @rating, @review_title, @review_text, @review_date);", conn);
                    cmd.Parameters.AddWithValue("@username", newReview.Username);
                    cmd.Parameters.AddWithValue("@rating", newReview.Rating);
                    cmd.Parameters.AddWithValue("@review_title", newReview.Title);
                    cmd.Parameters.AddWithValue("@review_text", newReview.Message);
                    cmd.Parameters.AddWithValue("@review_date", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return 0;
        }
    }
}
