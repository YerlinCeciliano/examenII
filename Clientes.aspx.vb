Imports Models

Partial Class Clientes
    Inherits System.Web.UI.Page

    Dim repo As New ClienteRepository()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarGrid()
        End If
    End Sub

    Private Sub CargarGrid()
        GridView1.DataSource = repo.GetAll()
        GridView1.DataBind()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse String.IsNullOrWhiteSpace(txtApellidos.Text) OrElse String.IsNullOrWhiteSpace(txtTelefono.Text) Then
            Response.Write("<script>alert('Nombre, Apellidos y Teléfono son obligatorios');</script>")
            Return
        End If

        If Not txtEmail.Text.Contains("@") Then
            Response.Write("<script>alert('Email inválido');</script>")
            Return
        End If

        Dim c As New Cliente With {
            .Nombre = txtNombre.Text,
            .Apellidos = txtApellidos.Text,
            .Telefono = txtTelefono.Text,
            .Email = txtEmail.Text
        }

        If String.IsNullOrEmpty(hfClienteId.Value) Then
            repo.Insert(c)
        Else
            c.ClienteId = Convert.ToInt32(hfClienteId.Value)
            repo.Update(c)
        End If

        LimpiarFormulario()
        CargarGrid()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim id = Convert.ToInt32(GridView1.SelectedDataKey.Value)
        Dim cliente = repo.GetAll().FirstOrDefault(Function(x) x.ClienteId = id)
        If cliente IsNot Nothing Then
            hfClienteId.Value = cliente.ClienteId
            txtNombre.Text = cliente.Nombre
            txtApellidos.Text = cliente.Apellidos
            txtTelefono.Text = cliente.Telefono
            txtEmail.Text = cliente.Email
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim id = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        repo.Delete(id)
        CargarGrid()
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarFormulario()
    End Sub

    Private Sub LimpiarFormulario()
        hfClienteId.Value = ""
        txtNombre.Text = ""
        txtApellidos.Text = ""
        txtTelefono.Text = ""
        txtEmail.Text = ""
    End Sub
End Class
