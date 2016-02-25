using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using ChatApp.Models;

namespace ChatWebServices.Controllers
{
    public class MessagesController : ApiController
    {
        // GET api/messages
        public IEnumerable<ChatMessage> Get()
        {
            List<ChatMessage> messages = new List<ChatMessage>();
            MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=chatdb.cchk4ntijdhx.us-east-1.rds.amazonaws.com;" +
                "uid=toddtwiggs;pwd=Kaelyn01;database=chat;";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM ChatMessages ORDER BY MessageID", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Int32 messageID = reader.GetInt32("MessageID");
                    string message = reader.GetString("MessageText");
                    string sentBy = reader.GetString("SentBy");
                    DateTime sentDateTime = reader.GetDateTime("SentDateTime");
                    ChatMessage msg = new ChatMessage();
                    msg.MessageID = messageID;
                    msg.MessageText = message;
                    msg.SentBy = sentBy;
                    msg.SentDateTime = sentDateTime;
                    messages.Add(msg);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            return messages;
        }

        // GET api/messages/5
        public IEnumerable<ChatMessage> Get(int id)
        {
            List<ChatMessage> messages = new List<ChatMessage>();
            MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=chatdb.cchk4ntijdhx.us-east-1.rds.amazonaws.com;" +
                "uid=toddtwiggs;pwd=Kaelyn01;database=chat;";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT * FROM ChatMessages WHERE MessageID > @id ORDER BY MessageID", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Int32 messageID = reader.GetInt32("MessageID");
                    string message = reader.GetString("MessageText");
                    string sentBy = reader.GetString("SentBy");
                    DateTime sentDateTime = reader.GetDateTime("SentDateTime");
                    ChatMessage msg = new ChatMessage();
                    msg.MessageID = messageID;
                    msg.MessageText = message;
                    msg.SentBy = sentBy;
                    msg.SentDateTime = sentDateTime;
                    messages.Add(msg);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            return messages;
        }

        // POST api/messages
        public void Post([FromBody]ChatMessage message)
        {
            MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=chatdb.cchk4ntijdhx.us-east-1.rds.amazonaws.com;" +
                "uid=toddtwiggs;pwd=Kaelyn01;database=chat;";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO ChatMessages (MessageID, MessageText, SentBy, SentDateTime) " +
                    "VALUES (@id, @messageText, @sentBy, NOW())", conn);
                cmd.Parameters.AddWithValue("@id", message.MessageID);
                cmd.Parameters.AddWithValue("@messageText", message.MessageText);
                cmd.Parameters.AddWithValue("@sentBy", message.SentBy);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/messages/5
        public void Put([FromBody]ChatMessage message)
        {
            MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=chatdb.cchk4ntijdhx.us-east-1.rds.amazonaws.com;" +
                "uid=toddtwiggs;pwd=Kaelyn01;database=chat;";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(
                    "UPDATE ChatMessages" +
                    "SET MessageText='@messageText', SentBy='@sentBy', SentDateTime=NOW()" +
                    "WHERE MessageID='@id'", conn);
                cmd.Parameters.AddWithValue("@id", message.MessageID);
                cmd.Parameters.AddWithValue("@messageText", message.MessageText);
                cmd.Parameters.AddWithValue("@sentBy", message.SentBy);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/messages/5
        public void Delete(int id)
        {
        }
    }
}