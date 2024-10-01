﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCarrera.aspx.cs" Inherits="CapaPresentacion.frmCarrera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Mantenimiento de la tabla carrera</h3>
    <p>
        CodAsignatura: <asp:TextBox runat="server" Id="txtCodAsignatura" />
    </p>
     <p>
        Asigantura: <asp:TextBox runat="server" Id="txtAsigantura" />
    </p>
    <p>
        CodRequisito: <asp:TextBox runat="server" Id="CodRequisito" />
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
        <asp:GridView runat="server" ID="gvAsignatura"></asp:GridView>
    </p>
</asp:Content>
