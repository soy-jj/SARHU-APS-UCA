﻿using System;
using Negocio;
using Entidades;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace SARHU.sarhu.personal
{
    public partial class puestos : Page
    {
        protected NG_Puestos ngPuesto = NG_Puestos.Instanciar();
        protected static int id = 0;
        private static DataTable dtFuncion = new DataTable();
        protected string Nombre = null;
        protected string Message = null;
        protected static int IdPuesto = 0;
        private static List<int> funcionesId = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRepeater();
                populatedDropdownArea();
                populatedDropdownCuentas();
            }
        }

        public void InitIDFunciones() {
            foreach (DataRow row in dtFuncion.Rows)
            {
                funcionesId.Add(int.Parse(row["Id"].ToString()));
            }

        }

        public void LoadRepeater()
        {
            rptFunciones.DataSource = ngPuesto.ListarPuesto(true);
            rptFunciones.DataBind();
        }

        private void populatedDropdownArea()
        {

            ddlarea.DataSource = NG_Areas.Instanciar().Listar();
            ddlarea.DataTextField = "Nombre";
            ddlarea.DataValueField = "Id";
            ddlarea.DataBind();
            ddlarea.Items.Insert(0, new ListItem("SELECCIONE...", "0"));

        }
        private void populatedDropdownCuentas()
        {

            ddlCuentas.DataSource = NG_Cuentas.Instanciar().ListarPorEstado(true);
            ddlCuentas.DataTextField = "Descripcion";
            ddlCuentas.DataValueField = "Id";
            ddlCuentas.DataBind();
            ddlCuentas.Items.Insert(0, new ListItem("SELECCIONE...", "0"));

        }

        public void ConsultData(int id)
        {


            Puesto puesto = ngPuesto.Consultar(id);

            ddlarea.ClearSelection();
            ddlCuentas.ClearSelection();

            NombrePuesto.Text = puesto.Nombre;
            textarea.Value = puesto.Descripcion;
            ddlarea.Items.FindByValue(puesto.AreaId.ToString()).Selected = true;
            ddlCuentas.Items.FindByValue(puesto.CuentaId.ToString()).Selected = true;
            Salario.Text = puesto.SalarioBase.ToString();
            dtFuncion = ngPuesto.ListarPuestoFunciones(id);

            InitIDFunciones();
            rptFuncion.DataSource = dtFuncion;
            rptFuncion.DataBind();
        }


        protected void Detalle_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            string arguments = b.CommandArgument;

            ConsultData(int.Parse(arguments));


            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowDetail();", true);
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            string arguments = b.CommandArgument;
            string[] args = arguments.Split(';');

            IdPuesto = int.Parse(args[0]);
            Nombre = args[1];

            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowPopup();", true);
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            dtFuncion.Clear();
            dtFuncion = ngPuesto.ListarPuestoFunciones(IdPuesto);
            InitIDFunciones();

            if (ngPuesto.Eliminar(IdPuesto,funcionesId))
            {
                Message = "BORRADO EXITOSAMENTE";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "DeletePopup();", true);
            }
            else
            {
                Message = "ERROR AL BORRAR EL REGISTRO";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "DeletePopup();", true);
            }
        }

    }
}