using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class usuarios_index : System.Web.UI.Page
{
    public string TotalIngresosAlmacen { get; set; }
    public string TotalIngresosAlmacenPorConfi { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //HttpCookie cookiep = Request.Cookies["appTienda"];
            //if (cookiep != null)
            //{
            //    //salidas confirmadas
            //    DataTable ttotalalmacen = Funciones.AlmacenTotalIngresosMes(DateTime.Now.Month, DateTime.Now.Year);
            //    DataRow row = ttotalalmacen.Rows[0];
            //    TotalIngresosAlmacen = row[0].ToString();

            //    //salidas noconfirmadas
            //     ttotalalmacen = Funciones.AlmacenTotalIngresosMesPorConfir(DateTime.Now.Month, DateTime.Now.Year);
            //     row = ttotalalmacen.Rows[0];
            //    TotalIngresosAlmacenPorConfi = row[0].ToString();

            //}
            //else
            //{
            //    Response.Redirect("wfLogin.aspx");
            //}

        }
    }
}