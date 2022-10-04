using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class usuarios_MPUsuario : System.Web.UI.MasterPage
{
    public string Alumno { get; set; }
    public string Matricula { get; set; }
    public string Titulo { get; set; }
    public string Mensaje { get; set; }
    public string TxtBoton { get; set; }
    public string TxtBotonNo { get; set; }
    public string Iconito { get; set; }
    public string dominio { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        dominio = System.Configuration.ConfigurationManager.AppSettings["dominio"];
        Titulo = System.Configuration.ConfigurationManager.AppSettings["Titulo"];
        //HttpCookie cookiep = Request.Cookies["appTienda"];
        //if (cookiep != null)
        //{
        //    DataTable tusuarios = Funciones.DatosUsuarioid(cookiep["UsuarioId"].ToString());
        //    DataRow row = tusuarios.Rows[0];

        //    Alumno = row["NombreCompletoUsuario"].ToString() + " " + row["PATERNO"].ToString() + " " + row["MATERNO"].ToString();
        //    //Matricula = row["Matricula"].ToString();
        //}
        //else
        //{
        //    Response.Redirect("wfLogin.aspx");
        //}

    }
}
