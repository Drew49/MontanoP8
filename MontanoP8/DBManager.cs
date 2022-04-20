using System.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontanoP8
{
    public class DBManager
    {
        
        public List<Card> GetCards()
        {
            List<Card> cards = new List<Card>();
            string connStr = ConfigurationManager.ConnectionStrings["MontanoP8"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Card", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Card card = new Card();

                    card.CardID = dr.GetInt32(0);
                    card.Title = dr.IsDBNull(1) ? null : dr.GetString(1);
                    card.Question = dr.IsDBNull(2) ? null : dr.GetString(2);
                    card.Answer = dr.IsDBNull(3) ? null : dr.GetString(3);
                    card.NumRight = dr.GetInt32(4);
                    card.NumWrong = dr.GetInt32(5);
                    cards.Add(card);
                }

            } return cards;
           
        }

        public void AddCard(Card card)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MontanoP8"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand
                    ("INSERT INTO Card(Title, Question, Answer, NumRight, NumWrong) " +
                    "VALUES (@Title, @Question,@Answer, @NumRight, @NumWrong);", conn);
                cmd.Parameters.AddWithValue("Title",card.Title);
                cmd.Parameters.AddWithValue("Question",card.Question);
                cmd.Parameters.AddWithValue("Answer", card.Answer);
                cmd.Parameters.AddWithValue("NumRight", card.NumRight);
                
                cmd.Parameters.AddWithValue("NumWrong", card.NumWrong);
                conn.Open();
                cmd.ExecuteNonQuery();
                    
            }
        }

        public void RemoveCard(int id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MontanoP8"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Card WHERE Id = @Id",conn);
                cmd.Parameters.AddWithValue("Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Card card)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MontanoP8"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Card SET Title = @Title, Question = @Question, Answer = @Answer," +
                    "NumRight = @NumRight, NumWrong = @NumWrong WHERE Id = @Id;", conn);
                cmd.Parameters.AddWithValue("Title", card.Title);
                cmd.Parameters.AddWithValue("Question", card.Question);
                cmd.Parameters.AddWithValue("Answer", card.Answer);
                cmd.Parameters.AddWithValue("NumRight", card.NumRight);
                cmd.Parameters.AddWithValue("NumWrong", card.NumWrong);
                cmd.Parameters.AddWithValue("Id", card.CardID);
                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}
