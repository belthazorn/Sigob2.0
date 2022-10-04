<%@ Page Title="" Language="C#" MasterPageFile="~/MPUsuario.master" AutoEventWireup="true" CodeFile="01Plantilla.aspx.cs" Inherits="_01Plantilla" %>

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
        --
    </div>
    <div class="main-container" id="busqueda" runat="server">
        <div class="title-container">
            <h5>--</h5>
        </div>
    <div class="items-container">
        <div class="row">
            <div class="col-12 col-lg-6 col-md-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">SKU</label>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="SKU" required autofocus></asp:TextBox>
                </div>            
                <div class="form-group">
                    <label for="exampleInputEmail1">Estatus</label>
                    <asp:CheckBox ID="checkbox1" runat="server" class="form-control" Text="Activo"></asp:CheckBox>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">Prioridad</label>
                    <asp:DropDownList ID="DropDownList1" class="form-control" placeholder="Prioridad" runat="server"></asp:DropDownList>
                </div>                
            </div>
        </div>
        <div class="row">
            <div class="col-12 col-md-12 col-lg-12" style="margin-top: 10px;">
                <asp:Button ID="Button6" runat="server" class="btn btnActualizar btn-lg" CausesValidation="false" Text="Actualizar" OnClick="Button6_Click" OnClientClick="Button6_Click" Visible="True" />
                <asp:Button ID="Button2" runat="server" class="btn btnPrimario btn-lg" CausesValidation="false" Text="Guardar" OnClick="Button2_Click" Visible="True" />
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

