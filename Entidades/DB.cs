using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Entidades
{
    public static class DB
    {
        const string STRINGCONNEC = @"Server=agasoluciones.dynamic-dns.net\mssqlserver2;Database=Mensajes;User Id=Alumno;Password=FraUtn;";

        static SqlConnection sqlConn;
        static SqlCommand command;

        static DB()
        {
            sqlConn = new SqlConnection();
            sqlConn.ConnectionString = STRINGCONNEC;
            command = new SqlCommand();
            command.Connection = sqlConn;
        }

        public static Usuario validaUsuario(string usuario, string pass)
        {
            string sql = "select users.id , Users.UserName, Users.PersonId,Personas.Apellido, Personas.DNI, Personas.Nombre from Users inner join Personas on users.PersonId = Personas.Id where  username = @usuario and password = @password";
            command.CommandText = sql;
            command.Parameters.Clear();
            command.Parameters.Add( new SqlParameter( "@usuario", usuario));
            command.Parameters.Add(new SqlParameter("@password", CreateMD5(pass)));

            try
            {
                sqlConn.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    Usuario user = new Usuario();
                    user.Username = usuario;
                    user.UsuarioId = int.Parse(dr["Id"].ToString());
                    user.PersonId = int.Parse(dr["PersonId"].ToString());
                    user.Nombre = dr["Nombre"].ToString();
                    user.DNI = double.Parse(dr["DNI"].ToString()); 
                    user.Apellido = dr["Apellido"].ToString();

                    return user;
                }
                else
                    return null;


            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                sqlConn.Close();
            }

        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

    }
}
