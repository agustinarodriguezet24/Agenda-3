using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Negocio;

namespace Datos
{
    public class CuentaCteDatos
    {
        private string conexion = "";

        public void Agregar(CuentaCte cuenta)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = @"INSERT INTO CuentaCte
                               (Id_Agenda, FechaApertura, LimiteCredito, EstadoCredito)
                               VALUES
                               (@Id_Agenda, @FechaApertura, @LimiteCredito, @EstadoCredito)";

                MySqlCommand cmd = new MySqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Id_Agenda", cuenta.Id_Agenda);
                cmd.Parameters.AddWithValue("@FechaApertura", cuenta.FechaApertura);
                cmd.Parameters.AddWithValue("@LimiteCredito", cuenta.LimiteCredito);
                cmd.Parameters.AddWithValue("@EstadoCredito", cuenta.EstadoCredito);

                cmd.ExecuteNonQuery();
            }
        }
    }
}