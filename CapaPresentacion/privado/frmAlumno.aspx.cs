using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaNegocio;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaPresentacion.privado
{
    public partial class frmAlumno : System.Web.UI.Page
    {
        private void LlenarDropDownList()
        {
            // Obtener la cadena de conexión desde Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

            // Definir la consulta SQL para obtener las carreras
            string query = "SELECT IdCarrera, NombreCarrera FROM Carreras";

            // Usar ADO.NET para conectarse a la base de datos
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open(); // Abrir la conexión
                    SqlDataReader reader = cmd.ExecuteReader(); // Ejecutar la consulta

                    // Vincular los datos al DropDownList
                    ddCarrera.DataSource = reader;
                    ddCarrera.DataTextField = "NombreCarrera";  // Lo que se mostrará
                    ddCarrera.DataValueField = "IdCarrera";  // El valor que se almacenará
                    ddCarrera.DataBind(); // Vincular los datos

                    // Agregar una opción inicial (opcional)
                    ddCarrera.Items.Insert(0, new ListItem("--Selecciona una carrera--", "0"));
                }
            }
        }
        private void Listar()
        {
            Alumno alumno = new Alumno();
            gvAlumno.DataSource = alumno.Listar();
            gvAlumno.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // solo carga la primera vez
            if (!Page.IsPostBack)
            {
                Listar();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.CodAlumno = txtCodAlumno.Text.Trim();
            alumno.APaterno = txtAPaterno.Text;
            alumno.AMaterno = txtAMaterno.Text;
            alumno.Nombres = txtNombres.Text;
            alumno.Usuario = txtUsuario.Text;
            alumno.CodCarrera = txtCodCarrera.Text;
            bool resultado = alumno.Agregar();
            if (resultado)
            {
                Listar();
                txtCodAlumno.Text = "";
                txtAPaterno.Text = "";
                txtAMaterno.Text = "";
                txtNombres.Text = "";
                txtCodCarrera.Text = "";
            }
            else
            {
                Response.Write("Error: No se agrego correctamente");
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.CodAlumno = txtCodAlumno.Text.Trim();
            alumno.APaterno = txtAPaterno.Text;
            alumno.AMaterno = txtAMaterno.Text;
            alumno.Nombres = txtNombres.Text;
            alumno.CodCarrera = txtCodCarrera.Text;
            bool resultado = alumno.Actualizar();
            if (resultado)
            {
                Listar();
                txtCodAlumno.Text = "";
                txtAPaterno.Text = "";
                txtAMaterno.Text = "";
                txtNombres.Text = "";
                txtCodCarrera.Text = "";
            }
            else
            {
                Response.Write("Error: No se actualizo correctamente");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.CodAlumno = txtBuscar.Text.Trim();
            gvAlumno.DataSource = alumno.Buscar();
            gvAlumno.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.CodAlumno = txtCodAlumno.Text.Trim();
                bool resultado = alumno.Eliminar();
                if (resultado)
                {
                    Listar();
                    txtCodAlumno.Text = "";
                    txtAPaterno.Text = "";
                    txtAMaterno.Text = "";
                    txtNombres.Text = "";
                    txtCodCarrera.Text = "";
                }
                else
                {
                    Response.Write("Error: No se eliminó correctamente");
                }
            }
            catch (SqlException sqlEx)
            {
                
                Response.Write("Error de base de datos: " + sqlEx.Message);
                
            }
        }

    }
}