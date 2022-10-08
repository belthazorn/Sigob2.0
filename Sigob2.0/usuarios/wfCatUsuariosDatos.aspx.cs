using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.Services;
using System.Configuration;

public partial class usuarios_wfCatUsuariosDatos : System.Web.UI.Page
{
    
    string id;
    public string Titulo { get; set; }
    public string Mensaje { get; set; }
    public string TxtBoton { get; set; }
    public string TxtBotonNo { get; set; }
    public string Iconito { get; set; }
    ws.wsSigob WS = new ws.wsSigob();
    ws.Usuarios p = new ws.Usuarios();


    
    protected void btnBuscarCurp_Click(object sender, EventArgs e)
    {
        DataTable tresutlados = WS.BusquedaCurp(txtCurp.Text.Trim());
        GridView1.DataSource = tresutlados;
        GridView1.DataBind();

    }

    protected void bntBuscarNom_Click(object sender, EventArgs e)
    {
        DataTable tresutlados = WS.BusquedaNombre(txtNom.Text.Trim(), txtApPat.Text.Trim(), txtApMat.Text.Trim());
        GridView1.DataSource = tresutlados;
        GridView1.DataBind();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Titulo = System.Configuration.ConfigurationManager.AppSettings["Titulo"];
        if (!IsPostBack)
        {
            try
            {
                id = Request.QueryString["Id"].Replace(" ", "+");
                DropDownList1.DataSource = WS.ComboPerfiles();
                DropDownList1.DataValueField = "PerfilId";
                DropDownList1.DataTextField = "Perfil";
                DropDownList1.Items.Insert(0, "-SELECCIONA-");
                DropDownList1.DataBind();

                if (id != "N")
                {
                    Session["UsuarioId"] = id;
                    DataTable Usuarios;
                    Usuarios = WS.DatosUsuarioid(id);
                    if (Usuarios.Rows.Count == 1)
                    {
                        DataRow row = Usuarios.Rows[0];
                        string nombre = row["nombre"].ToString();
                        TextBox2.Text = nombre;
                        TextBox2.ReadOnly = true;
                        TextBox1.Text = row["correoins"].ToString();
                        TextBox1.ReadOnly = true;
                        DropDownList1.SelectedValue = row["PerfilId"].ToString(); ;
                        CheckBox1.Checked = Convert.ToBoolean(row["Estatus"]);
                        busqueda.Visible = false;
                        usuariodatos.Visible = true;
                        Button6.Visible = true;
                        Button2.Visible = false;
                    }
                }
                else
                {
                    Button6.Visible = false;
                    Button2.Visible = true;
                }
            }
            catch
            {
                Response.Redirect("../login/wfLogin.aspx");
            }

        }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        
        p.UsuarioId = Request.QueryString["Id"].Replace(" ", "+");
        p.PerfilId = DropDownList1.SelectedValue;        
        p.correo = TextBox1.Text.ToLower();
        p.Estatus = CheckBox1.Checked;        
        string errores = WS.UsuariosActualiza(p);
        if (errores == "OK")
        {
            Titulo = Titulo;
            Mensaje = "Los datos se han actualizado correctamente";
            TxtBoton = "OK";
            Iconito = "bi bi-check-circle";
            Button2.Visible = false;
            Button6.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modalSlideUp", "$('#modalSlideUp').modal('show');", true);
        }
        else
        {
            Titulo = Titulo;
            Mensaje = errores;
            TxtBoton = "CERRAR";
            Iconito = "bi bi-x-circle";
            Button6.Visible = false;
            Button2.Visible = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSlideUp", "$('#modalSlideUp').modal();", true);
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Server.Transfer("../Index.aspx");
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        //busca si el correo no esta registrado
        DataTable tresultados = WS.DatosUsuariomail(Funciones.EncriptarAES(TextBox1.Text));
        if(tresultados.Rows.Count == 0)
        {
            p.UsuarioId = Guid.NewGuid().ToString();
            p.EmpeladoId = Session["EmpleadoId"].ToString();
            p.PerfilId = DropDownList1.SelectedValue;
            p.Contraseña = Funciones.EncriptarAES(WS.generapass());
            p.correo = TextBox1.Text.ToLower();
            p.Estatus = true;
            p.Actualiza = "0";
            string errores = WS.UsuariosAlta(p);
            if (errores == "OK")
            {
                envia(TextBox2.Text, p.Contraseña, p.correo);
                Titulo = Titulo;
                Mensaje = "Los datos se han guardado correctamente";
                TxtBoton = "OK";
                Iconito = "bi bi-check-circle";
                Button2.Visible = false;
                Button6.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modalSlideUp", "$('#modalSlideUp').modal('show');", true);
            }
            else
            {
                Titulo = Titulo;
                Mensaje = errores;
                TxtBoton = "CERRAR";
                Iconito = "bi bi-x-circle";
                Button6.Visible = false;
                Button2.Visible = true;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSlideUp", "$('#modalSlideUp').modal();", true);
            }
        }
        else
        {
            Titulo = Titulo;
            Mensaje = "Este correo ya esta registrado";
            TxtBoton = "CERRAR";
            Iconito = "bi bi-x-circle";
            Button6.Visible = false;
            Button2.Visible = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSlideUp", "$('#modalSlideUp').modal();", true);
        }

        
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = Session["Resultados"];
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {

    }

   protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        string valor = Convert.ToString(e.CommandArgument);
        switch (e.CommandName)
        {
            case "Crear":
                //Response.Redirect("wfClientesDatos.aspx?id=" + Funciones.EncriptarAES(valor));
                //checar si el usuario existe para no crearlo de nuevo
                DataTable tresultados = WS.UsuariosBuscaEmleado(valor);
                if (tresultados.Rows.Count == 0)
                {
                    //extrae el correo del empleado
                    tresultados = WS.KardexRegresaMail(valor);
                    DataRow row = tresultados.Rows[0];
                    TextBox2.Text = row["Nombre"].ToString() + " " + row["Paterno"].ToString() + " " + row["Materno"].ToString();
                    TextBox1.Text = row["correoins"].ToString();
                    
                    usuariodatos.Visible = true;
                    Button2.Visible = true;
                    Session["EmpleadoId"] = valor;
                    busqueda.Visible = false;
                }
                else
                {
                    Titulo = System.Configuration.ConfigurationManager.AppSettings["Titulo"];
                    Mensaje = "ESTA PERSONA YA TIENE UN USUARIO CREADO";
                    TxtBoton = "CERRAR";
                    Iconito = "bi bi-x-circle";
                    Button5.Visible = false;
                    Button3.Visible = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSlideUp", "$('#modalSlideUp').modal();", true);
                }

                break;

        }
    }


    void envia(string nombre, string contraseña, string correo)
    {
        string cuerpo;
        const string quote = "\"";
        cuerpo =
      "<div align=" + quote + "center" + quote + " width=" + quote + "100%" + quote + " style=" + quote + "font-family: Arial, Helvetica, sans-serif;" + quote + ">" +
    "<table width=" + quote + " 90% " + quote + " bgcolor=" + quote + " #f6f8f1 " + quote + " border=" + quote + " 0" + quote + " cellpadding=" + quote + " 0" + quote + " cellspacing=" + quote + " 0" + quote + ">" +
    "<tr>" +
    "<td align=" + quote + "center" + quote + ">" +
    "<img src=" + quote + ConfigurationManager.AppSettings["dominio"] + "/images/logoj.png" + quote + " width=" + quote + "8%" + quote + " border=" + quote + "0" + quote + " />" +
    "</td>" +
    "</tr>" +
    "<tr>" +
    "<td>" +
    "<table align=" + quote + "center" + quote + " border=" + quote + "0" + quote + " cellpadding=" + quote + "25" + quote + " cellspacing=" + quote + "0" + quote + " style=" + quote + "width: 100%;" + quote + ">" +
    "<tr>" +
    "<td>" +
    "<table width=" + quote + "100%" + quote + " border=" + quote + "0" + quote + " cellspacing=" + quote + "0" + quote + " cellpadding=" + quote + "0" + quote + ">" +
    "<tr>" +
    "<td align=" + quote + "center" + quote + ">" +
    "<h1 style=" + quote + "margin-top:10px; margin-bottom:25px; color:#121212; font-size:20px" + quote + ">Hola," + nombre + "</h1>" +
    "</td>" +
    "</tr>" +
    "<tr>" +
    "<td align=" + quote + "center" + quote + ">" +
    "Esta es la contraseña para tu acceso a SIGOB: " + contraseña  + 
    "<br /><br />" +
    "</td>" +
    "</tr>" +
    "<tr>" +
    "<td>" +    
    "</td>" +
    "</tr>" +
    "<tr>" +
    "<td align=" + quote + "center" + quote + " style=" + quote + "padding-top:15px;" + quote + ">" +
    "Es importante comentarte que si tienes algun problema con esto por favor escribenos a :" +
    "</td>" +
    "</tr>" +
    "<tr><td align = " + quote + "center" + quote + " style = " + quote + "padding - top:15px; " + quote + ">soporte@scsiscoluciones.com</td></tr>" +
    "<tr></tr>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "<tr>" +
    "<td bgcolor=" + quote + "#44525f" + quote + ">" +
    "<table width=" + quote + "100%" + quote + " border=" + quote + "0" + quote + " cellspacing=" + quote + "0" + quote + " cellpadding=" + quote + "5" + quote + ">" +
    "<tr>" +
    "<td align=" + quote + "center" + quote + " style=" + quote + "font-size:14px; color:#ffffff;" + quote + ">" +
    "Municipio de Celaya / SSC <br />" +
    "Todos los derechos reservados" +
    "</td>" +
    "</tr>" +
    "<tr>" +
    "<td align=" + quote + "center" + quote + ">" +
    "<table border=" + quote + "0" + quote + " cellspacing=" + quote + "0" + quote + " cellpadding=" + quote + "0" + quote + ">" +
    "<tr>" +
    "<td width=" + quote + "37" + quote + " style=" + quote + "text-align: center; padding: 0 10px 0 10px;" + quote + ">" +
    "<a href=" + quote + "#" + quote + ">" +
    "<img src=" + quote + "https://micartaonline.com.mx/images/lf.png" + quote + " width=" + quote + "31" + quote + " + quote + " + quote + " height=" + quote + "36" + quote + " alt=" + quote + "Facebook" + quote + " border=" + quote + "0" + quote + " />" +
    "</a>" +
    "</td>" +
    "<td width=" + quote + "37" + quote + " style=" + quote + "text-align: center; padding: 0 10px 0 10px;" + quote + ">" +
    "<a href=" + quote + "#" + quote + ">" +
    "<img src=" + quote + "https://micartaonline.com.mx/images/lin.png" + quote + " width=" + quote + "31" + quote + " height=" + quote + "36" + quote + " alt=" + quote + "Twitter" + quote + " border=" + quote + "0" + quote + " />" +
    "</a>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "</table>" +
    "</div>";
        string Errores = Funciones.enviamail(correo, "Contraseña SIGOB ", cuerpo);
    }
}