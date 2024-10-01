<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDocente.aspx.cs" Inherits="CapaPresentacion.Privado.frmDocente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h3>Mantenimiento de la tabla Docente</h3>
<p>
    CodDocente: <asp:TextBox runat="server" Id="txtCodDocente" />
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
    <asp:Button Text="Agregar" runat="server" Id="btnAgregar" OnClick="btnAgregar_Click" />
    <asp:Button Text="Eliminar" runat="server" Id="btnEliminar" OnClick="btnEliminar_Click" />
    <asp:Button Text="Actualizar" runat="server" Id="btnActualizar" OnClick="btnActualizar_Click" />
</p>
<p>
    Buscar: <asp:TextBox runat="server" Id="txtBuscar" />
    <asp:Button Text="Buscar" runat="server" Id="btnBuscar" OnClick="btnBuscar_Click" />
</p>
<p>
    <asp:GridView runat="server" ID="gvDocente"></asp:GridView>
</p>
</asp:Content>

