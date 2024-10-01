﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Security;


namespace CapaPresentacion
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            
                string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    string consulta = "select * from TUsuario where Usuario=@usuario and Contrasena=@pass";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@usuario", Login1.UserName);
                    comando.Parameters.AddWithValue("@pass", Login1.Password);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    DataRow fila = tabla.Rows[0];
                    adapter.Fill(tabla);
                    if (tabla.Rows.Count == 0)
                    {
                        Login1.FailureText = "usuario no autorizado";
                    }
                    else
                    {
                        Login1.FailureText = "usuario correcto";

                        FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);

                    }
                }
            
        }
    }
}