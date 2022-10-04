using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.Services;

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
                        
                        DropDownList1.SelectedValue = row["PerfilId"].ToString(); ;
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
        //if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox4.Text != "")
        //{
        //    p.UsuarioId = Request.QueryString["Id"].Replace(" ", "+");

        //    p.NombreCompletoUsuario = TextBox1.Text.ToUpper();
        //    p.Paterno = TextBox2.Text.ToUpper();
        //    p.Materno = TextBox3.Text.ToUpper();
        //    p.usuario = TextBox6.Text.ToUpper();
        //    p.PerfilId = DropDownList1.SelectedValue;            
        //    p.correo = TextBox4.Text.ToLower();
        //    if (checkbox1.Checked == true)
        //    {
        //        p.Estatus = true;
        //    }
        //    else p.Estatus = false;
        //    Session["UsuarioId"] = p.UsuarioId;
        //    string errores = WS.UsuariosActualiza(p);
        //    if (errores == "OK")
        //    {
        //        Titulo = "MiTiendaOnline";
        //        Mensaje = "Los datos se han guardado correctamente";
        //        TxtBoton = "OK";
        //        Iconito = "bi bi-check-circle";
        //        Button5.Visible = false;
        //        Button3.Visible = true;
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "modalSlideUp", "$('#modalSlideUp').modal('show');", true);
        //    }
        //    else
        //    {
        //        Titulo = "MiTiendaOnline";
        //        Mensaje = errores;
        //        TxtBotonNo = "CERRAR";
        //        Iconito = "bi bi-x-circle";
        //        Button5.Visible = true;
        //        Button3.Visible = false;
        //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSlideUp", "$('#modalSlideUp').modal();", true);
        //    }
        //}
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Server.Transfer("../Index.aspx");
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        //if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox4.Text != "")
        //{
        p.UsuarioId = Guid.NewGuid().ToString();
        p.EmpeladoId = Session["EmpleadoId"].ToString();
        p.PerfilId = DropDownList1.SelectedValue;
        p.Contraseña = Funciones.EncriptarAES(WS.generapass());
        p.correo = TextBox1.Text.ToLower();
        p.Estatus = true;
        p.Actualiza ="0";
        string errores = WS.UsuariosAlta(p);
        if (errores == "OK")
        {
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
}