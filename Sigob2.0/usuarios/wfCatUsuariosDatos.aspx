<%@ Page Title="" Language="C#" MasterPageFile="../MPUsuario.master" AutoEventWireup="true" CodeFile="wfCatUsuariosDatos.aspx.cs" Inherits="usuarios_wfCatUsuariosDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script> 
        function pulsar(e) {
            tecla = (document.all) ? e.keyCode : e.which;
            return (tecla != 13);
        }
    </script>
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/modal.css" rel="stylesheet" />
    <div class="row main-titulo">
        ALTA DE USUARIO
    </div>
    <div class="main-container" id="busqueda" runat="server">
        <div class="title-container">
            <h5>Busqueda Empleado</h5>
        </div>
        <div class="items-container">
            <div class="row">
                <div class="col-12 col-lg-4 col-md-4">
                    <div class="form-group">
                        <label for="exampleInputEmail1">CURP</label>
                        <asp:TextBox ID="txtCurp" runat="server" class="form-control" placeholder="CURP"></asp:TextBox>
                        <asp:Button ID="btnBuscarCurp" class="btn btn-primary btn-lg" runat="server" Text="Buscar" OnClick="btnBuscarCurp_Click" />
                    </div>
                </div>
                <div class="col-12 col-lg-8 col-md-8">
                    <div class="container-fluid">
                        <div class="form-group">
                            <label for="exampleInputEmail1">NOMBRE</label>
                            <asp:TextBox ID="txtNom" class="form-control" runat="server" placeholder="Nombre"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">PATERNO</label>
                            <asp:TextBox ID="txtApPat" class="form-control" runat="server" placeholder="Apellido Paterno"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">MATERNO</label>
                            <asp:TextBox ID="txtApMat" class="form-control" runat="server" placeholder="Apellido Materno"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="bntBuscarNom" class="btn btn-primary btn-lg" runat="server" Text="Buscar" OnClick="bntBuscarNom_Click" />
                </div>
            </div>
        </div>
        <div class="divespacio"></div>
        <div class="container">
            <div class="items-container">
                <div class="row">
                    <asp:GridView BorderWidth="0px" GridLines="None" ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="Id"
                        HorizontalAlign="Center" PageSize="20" AllowPaging="True" Width="100%" OnRowCommand="GridView1_RowCommand1" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <PagerSettings Position="Bottom" Mode="Numeric" FirstPageText="First" LastPageText="Last"
                            NextPageText="Next" PreviousPageText="Prev" />
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre"></asp:BoundField>
                            <asp:BoundField DataField="Paterno" HeaderText="Paterno"></asp:BoundField>
                            <asp:BoundField DataField="Materno" HeaderText="Materno"></asp:BoundField>
                            <asp:BoundField DataField="CURP" HeaderText="CURP"></asp:BoundField>
                            <asp:TemplateField>
                                <HeaderTemplate>Crear</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkver" runat="server" CausesValidation="false" CssClass="btn btn-primary" CommandArgument='<%#Eval("Id")%>' CommandName="Crear"> 
                                 <span><i class="bi bi-pencil-square"></i></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <div class="main-container">
        <div class="items-container" id="usuariodatos" runat="server" visible ="false">
            <div class="row">
                <div class="col-12 col-lg-6 col-md-6">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Nombre</label>
                        <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Nombre" required autofocus Style="text-transform: uppercase;"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Correo</label>
                        <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Correo" required autofocus Style="text-transform: lowercase;"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Perfil</label>
                        <asp:DropDownList ID="DropDownList1" class="form-control" placeholder="Perfil" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">                        
                        <asp:CheckBox ID="CheckBox1" runat="server" value="Activo"/>
                        <label for="exampleInputEmail1">Activo</label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12 col-md-12 col-lg-12" style="margin-top: 10px;">
                <asp:Button ID="Button6" runat="server" class="btn btn-primary btn-lg" causesvalidation="false" Text="Actualizar" OnClick="Button6_Click" OnClientClick="Button6_Click" Visible="True" />
                <asp:Button ID="Button2" runat="server" class="btn btn-primary btn-lg" causesvalidation="false" Text="Guardar" OnClick="Button2_Click" Visible="True" />
                </div>
                
            </div>
        </div>
    </div>

    <div class="modal fade" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" id="modalSlideUp" aria-labelledby="staticBackdropLabel" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header" style ="background-color:#6f4220; color:white;">
                    <h5 class="modal-title" id="staticBackdropLabel"><%=Titulo%></h5>
                    <button type="button" class="btn-close btn-close-white" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <div class="rmodal-body">
                    <p class="bold"><i class="<%=Iconito%>"></i>&nbsp <%=Mensaje%></p>
                </div>
                <div class="modal-footer bakcmenu">
                    <asp:Button ID="Button3" runat="server" class="btn btnPrimario"  causesvalidation="false" Text="OK" OnClick="Button3_Click" Visible="True" />
                    <button type="button" class="btn btnActualizar btn-lg" data-dismiss="modal" runat="server" id="Button5"><%=TxtBotonNo%></button>
                </div>
            </div>
        </div>
    </div>  
</asp:Content>
