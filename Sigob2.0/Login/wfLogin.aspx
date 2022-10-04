<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfLogin.aspx.cs" Inherits="usuarios_wfLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title><%=Titulo%></title>
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/generales.css" rel="stylesheet" />
    <link href="../css/modal.css" rel="stylesheet" />
    <link href="../css/dashboard.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <style>
        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            user-select: none;
        }

        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }
    </style>
   
</head>
<body style="background-color:#e1e1e1">

    <form id="form1" runat="server">
        <div class="container">
            <div class="m-0 vh-100 row justify-content-center align-middle" style="margin-top: 0px !Important;">
                    <div class="col-12 col-md-6 col-sm-6 align-self-center shadow bg-white">
                        <div class="text-center fw-bold fs-4">
                            <a href="<%=dominio%>/index.aspx">
                                <img src="images/texier-logo.svg" alt="" style="max-width: 200px; width: 100%; height: auto;"></a>
                            <br />
                        </div>
                        <div class="text-center fs-6">
                            Inicie sesión con su ID del sistema
                        </div>
                        <div class="p-3">
                            <div class="form-group">
                                <label for="exampleInputEmail1">Nombre</label>
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Usuario" required autofocus></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Nombre</label>
                                <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Contraseña" required TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="text-end fw-3 fs-6 pt-3 pb-3">
                                <a style="text-decoration-color: black; color: black;" href="#">¿Ha olvidado su contraseña?</a>
                            </div>
                            <div class="d-grid gap-2 pt-2 pb-2">
                                <asp:Button ID="Button1" runat="server" Text="INICIAR SESIÓN" class="btn bottonlogin" OnClick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                </div>


            <div class ="shadow">
                
            </div>
            


        </div>





        <div class="modal fade" id="modalSlideUp" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #153d77 !important; color: white;">
                        <h5 class="modal-title" id="modalSlideUpLabel"><%=Titulo%></h5>
                        <button type="button" class="btn-close btn-close-white" data-dismiss="modal" aria-label="Close">
                            <%--<i class="bi bi-x-circle"></i>--%>
                        </button>
                    </div>
                    <div class="rmodal-body">
                        <p class="bold">&nbsp<i class="<%=Iconito%>"></i>&nbsp <%=Mensaje%></p>
                    </div>
                    <div class="modal-footer" style="background-color: #f4f7fc;">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" runat="server" id="Button3"><%=TxtBoton%></button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" runat="server" id="Button2" onserverclick="Button2_Click">Reenviar</button>
                        <button type="button" class="btn btn-info" data-dismiss="modal" runat="server" id="Button5">Crear</button>

                    </div>
                </div>
            </div>
        </div>


        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ" crossorigin="anonymous"></script>
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    </form>
</body>
</html>
