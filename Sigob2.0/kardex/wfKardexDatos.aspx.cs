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

public partial class kardex_wfKardexDatos : System.Web.UI.Page
{

    string id;
    public string Titulo {  get; set; }
    public string Mensaje { get; set; }
    public string TxtBoton { get; set; }
    public string TxtBotonNo { get; set; }
    public string Iconito { get; set; }
    ws.wsSigob WS = new ws.wsSigob();
    ws.kardex  p = new ws.kardex();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                id =Funciones.DesencriptarAES(Request.QueryString["Id"].Replace(" ", "+"));
                DropDownList1.DataSource = WS.ComboSexo();
                DropDownList1.DataValueField = "SexoId";
                DropDownList1.DataTextField = "Sexo";
                DropDownList1.Items.Insert(0, "-SELECCIONA-");
                DropDownList1.DataBind();

                DropDownList2.DataSource = WS.ComboEdocivil();
                DropDownList2.DataValueField = "EdoCivilId";
                DropDownList2.DataTextField = "EdoCivil";
                DropDownList2.Items.Insert(0, "-SELECCIONA-");
                DropDownList2.DataBind();

                DropDownList3.DataSource = WS.ComboTipoSangre();
                DropDownList3.DataValueField = "TipoSangreId";
                DropDownList3.DataTextField = "TipoSangre";
                DropDownList3.Items.Insert(0, "-SELECCIONA-");
                DropDownList3.DataBind();


                DropDownList4.DataSource = WS.ComboEstatusKardex();
                DropDownList4.DataValueField = "EstatusId";
                DropDownList4.DataTextField = "EstatusD";
                DropDownList4.Items.Insert(0, "-SELECCIONA-");
                DropDownList4.DataBind();

