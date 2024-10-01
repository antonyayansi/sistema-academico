using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace CapaPresentacion.Privado
{
    public partial class frmDocente : System.Web.UI.Page
    {

        private void Listar()
        {
            Docente Docente = new Docente();
            gvDocente.DataSource = Docente.Listar();
            gvDocente.DataBind();
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

            Docente Docente = new Docente();
            Docente.CodDocente = txtCodDocente.Text.Trim();
            Docente.APaterno = txtAPaterno.Text;
            Docente.AMaterno = txtAMaterno.Text;
            Docente.Nombres = txtNombres.Text;
            Docente.Usuario = txtUsuario.Text;
            bool resultado = Docente.Agregar();
            if (resultado)
            {
                Listar();
                txtCodDocente.Text = "";
                txtAPaterno.Text = "";
                txtAMaterno.Text = "";
                txtNombres.Text = "";
                txtUsuario.Text = "";
            }
            else
            {
                Response.Write("Error: No se agrego correctamente");
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Docente Docente = new Docente();
                Docente.CodDocente = txtCodDocente.Text.Trim();
                bool resultado = Docente.Eliminar();
                if (resultado)
                {
                    Listar();
                    txtCodDocente.Text = "";
                    txtAPaterno.Text = "";
                    txtAMaterno.Text = "";
                    txtNombres.Text = "";
                    txtUsuario.Text = "";
                }
                else
                {
                    Response.Write("Error: No se eliminó correctamente");
                }
            }
            catch (SqlException sqlEx)
            {
                // Verifica el código de error de SQL
                if (sqlEx.Number == 547) // Código de error para violación de clave foránea
                {
                    Response.Write("Error: No se puede eliminar Docente porque está relacionada con otros registros.");
                }
                else
                {
                    Response.Write("Error de base de datos: " + sqlEx.Message);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            Docente Docente = new Docente();
            Docente.CodDocente = txtCodDocente.Text.Trim();
            Docente.APaterno = txtAPaterno.Text;
            Docente.AMaterno = txtAMaterno.Text;
            Docente.Nombres = txtNombres.Text;
            Docente.Usuario = txtUsuario.Text;
            bool resultado = Docente.Actualizar();
            if (resultado)
            {
                Listar();
                txtCodDocente.Text = "";
                txtAPaterno.Text = "";
                txtAMaterno.Text = "";
                txtNombres.Text = "";
                txtUsuario.Text = "";

            }
            else
            {
                Response.Write("Error: No se actualizo correctamente");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Docente Docente = new Docente();
            Docente.CodDocente = txtBuscar.Text.Trim();
            gvDocente.DataSource = Docente.Buscar();
            gvDocente.DataBind();
        }
    }
}