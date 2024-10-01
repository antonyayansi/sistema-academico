<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CapaPresentacion.Privado.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h3>Mantenimiento de la tabla asignatura</h3>
    <p>
        CodAsiganatura: <asp:TextBox runat="server" Id="txtCodAsignatura" />
    </p>
     <p>
        Asignatura: <asp:TextBox runat="server" Id="txtAsignatura" />
    </p>
    <p>
        CodRequisito: <asp:TextBox runat="server" Id="TextCodRequisito" />
    </p>
    <p>
        <asp:Button Text="Agregar" runat="server" Id="btnAgregar" OnClick="btnAgregar_Click" />
        <asp:Button Text="Eliminar" runat="server" Id="btnEliminar" OnClick="btnEliminar_Click"  />
        <asp:Button Text="Actualizar" runat="server" Id="btnActualizar"  />
    </p>
    <p>
        Buscar: <asp:TextBox runat="server" Id="txtBuscar" />
        <asp:Button Text="Buscar" runat="server" Id="btnBuscar" OnClick="btnBuscar_Click" />
    </p>
    <p>
        <asp:GridView runat="server" ID="gvCarrera"></asp:GridView>
    </p>
</asp:Content>
