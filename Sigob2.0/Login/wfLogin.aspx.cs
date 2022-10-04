using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using ws;


public partial class usuarios_wfLogin : System.Web.UI.Page
{
    public string Titulo { get; set; }
    public string Mensaje { get; set; }
    public string TxtBoton { get; set; }
    public string TxtBotonNo { get; set; }
    public string Iconito { get; set; }
    public string dominio { get; set; }

    ws.wsSigob WS = new ws.wsSigob();
    protected void Page_Load(object sender, EventArgs e)
    {
        dominio = System.Configuration.ConfigurationManager.AppSettings["dominio"];
        Titulo = System.Configuration.ConfigurationManager.AppSettings["Titulo"];

        HttpCookie cookiep = Request.Cookies["appTienda"];
        if (cookiep != null)
        {
            cookiep.Expires = DateTime.Now.AddDays(-1);
            cookiep.Value = string.Empty;
            cookiep.Expires = DateTime.Now.AddMinutes(-1);
            Response.Cookies.Add(cookiep);
        }
        Session.Abandon();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "" & TextBox2.Text != "")
        {
            System.Data.DataTable tusua;
            tusua = WS.UsuariosLogin(TextBox1.Text, Funciones.EncriptarAES(TextBox2.Text));
            if ((tusua.Rows.Count > 0))
            {
                tusua = WS.DatosUsuario((TextBox1.Text));
                DataRow row = tusua.Rows[0];

                Session["Login"] = true;
                HttpCookie cookie = Request.Cookies["appTienda"];
                if (cookie == null)
                {
                    cookie = new HttpCookie("appTienda");
                    cookie["UsuarioId"] = row["UsuarioId"].ToString();
                    cookie["PerfilId"] = row["PerfilId"].ToString();
                    cookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("../Default.aspx");
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //System.Data.DataTable tusua;
        //tusua = WS.ClientesBuscaMail(TextBox1.Text);
        //if ((tusua.Rows.Count > 0))
        //{
        //    DataRow row = tusua.Rows[0];
        //    string cuerpo;
        //    const string quote = "\"";
        //    cuerpo =
        //  "<div align=" + quote + "center" + quote + " width=" + quote + "100%" + quote + " style=" + quote + "font-family: Arial, Helvetica, sans-serif;" + quote + ">" +
        //"<table width=" + quote + " 90% " + quote + " bgcolor=" + quote + " #f6f8f1 " + quote + " border=" + quote + " 0" + quote + " cellpadding=" + quote + " 0" + quote + " cellspacing=" + quote + " 0" + quote + ">" +
        //"<tr>" +
        //"<td align=" + quote + "center" + quote + ">" +
        //"<img src=" + quote + ConfigurationManager.AppSettings["dominio"] + "/images/logoj.png" + quote + " width=" + quote + "8%" + quote + " border=" + quote + "0" + quote + " />" +
        //"</td>" +
        //"</tr>" +
        //"<tr>" +
        //"<td>" +
        //"<table align=" + quote + "center" + quote + " border=" + quote + "0" + quote + " cellpadding=" + quote + "25" + quote + " cellspacing=" + quote + "0" + quote + " style=" + quote + "width: 100%;" + quote + ">" +
        //"<tr>" +
        //"<td>" +
        //"<table width=" + quote + "100%" + quote + " border=" + quote + "0" + quote + " cellspacing=" + quote + "0" + quote + " cellpadding=" + quote + "0" + quote + ">" +
        //"<tr>" +
        //"<td align=" + quote + "center" + quote + ">" +
        //"<h1 style=" + quote + "margin-top:10px; margin-bottom:25px; color:#121212; font-size:20px" + quote + ">Hola," + row["Nombre"].ToString() + " " + row["Apellidos"].ToString() + "</h1>" +
        //"</td>" +
        //"</tr>" +
        //"<tr>" +
        //"<td align=" + quote + "center" + quote + ">" +
        //"Necesitamos validar tu cuenta de correo, por favor da click en el siguiente enlace para hacerlo." +
        //"<br /><br />" +
        //"</td>" +
        //"</tr>" +
        //"<tr>" +
        //"<td>" +
        //"<table align=" + quote + "center" + quote + " bgcolor=" + quote + "#e05443" + quote + " border=" + quote + "0" + quote + " cellspacing=" + quote + "0" + quote + " cellpadding=" + quote + "10" + quote + ">" +
        //"<tr>" +
        //"<td height=" + quote + "40" + quote + ">" +
        //"<a href=" + quote + ConfigurationManager.AppSettings["dominio"] + "/clientes/wfclientesvali.aspx?Id=" + Funciones.EncriptarAES(row["ClienteId"].ToString()) + quote + " style=" + quote + "text-decoration:none; color: #ffffff" + quote + "> Validar Correo </ a >" +
        //"</td>" +
        //"</tr>" +
        //"</table>" +
        //"</td>" +
        //"</tr>" +
        //"<tr>" +
        //"<td align=" + quote + "center" + quote + " style=" + quote + "padding-top:15px;" + quote + ">" +
        //"Es importante comentarte que si tienes algun problema con esto por favor escribenos a :" +
        //"</td>" +
        //"</tr>" +
        //"<tr><td align = " + quote + "center" + quote + " style = " + quote + "padding - top:15px; " + quote + ">soporte@joyeria5estrellas.com</td></tr>" +
        //"<tr></tr>" +
        //"</table>" +
        //"</td>" +
        //"</tr>" +
        //"</table>" +
        //"</td>" +
        //"</tr>" +
        //"<tr>" +
        //"<td bgcolor=" + quote + "#44525f" + quote + ">" +
        //"<table width=" + quote + "100%" + quote + " border=" + quote + "0" + quote + " cellspacing=" + quote + "0" + quote + " cellpadding=" + quote + "5" + quote + ">" +
        //"<tr>" +
        //"<td align=" + quote + "center" + quote + " style=" + quote + "font-size:14px; color:#ffffff;" + quote + ">" +
        //"Joyería 5 Estrellas <br />" +
        //"Todos los derechos reservados" +
        //"</td>" +
        //"</tr>" +
        //"<tr>" +
        //"<td align=" + quote + "center" + quote + ">" +
        //"<table border=" + quote + "0" + quote + " cellspacing=" + quote + "0" + quote + " cellpadding=" + quote + "0" + quote + ">" +
        //"<tr>" +
        //"<td width=" + quote + "37" + quote + " style=" + quote + "text-align: center; padding: 0 10px 0 10px;" + quote + ">" +
        //"<a href=" + quote + "#" + quote + ">" +
        //"<img src=" + quote + "https://micartaonline.com.mx/images/lf.png" + quote + " width=" + quote + "31" + quote + " + quote + " + quote + " height=" + quote + "36" + quote + " alt=" + quote + "Facebook" + quote + " border=" + quote + "0" + quote + " />" +
        //"</a>" +
        //"</td>" +
        //"<td width=" + quote + "37" + quote + " style=" + quote + "text-align: center; padding: 0 10px 0 10px;" + quote + ">" +
        //"<a href=" + quote + "#" + quote + ">" +
        //"<img src=" + quote + "https://micartaonline.com.mx/images/lin.png" + quote + " width=" + quote + "31" + quote + " height=" + quote + "36" + quote + " alt=" + quote + "Twitter" + quote + " border=" + quote + "0" + quote + " />" +
        //"</a>" +
        //"</td>" +
        //"</tr>" +
        //"</table>" +
        //"</td>" +
        //"</tr>" +
        //"</table>" +
        //"</td>" +
        //"</tr>" +
        //"</table>" +
        //"</div>";
        //    //string Errores = Funciones.enviamail(TextBox1.Text, "Joyeria 5 estrellas ", cuerpo);
        //    if (Errores == "OK")
        //    {


        //    }
        //    //else Label1.Text = Errores;
        //    //Label1.Visible = true;
        //}

    }
}