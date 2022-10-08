<%@ Page Title="" Language="C#" MasterPageFile="~/MPUsuario.master" AutoEventWireup="true" CodeFile="wfKardexDatos.aspx.cs" Inherits="kardex_wfKardexDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script> 
        function pulsar(e) {
            tecla = (document.all) ? e.keyCode : e.which;
            return (tecla != 13);
        }
    </script>
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/modal.css" rel="stylesheet" />

    <div class="row main-titulo">
        DATOS DEL PERSONAL
    </div>
    <div class="main-container" id="busqueda" runat="server">
        <div class="title-container">
            <h5>Datos Generales</h5>
        </div>
        <div class="items-container">
            <div class="row gx-5 mt-4 mb-4">
                <div class="col">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Datos generales</h5>                                                        
                            <div class="form-group">                                                                                                
                                <asp:TextBox ID="txtInsNom" CssClass="txtBox" runat="server" placeholder="Nombre" required></asp:TextBox>
                                <asp:TextBox ID="txtInsApPat" CssClass="txtBox" runat="server" placeholder="Apellido Paterno" required></asp:TextBox>
                                <asp:TextBox ID="txtInsApMat" CssClass="txtBox" runat="server" placeholder="Apellido Materno"></asp:TextBox>
                                <asp:TextBox ID="txtInsCurp" CssClass="txtBox" runat="server" placeholder="CURP" required></asp:TextBox>
                                <asp:TextBox ID="txtRfc" CssClass="txtBox" runat="server" placeholder="RFC"></asp:TextBox>
                                <asp:DropDownList ID="DropDownList1" class="form-control" placeholder="Sexo" runat="server"></asp:DropDownList>
                                <asp:DropDownList ID="DropDownList2" class="form-control" placeholder="Edo Civil" runat="server"></asp:DropDownList>
                                <asp:TextBox ID="txtFecNac" CssClass="txtBox" runat="server" TextMode="Date" required></asp:TextBox>
                                <asp:TextBox ID="txtCorreoInst" CssClass="txtBox" runat="server" TextMode="Email" placeholder="correo@institucional.com" required></asp:TextBox>
                                <asp:TextBox ID="txtCorreoPer" CssClass="txtBox" runat="server" TextMode="Email" placeholder="correo@micorreo.com"></asp:TextBox>
                                <asp:TextBox ID="txtTelInst" CssClass="txtBox" runat="server" TextMode="Phone" placeholder=""></asp:TextBox>
                                <asp:TextBox ID="txtTelPer" CssClass="txtBox" runat="server" TextMode="Phone" placeholder="" required></asp:TextBox>
                                <asp:DropDownList ID="DropDownList3" class="form-control" placeholder="TipoSangre" runat="server"></asp:DropDownList>
                                <asp:TextBox ID="txtLicTipo" CssClass="txtBox" runat="server" placeholder="Tipo de licencia"></asp:TextBox>
                                <asp:TextBox ID="txtLicNum" CssClass="txtBox" runat="server" placeholder="Numero de licencia"></asp:TextBox>
                                <asp:TextBox ID="txtLicVenc" CssClass="txtBox" runat="server" TextMode="Date" ></asp:TextBox>
                                <asp:TextBox ID="txtDepEco" CssClass="txtBox" runat="server" placeholder="Nuemo de dependientes economicos"></asp:TextBox>
                                <asp:TextBox ID="txtNss" CssClass="txtBox" runat="server" placeholder="Nuemo de seguro social"></asp:TextBox>
                                <asp:TextBox ID="txtFecIng" CssClass="txtBox" runat="server" TextMode="Date"></asp:TextBox>
                                <asp:TextBox ID="txtNumExp" CssClass="txtBox" runat="server" placeholder="Nuemo de empleado" required></asp:TextBox>
                                <asp:TextBox ID="txtCveElect" CssClass="txtBox" runat="server" placeholder="Clave de elector"></asp:TextBox>
                                <asp:DropDownList ID="DropDownList4" class="form-control" placeholder="Estatus" runat="server"></asp:DropDownList>
                                <asp:TextBox ID="txtBeneficiario" CssClass="txtBox" runat="server" placeholder="Beneficiario"></asp:TextBox>
                            </div>
                            <br />
                            <asp:Button ID="Button1" runat="server" class="btn btnPrimario btn-lg" CausesValidation="false" Text="Guardar" OnClick="Button1_Click" Visible="False" />
                            <asp:Button ID="Button2" runat="server" class="btn btnPrimario btn-lg" CausesValidation="false" Text="Actualizar" OnClick="Button2_Click" Visible="False" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12 col-md-12 col-lg-12" style="margin-top: 10px;">
                    <%--<asp:Button ID="Button6" runat="server" class="btn btnActualizar btn-lg" CausesValidation="false" Text="Actualizar" OnClick="Button6_Click" OnClientClick="Button6_Click" Visible="True" />
                    <asp:Button ID="Button2" runat="server" class="btn btnPrimario btn-lg" CausesValidation="false" Text="Guardar" OnClick="Button2_Click" Visible="True" />--%>
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
                    <%--<asp:Button ID="Button3" runat="server" class="btn btnPrimario"  causesvalidation="false" Text="OK" OnClick="Button3_Click" Visible="True" />--%>
                    <button type="button" class="btn btnActualizar btn-lg" data-dismiss="modal" runat="server" id="Button5"><%=TxtBotonNo%></button>
                </div>
            </div>
        </div>
    </div>  
</asp:Content>

