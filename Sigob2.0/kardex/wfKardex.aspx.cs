using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class kardex_wfKardex : System.Web.UI.Page
{
    string id;
    public string Titulo { get; set; }
    public string Mensaje { get; set; }
    public string TxtBoton { get; set; }
    public string TxtBotonNo { get; set; }
    public string Iconito { get; set; }
    ws.wsSigob WS = new ws.wsSigob();
    ws.Usuarios p = new ws.Usuarios();
    protected void Page_Load(object sender, EventArgs e)
    {

        Titulo = System.Configuration.ConfigurationManager.AppSettings["Titulo"];
        if (!IsPostBack)
        {

        }
    }

    protected void btnBuscarCurp_Click(object sender, EventArgs e)
    {
        DataTable tresutlados = WS.BusquedaCurp(txtCurp.Text.Trim());
        GridView1.DataSource = tresutlados;
        GridView1.DataBind();
        Button1.Visible = true;
    }

    protected void bntBuscarNom_Click(object sender, EventArgs e)
    {
        DataTable tresutlados = WS.BusquedaNombre(txtNom.Text.Trim(), txtApPat.Text.Trim(), txtApMat.Text.Trim());
        GridView1.DataSource = tresutlados;
        GridView1.DataBind();
        Button1.Visible = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfKardexDatos.aspx?id=" + Funciones.EncriptarAES ("N"));
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
                Response.Redirect("wfKardexDatos.aspx?id=" + Funciones.EncriptarAES(valor));


                break;

        }
    }
}