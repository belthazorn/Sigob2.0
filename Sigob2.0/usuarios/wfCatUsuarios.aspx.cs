using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ws;

public partial class usuarios_wfCatUsuarios : System.Web.UI.Page
{
    ws.wsSigob WS = new ws.wsSigob();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //HttpCookie cookiep = Request.Cookies["appTienda"];
            //if (cookiep != null)
            //{
                DataTable resultados;
                resultados = WS.UsuariosGrid();
                GridView1.DataSource = resultados;
                GridView1.DataBind();
            //}
            //else
            //{
            //    Response.Redirect("../login/wfLogin.aspx");
            //}

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable resultados;
        Button2.Visible = false;
        if (TextBox1.Text != "")
        {
            resultados = WS.UsuariosBuscaNombre(TextBox1.Text.Trim());
            GridView1.DataSource = resultados;
            GridView1.DataBind();

            if (resultados.Rows.Count == 0) Button2.Visible = true;
            else Button2.Visible = false;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfCatUsuariosDatos.aspx?id=N");
    }

    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        string valor = Convert.ToString(e.CommandArgument);
        switch (e.CommandName)
        {
            case "Registrar":
                Response.Redirect("wfCatUsuariosDatos.aspx?id=" + valor);
                break;
            case "Remover":

                return;
        }
    }
}