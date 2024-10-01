<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAlumno.aspx.cs" Inherits="CapaPresentacion.privado.frmAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Mantenimiento de la tabla Alumno</h3>
    <p>
        CodAlumno: <asp:TextBox runat="server" Id="txtCodAlumno" />
    </p>
     <p>
        APaterno: <asp:TextBox runat="server" Id="txtAPaterno" />
    </p>
     <p>
        AMaterno: <asp:TextBox runat="server" Id="txtAMaterno" />
    </p>
     <p>
        Nombres: <asp:TextBox runat="server" Id="txtNombres" />
    </p>
     <p>
        Usuario: <asp:TextBox runat="server" Id="txtUsuario" />
      </p>
     <p>
        CodCarrera: <asp:TextBox runat="server" Id="txtCodCarrera" />

         <asp:DropDownList runat="server" Id="ddCarrera" AutoPostBack="True">
         </asp:DropDownList>
     </p>
    <p>
        <asp:Button Text="Agregar" runat="server" Id="btnAgregar" OnClick="btnAgregar_Click" />
        <asp:Button Text="Eliminar" runat="server" Id="btnEliminar" OnClick="btnEliminar_Click" />
        <asp:Button Text="Actualizar" runat="server" Id="btnActualizar" OnClick="btnActualizar_Click" />
    </p>
    <p>
        Buscar: <asp:TextBox runat="server" Id="txtBuscar" />
        <asp:Button Text="Buscar" runat="server" Id="btnBuscar" OnClick="btnBuscar_Click" />
    </p>
    <p>
        <asp:GridView runat="server" ID="gvAlumno"></asp:GridView>
    </p>
</asp:Content>
