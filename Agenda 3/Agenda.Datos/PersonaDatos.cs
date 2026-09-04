using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Entidades;
using MySql.Data.MySqlClient;

namespace Agenda.Datos
{
    public class PersonaDatos
    {
        private string conexion =
            "Server=localhost;Database=agenda;Uid=root;Pwd=TU_CONTRASEÑA;";

        public void Agregar(Persona persona)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = @"INSERT INTO personas
                (DNI, APELLIDO, NOMBRES, CALLE, DEPTO, PISO, CIUDAD, TELEFONO, EMAIL)
                VALUES
                (@DNI, @APELLIDO, @NOMBRES, @CALLE, @DEPTO, @PISO, @CIUDAD, @TELEFONO, @EMAIL)";

                MySqlCommand cmd = new MySqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@DNI", persona.DNI);
                cmd.Parameters.AddWithValue("@APELLIDO", persona.APELLIDO);
                cmd.Parameters.AddWithValue("@NOMBRES", persona.NOMBRES);
                cmd.Parameters.AddWithValue("@CALLE", persona.CALLE);
                cmd.Parameters.AddWithValue("@DEPTO", persona.DEPTO);
                cmd.Parameters.AddWithValue("@PISO", persona.PISO);
                cmd.Parameters.AddWithValue("@CIUDAD", persona.CIUDAD);
                cmd.Parameters.AddWithValue("@TELEFONO", persona.TELEFONO);
                cmd.Parameters.AddWithValue("@EMAIL", persona.EMAIL);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Persona> Buscar(string campo, string valor)
        {
            List<Persona> personas = new List<Persona>();

            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = $"SELECT * FROM personas WHERE {campo} LIKE @valor";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@valor", "%" + valor + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    personas.Add(new Persona
                    {
                        DNI = Convert.ToInt32(reader["DNI"]),
                        APELLIDO = reader["APELLIDO"].ToString(),
                        NOMBRES = reader["NOMBRES"].ToString(),
                        CALLE = reader["CALLE"].ToString(),
                        DEPTO = reader["DEPTO"].ToString(),
                        PISO = Convert.ToInt32(reader["PISO"]),
                        CIUDAD = reader["CIUDAD"].ToString(),
                        TELEFONO = reader["TELEFONO"].ToString(),
                        EMAIL = reader["EMAIL"].ToString()
                    });
                }
            }

            return personas;
        }

        public void Eliminar(int dni)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = "DELETE FROM personas WHERE DNI = @DNI";

                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@DNI", dni);

                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(Persona persona)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = @"UPDATE personas SET
                    APELLIDO = @APELLIDO,
                    NOMBRES = @NOMBRES,
                    CALLE = @CALLE,
                    DEPTO = @DEPTO,
                    PISO = @PISO,
                    CIUDAD = @CIUDAD,
                    TELEFONO = @TELEFONO,
                    EMAIL = @EMAIL
                    WHERE DNI = @DNI";

                MySqlCommand cmd = new MySqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@DNI", persona.DNI);
                cmd.Parameters.AddWithValue("@APELLIDO", persona.APELLIDO);
                cmd.Parameters.AddWithValue("@NOMBRES", persona.NOMBRES);
                cmd.Parameters.AddWithValue("@CALLE", persona.CALLE);
                cmd.Parameters.AddWithValue("@DEPTO", persona.DEPTO);
                cmd.Parameters.AddWithValue("@PISO", persona.PISO);
                cmd.Parameters.AddWithValue("@CIUDAD", persona.CIUDAD);
                cmd.Parameters.AddWithValue("@TELEFONO", persona.TELEFONO);
                cmd.Parameters.AddWithValue("@EMAIL", persona.EMAIL);

                cmd.ExecuteNonQuery();
            }
        }
    }
}