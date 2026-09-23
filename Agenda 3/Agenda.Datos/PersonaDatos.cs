
using System;
using System.Collections.Generic;
using Agenda.Entidades;
using MySql.Data.MySqlClient;

namespace Agenda.Datos
{
    public class PersonaDatos
    {
        private string conexion =
            "Server=localhost;Database=agenda3;Uid=root;Pwd=;";

        public void Agregar(Persona persona)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = @"INSERT INTO personas
                (DNI, APELLIDO, NOMBRES, CALLE, DEPTO, PISO, CIUDAD, TELEFONO, EMAIL)
                VALUES
                (@DNI, @APELLIDO, @NOMBRES, @CALLE, @DEPTO, @PISO, @CIUDAD, @TELEFONO, @EMAIL)";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@DNI", persona.Dni);
                    cmd.Parameters.AddWithValue("@APELLIDO", persona.Apellido);
                    cmd.Parameters.AddWithValue("@NOMBRES", persona.Nombres);
                    cmd.Parameters.AddWithValue("@CALLE", persona.Calle);
                    cmd.Parameters.AddWithValue("@DEPTO", persona.Depto);
                    cmd.Parameters.AddWithValue("@PISO", persona.Piso);
                    cmd.Parameters.AddWithValue("@CIUDAD", persona.Ciudad);
                    cmd.Parameters.AddWithValue("@TELEFONO", persona.Telefono);
                    cmd.Parameters.AddWithValue("@EMAIL", persona.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarConCuenta(Persona persona, CuentaCte cuenta)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                using (MySqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        string sqlPersona = @"INSERT INTO personas
                            (DNI, APELLIDO, NOMBRES, CALLE, DEPTO, PISO, CIUDAD, TELEFONO, EMAIL)
                            VALUES
                            (@DNI, @APELLIDO, @NOMBRES, @CALLE, @DEPTO, @PISO, @CIUDAD, @TELEFONO, @EMAIL)";

                        using (MySqlCommand cmd = new MySqlCommand(sqlPersona, cn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@DNI", persona.Dni);
                            cmd.Parameters.AddWithValue("@APELLIDO", persona.Apellido);
                            cmd.Parameters.AddWithValue("@NOMBRES", persona.Nombres);
                            cmd.Parameters.AddWithValue("@CALLE", persona.Calle);
                            cmd.Parameters.AddWithValue("@DEPTO", persona.Depto);
                            cmd.Parameters.AddWithValue("@PISO", persona.Piso);
                            cmd.Parameters.AddWithValue("@CIUDAD", persona.Ciudad);
                            cmd.Parameters.AddWithValue("@TELEFONO", persona.Telefono);
                            cmd.Parameters.AddWithValue("@EMAIL", persona.Email);

                            cmd.ExecuteNonQuery();
                        }

                        string sqlCuenta = @"INSERT INTO CuentaCte
                            (Id, Id_Agenda, FechaApertura, LimiteCredito, EstadoCredito)
                            VALUES
                            (@Id, @Id_Agenda, @FechaApertura, @LimiteCredito, @EstadoCredito)";

                        using (MySqlCommand cmd = new MySqlCommand(sqlCuenta, cn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@Id", cuenta.Id);
                            cmd.Parameters.AddWithValue("@Id_Agenda", cuenta.IdAgenda);
                            cmd.Parameters.AddWithValue("@FechaApertura", cuenta.FechaApertura);
                            cmd.Parameters.AddWithValue("@LimiteCredito", cuenta.LimiteCredito);
                            cmd.Parameters.AddWithValue("@EstadoCredito", cuenta.EstadoCredito);

                            cmd.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<Persona> Buscar(string campo, string valor)
        {
            List<Persona> personas = new List<Persona>();

            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = $"SELECT * FROM personas WHERE {campo} LIKE @valor";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@valor", "%" + valor + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            personas.Add(new Persona
                            {
                                Dni = Convert.ToInt32(reader["DNI"]),
                                Apellido = reader["APELLIDO"].ToString(),
                                Nombres = reader["NOMBRES"].ToString(),
                                Calle = reader["CALLE"].ToString(),
                                Depto = reader["DEPTO"].ToString(),

                                Piso = reader["PISO"] == DBNull.Value
                                    ? 0
                                    : Convert.ToInt32(reader["PISO"]),

                                Ciudad = reader["CIUDAD"].ToString(),
                                Telefono = reader["TELEFONO"].ToString(),
                                Email = reader["EMAIL"].ToString()
                            });
                        }
                    }
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

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@DNI", dni);
                    cmd.ExecuteNonQuery();
                }
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

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@DNI", persona.Dni);
                    cmd.Parameters.AddWithValue("@APELLIDO", persona.Apellido);
                    cmd.Parameters.AddWithValue("@NOMBRES", persona.Nombres);
                    cmd.Parameters.AddWithValue("@CALLE", persona.Calle);
                    cmd.Parameters.AddWithValue("@DEPTO", persona.Depto);
                    cmd.Parameters.AddWithValue("@PISO", persona.Piso);
                    cmd.Parameters.AddWithValue("@CIUDAD", persona.Ciudad);
                    cmd.Parameters.AddWithValue("@TELEFONO", persona.Telefono);
                    cmd.Parameters.AddWithValue("@EMAIL", persona.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

