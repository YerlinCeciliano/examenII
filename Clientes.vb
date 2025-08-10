<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Clientes.aspx.vb" Inherits="Clientes" %>
<!DOCTYPE html>
<html xmlns = "http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CRUD Clientes</title>
</head>
<body>
<form id = "form1" runat="server">
        <asp:GridView ID = "GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ClienteId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
<asp:BoundField DataField = "ClienteId" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField = "Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField = "Apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField = "Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField = "Email" HeaderText="Email" />
                <asp:CommandField ShowSelectButton = "True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <h3> Formulario</h3>
        <asp:HiddenField ID = "hfClienteId" runat="server" />
        <asp:TextBox ID = "txtNombre" runat="server" Placeholder="Nombre"></asp:TextBox<> br />
        <asp:TextBox ID="txtApellidos" runat="server" Placeholder="Apellidos"></asp:TextBox> < br />
        <asp:TextBox ID="txtTelefono" runat="server" Placeholder="Teléfono"></asp:TextBox> < br />
        <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox> < br />

        <asp:Button ID = "btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID = "btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
    </form>
</body>
</html>
