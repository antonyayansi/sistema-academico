using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Privado
{
    public partial class frmAsignatura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            private void Listar()
            {
                Asignatura asignatura = new Asignatura();
                gvAsignatura.DataSource = asignatura.Listar();
                gvAsignatura.DataBind();
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                // solo carga la primera vez
                if (!Page.IsPostBack)
                {
                    Listar();
                }
            }
        }


        protected void btnActualizar_Click(object sender, EventArgs e) 
        {
            Asignatura asignatura = new Asignatura();
            asignatura.CodAsignatura = txtBuscar.Text.Trim();
            asignatura.Asignatura = txtAsignatura();
            asignatura.CodRequisito = txtCodRequisito();
            gvAsignatura.DataSource = asignatura.Buscar();
            gvAsignatura.DataBind();

        }
        

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Asignatura asignatura = new Asignatura();
            asignatura.CodAsignatura = txtCodAsignatura.Text.Trim();
            asignatura.Asignatura = txtAsignatura.Text;
            asignatura.CodRequisito = txtCodRequisito();
            bool resultado = asignatura.Agregar();
            if (resultado)
            {
                Listar();
                txtCodAsignatura.Text = "";
                txtAsignatura.Text = "";
            }
            else
            {
                Response.Write("Error: No se agrego correctamente");
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e) 
        {
            Asignatura asignatura = new Asignatura();
            asignatura.CodAsignatura = txtBuscar.Text.Trim();
            asignatura.CodRequisito = txtCodRequisito();
            gvCarrera.DataSource = carrera.Buscar();
            gvCarrera.DataBind();

        }
            

         protected void btnEliminar_Click(object sender, EventArgs e) 
        {
            try
            {
                Asignatura asignatura = new Asignatura();
                asignatura.CodAsignatura = txtCodAsignatura.Text.Trim();
                asignatura.CodRequisito = txtCodRequisito();
                bool resultado = asignatura.Eliminar();
                if (resultado)
                {
                    Listar();
                    txtCodAsignatura.Text = "";
                    txtAsignatura.Text = "";
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
                    Response.Write("Error: No se puede eliminar esta carrera porque está relacionada con otros registros.");
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
    }
}