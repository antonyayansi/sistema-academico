using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaNegocio
{
    public class Asignatura
    {
        

        public string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        public string CodAsignatura { get; set; }
        public string NombreAsignatura { get; set; }
        public string CodRequisito { get; set; }


        public DataTable Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM TAsignatura";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }

        public bool Agregar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "INSERT INTO TAsignatura values(@CodCarrera, @NombreCarrera, @CodRequisito)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
                comando.Parameters.AddWithValue("@NombreAsignatura", NombreAsignatura);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }


        public bool Eliminar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "DELETE FROM TAsignatura WHERE CodAsignartura= @CodAsignatura";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

        public bool Actualizar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "UPDATE TAsignatura SET Asignatura = @NombreAsignatura WHERE CodAsignatura = @CodAsignatura";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@NombreAsignatura", NombreAsignatura);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

        public DataTable Buscar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM TAsignatura WHERE CodAsigantura = @CodAsignatura";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }

        }
    }
}
