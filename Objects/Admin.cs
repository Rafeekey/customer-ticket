using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Ticketizer
{
    public class Admin
    {
        private int _id;
        private string _name;
        private string _login_name;
        private string _password;

        public Admin(string name, string username, string password, int id = 0)
        {
            _id = id;
            _name = name;
            _login_name = username;
            _password = password;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetPassword()
        {
            return _password;
        }

        public string GetUsername()
        {
            return _login_name;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO admins (name, login_name, password) OUTPUT INSERTED.id VALUES (@AdminName, @UserName, @Password);", conn);

            cmd.Parameters.Add(new SqlParameter("@AdminName", this.GetName()));
            cmd.Parameters.Add(new SqlParameter("@UserName", this.GetUsername()));
            cmd.Parameters.Add(new SqlParameter("@Password", this.GetPassword()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            DB.CloseSqlConnection(conn, rdr);
        }

        public static Admin Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM admins WHERE id = @AdminId;", conn);

            cmd.Parameters.Add(new SqlParameter("@AdminId", id));

            SqlDataReader rdr = cmd.ExecuteReader();

            int foundId = 0;
            string foundName = null;
            string foundUsername = null;
            string foundPassword = null;

            while(rdr.Read())
            {
                foundId = rdr.GetInt32(0);
                foundName = rdr.GetString(1);
                foundUsername = rdr.GetString(2);
                foundPassword = rdr.GetString(3);
            }

            Admin foundAdmin = new Admin(foundName, foundUsername, foundPassword, foundId);

            DB.CloseSqlConnection(conn, rdr);

            return foundAdmin;
        }

        public static List<Admin> GetAll()
        {
            List<Admin> allAdmins = new List<Admin>();

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM admins ORDER BY name;", conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int foundId = rdr.GetInt32(0);
                string foundName = rdr.GetString(1);
                string foundUsername = rdr.GetString(2);
                string foundPassword = rdr.GetString(3);
                Admin foundAdmin = new Admin(foundName, foundUsername, foundPassword, foundId);
                allAdmins.Add(foundAdmin);
            }

            DB.CloseSqlConnection(conn, rdr);

            return allAdmins;
        }


        public static void Update(int id, string newName)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE admins SET name = @NewName OUTPUT INSERTED.name WHERE id = @AdminId;", conn);
            cmd.Parameters.Add(new SqlParameter("@NewName", newName));
            cmd.Parameters.Add(new SqlParameter("@AdminId", id));

            cmd.ExecuteNonQuery();

            DB.CloseSqlConnection(conn);

        }

        public static bool CheckUsername(string username)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            bool verify = false;

            SqlCommand cmd = new SqlCommand("SELECT * FROM admins WHERE login_name = @UserName;", conn);
            cmd.Parameters.Add(new SqlParameter("@UserName", username));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                verify = true;
            }

            return verify;
        }

        public static bool VerifyLogin(string username, string pw)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            bool verify = false;

            SqlCommand cmd = new SqlCommand("SELECT * FROM admins WHERE login_name = @Username AND password = @Password;", conn);
            cmd.Parameters.Add( new SqlParameter("@Username", username));
            cmd.Parameters.Add(new SqlParameter("@Password", pw));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                verify = true;
            }

            return verify;
        }

        public static Admin FindByUsername(string username)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM admins WHERE login_name = @Username;", conn);

            cmd.Parameters.Add(new SqlParameter("@Username", username));

            SqlDataReader rdr = cmd.ExecuteReader();

            int foundId = 0;
            string foundName = null;
            string foundUsername = null;
            string foundPassword = null;

            while(rdr.Read())
            {
                foundId = rdr.GetInt32(0);
                foundName = rdr.GetString(1);
                foundUsername = rdr.GetString(2);
                foundPassword = rdr.GetString(3);
            }

            Admin foundAdmin = new Admin(foundName, foundUsername, foundPassword, foundId);

            DB.CloseSqlConnection(conn, rdr);

            return foundAdmin;
        }

        public static void Delete(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM admins WHERE id = @AdminId;", conn);
            cmd.Parameters.Add(new SqlParameter("@AdminId", id));

            cmd.ExecuteNonQuery();

            DB.CloseSqlConnection(conn);
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM admins;", conn);

            cmd.ExecuteNonQuery();

            DB.CloseSqlConnection(conn);
        }

        public override bool Equals(System.Object otherAdmin)
        {
            if(!(otherAdmin is Admin))
            {
                return false;
            }
            else
            {
                Admin newAdmin = (Admin) otherAdmin;
                bool idEquality = this.GetId() == newAdmin.GetId();
                bool nameEquality = this.GetName() == newAdmin.GetName();
                return (idEquality && nameEquality);
            }

        }
    }
}
