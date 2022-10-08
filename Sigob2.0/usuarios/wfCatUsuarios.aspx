<%@ Page Title="" Language="C#" MasterPageFile="../MPUsuario.master" AutoEventWireup="true" CodeFile="wfCatUsuarios.aspx.cs" Inherits="usuarios_wfCatUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <script> 
        function pulsar(e) {
            tecla = (document.all) ? e.keyCode : e.which;
            return (tecla != 13);
        }
    </script>
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/modal.css" rel="stylesheet" />

    <div class="row main-titulo">
        USUARIOS
    </div>
    <div class="main-container" id="busqueda" runat="server">
        <div class="title-container">
            <h5>Busqueda del Usuario</h5>
        </div>
        <div class="items-container align-content-center align-items-center align-content-lg-center text-center">
            <div class="row align-content-center align-items-center align-content-lg-center text-center">
                <div class="col-12 col-md-12 col-lg-12">
                    <div class="form-group form-group-default required ">
                        <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Correo Electronico  " Style="text-transform: uppercase;" onkeypress="return pulsar(event)"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12 col-md-12 col-lg-12" style="margin-top: 10px;">
                    <asp:Button ID="Button1" class="btn btn-primary btn-lg" runat="server" Text="Buscar" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" class="btn btn-primary btn-lg" runat="server" Text="Nuevo" OnClick="Button2_Click" Visible="false" />
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>

            </div>
        </div>
    </div>

    <div class="card-container" id="resultado" runat="server">
        <div class="title-container">
            <h5>Resultados</h5>
        </div>
        <div class="items-container">
            <div class="row">
                <asp:GridView BorderWidth="0px" GridLines="None" ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="UsuarioId"
                    HorizontalAlign="Center" PageSize="10" AllowPaging="True" Width="100%" OnRowCommand="GridView1_RowCommand1">
                    <PagerSettings Position="Bottom" Mode="Numeric" FirstPageText="First" LastPageText="Last"
                        NextPageText="Next" PreviousPageText="Prev" />
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" ControlStyle-CssClass="gradeU">
                            <ControlStyle CssClass="gradeU"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="noempleado" HeaderText="No Empleado"></asp:BoundField>
                        <asp:BoundField DataField="correo" HeaderText="Correo"></asp:BoundField>
                        <asp:BoundField DataField="perfil" HeaderText="Perfil"></asp:BoundField>
                        <asp:BoundField DataField="estatus" HeaderText="Estatus"></asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>Editar</HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkver" runat="server" CausesValidation="false" CssClass="btn btn-primary" CommandArgument='<%#Eval("UsuarioId")%>' CommandName="Registrar"> 
                                                     <span><i class="bi bi-pencil-square"></i></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