                //si es un existente
                if (id != "N")
                {
                    Session["Id"] = id;
                    DataTable Usuarios;
                    //regresa los datos del empleado
                    Usuarios = WS.KardexRegresaMail(id);
                    if (Usuarios.Rows.Count == 1)
                    {
                        DataRow row = Usuarios.Rows[0];
                        txtInsNom.Text= row["nombre"].ToString();
                        txtInsApPat.Text = row["Paterno"].ToString();
                        txtInsApMat.Text = row["Materno"].ToString();
                        txtInsCurp.Text = row["CURP"].ToString();
                        txtRfc.Text = row["RFC"].ToString();
                        DropDownList1.SelectedValue = row["Sexo"].ToString();
                        DropDownList1.SelectedValue = row["EstadoCivil"].ToString();
                        txtFecNac.Text = string.Format("{0:yyyy-MM-dd}",row["FechaNacimiento"]);
                        txtCorreoInst.Text = row["correoins"].ToString();
                        txtCorreoPer.Text = row["correoper"].ToString();


                        txtTelPer.Text = row["celuarp"].ToString();
                        txtTelInst.Text = row["celularof"].ToString();
                        DropDownList3.SelectedValue  = row["tiposangre"].ToString();
                        txtLicTipo.Text = row["licenciatipo"].ToString();
                        txtLicNum.Text = row["licencianumero"].ToString();
                        txtLicVenc.Text = string.Format("{0:yyyy-MM-dd}", row["licenciafin"]);
                        txtDepEco.Text = row["dependientes"].ToString();
                        txtNss.Text = row["nss"].ToString();
                        txtFecIng.Text = string.Format("{0:yyyy-MM-dd}", row["fechaingreso"]);
                        txtNumExp.Text = row["noempleado"].ToString();
                        txtCveElect.Text = row["claveelector"].ToString();
                        DropDownList4.SelectedValue = row["estatus"].ToString();
                        


                        Button1.Visible = false;
                        Button2.Visible = true;
                    }
                }
                else
                {
                    Button2.Visible = false;
                    Button1.Visible = true;
                }
            }
            catch
            {
                Response.Redirect("../login/wfLogin.aspx");
            }

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtInsNom.Text != "" && txtInsApPat.Text != "" && txtInsCurp.Text != "")
        {
            p.Id = Guid.NewGuid().ToString();
            p.Nombre = txtInsNom.Text.ToUpper();
            p.Paterno = txtInsApPat.Text.ToUpper();
            p.Materno = txtInsApMat.Text.ToUpper();
            p.FechaNacimiento = Convert.ToDateTime(txtFecNac.Text);
            p.RFC = txtRfc.Text.ToUpper();
            p.CURP = txtInsCurp.Text.ToUpper();
            p.SEXO = DropDownList1.SelectedValue;
            p.correoins = txtCorreoInst.Text.ToUpper();
            p.correoper = txtCorreoPer.Text.ToUpper();
            p.estadocivil = Convert.ToInt16(DropDownList2.SelectedValue);
            p.celuarp = txtTelPer.Text.ToUpper();
            p.celularof = txtTelInst.Text.ToUpper();
            p.tiposangre = Convert.ToInt32(DropDownList3.SelectedValue);
            p.licenciatipo = txtLicTipo.Text.ToUpper();
            p.licencianumero = txtLicNum.Text.ToUpper();
            p.licenciafin = Convert.ToDateTime(txtLicVenc.Text);
            p.dependientes = Convert.ToInt32(txtDepEco.Text);
            p.nss = txtNss.Text.ToUpper();
            p.fechaingreso = Convert.ToDateTime(txtFecIng.Text);
            p.noempleado = txtNumExp.Text.ToUpper();
            p.claveelector = txtCveElect.Text.ToUpper();
            p.estatus = Convert.ToInt32(DropDownList4.SelectedValue);
            p.beneficiario = txtBeneficiario.Text.ToUpper();
            string errores = WS.KardexAlta(p);

            if (errores == "OK")
            {
                Titulo = Titulo;
                Mensaje = "Los datos se han guardado correctamente";
                TxtBoton = "OK";
                Iconito = "bi bi-check-circle";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modalSlideUp", "$('#modalSlideUp').modal('show');", true);
            }
            else
            {
                Titulo = Titulo;
                Mensaje = errores;
                TxtBoton = "CERRAR";
                Iconito = "bi bi-x-circle";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSlideUp", "$('#modalSlideUp').modal();", true);
            }

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        if (txtInsNom.Text != "" && txtInsApPat.Text != "" && txtInsCurp.Text != "")
        {
            p.Id = Funciones.DesencriptarAES(Request.QueryString["Id"].Replace(" ", "+"));
            p.Nombre = txtInsNom.Text.ToUpper();
            p.Paterno = txtInsApPat.Text.ToUpper();
            p.Materno = txtInsApMat.Text.ToUpper();
            p.FechaNacimiento =Convert.ToDateTime(txtFecNac.Text);
            p.RFC = txtRfc.Text.ToUpper();
            p.CURP = txtInsCurp.Text.ToUpper();
            p.SEXO = DropDownList1.SelectedValue ;
            p.correoins = txtCorreoInst.Text.ToUpper();
            p.correoper = txtCorreoPer.Text.ToUpper();
            p.estadocivil =Convert.ToInt16(DropDownList2.SelectedValue);
            p.celuarp = txtTelPer.Text.ToUpper();
            p.celularof = txtTelInst.Text.ToUpper();
            p.tiposangre = Convert.ToInt32(DropDownList3.SelectedValue);
            p.licenciatipo = txtLicTipo.Text.ToUpper();
            p.licencianumero = txtLicNum.Text.ToUpper();
            p.licenciafin =Convert.ToDateTime(txtLicVenc.Text);
            p.dependientes =Convert.ToInt32(txtDepEco.Text);
            p.nss = txtNss.Text.ToUpper();
            p.fechaingreso =Convert.ToDateTime(txtFecIng.Text);
            p.noempleado = txtNumExp.Text.ToUpper();
            p.claveelector = txtCveElect.Text.ToUpper();
            p.estatus =Convert.ToInt32(DropDownList4.SelectedValue);
            p.beneficiario = txtBeneficiario.Text.ToUpper();
            string errores = WS.KardexActualiza(p);

            if(errores == "OK")
            {
                Titulo = Titulo;
                Mensaje = "Los datos se han guardado correctamente";
                TxtBoton = "OK";
                Iconito = "bi bi-check-circle";
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modalSlideUp", "$('#modalSlideUp').modal('show');", true);
            }
            else
            {
                Titulo = Titulo;
                Mensaje = errores;
                TxtBoton = "CERRAR";
                Iconito = "bi bi-x-circle";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSlideUp", "$('#modalSlideUp').modal();", true);
            }

        }
    }
}