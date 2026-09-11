using System;
using Agenda.Entidades;
using MySql.Data.MySqlClient;

namespace Agenda.Datos
{
    public class CuentaCteDatos
    {
        private string conexion =
            "Server=localhost;Database=agenda;Uid=root;Pwd=;";

        public void Agregar(CuentaCte cuenta)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = @"INSERT INTO CuentaCte
                    (Id, Id_Agenda, FechaApertura, LimiteCredito, EstadoCredito)
                    VALUES
                    (@Id, @Id_Agenda, @FechaApertura, @LimiteCredito, @EstadoCredito)";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", cuenta.Id);
                    cmd.Parameters.AddWithValue("@Id_Agenda", cuenta.Id_Agenda);
                    cmd.Parameters.AddWithValue("@FechaApertura", cuenta.FechaApertura);
                    cmd.Parameters.AddWithValue("@LimiteCredito", cuenta.LimiteCredito);
                    cmd.Parameters.AddWithValue("@EstadoCredito", cuenta.EstadoCredito);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Modificar(CuentaCte cuenta)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = @"UPDATE CuentaCte SET
                    Id_Agenda = @Id_Agenda,
                    FechaApertura = @FechaApertura,
                    LimiteCredito = @LimiteCredito,
                    EstadoCredito = @EstadoCredito
                    WHERE Id = @Id";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", cuenta.Id);
                    cmd.Parameters.AddWithValue("@Id_Agenda", cuenta.Id_Agenda);
                    cmd.Parameters.AddWithValue("@FechaApertura", cuenta.FechaApertura);
                    cmd.Parameters.AddWithValue("@LimiteCredito", cuenta.LimiteCredito);
                    cmd.Parameters.AddWithValue("@EstadoCredito", cuenta.EstadoCredito);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarPorAgenda(int idAgenda)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = "DELETE FROM CuentaCte WHERE Id_Agenda = @Id_Agenda";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Id_Agenda", idAgenda);
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}