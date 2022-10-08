<%@ Page Title="" Language="C#" MasterPageFile="~/MPUsuario.master" AutoEventWireup="true" CodeFile="wfKardex.aspx.cs" Inherits="kardex_wfKardex" %>

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
            KARDEX
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
                        <asp:TextBox ID="txtCurp" runat="server" class="form-control" placeholder="CURP"  Style="text-transform: uppercase;"></asp:TextBox>
                        <asp:Button ID="btnBuscarCurp" class="btn btn-primary btn-lg" runat="server" Text="Buscar" OnClick="btnBuscarCurp_Click" />
                    </div>
                </div>
                <div class="col-12 col-lg-8 col-md-8">
                    <div class="container-fluid">
                        <div class="form-group">
                            <label for="exampleInputEmail1">NOMBRE</label>
                            <asp:TextBox ID="txtNom" class="form-control" runat="server" placeholder="Nombre" Style="text-transform: uppercase;"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">PATERNO</label>
                            <asp:TextBox ID="txtApPat" class="form-control" runat="server" placeholder="Apellido Paterno" Style="text-transform: uppercase;"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">MATERNO</label>
                            <asp:TextBox ID="txtApMat" class="form-control" runat="server" placeholder="Apellido Materno" Style="text-transform: uppercase;"></asp:TextBox>
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
        <div class="container">
            <div class="row col-12">
                <asp:Button ID="Button1" class="btn btn-primary btn-lg" runat="server" Text="Nuevo" OnClick="Button1_Click" Visible ="false"/>
            </div>
        </div>
    </div>    


</asp:Content>

