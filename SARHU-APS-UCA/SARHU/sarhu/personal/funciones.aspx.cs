﻿using System;
using Negocio;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class funciones : System.Web.UI.Page
    {
        protected string nombreFuncion { get; set; }
        protected string Message { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();

            }
        }


        private void LoadData()
        {
            rptTable.DataSource = NG_Funciones.Instanciar().Listar(); ;
            rptTable.DataBind();

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;

            string arguments = b.CommandArgument;
            string[] args = arguments.Split(';');

            Idelminar.Value = args[0];
            nombreFuncion = args[1];

            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowPopup();", true);
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            int index = int.Parse(Idelminar.Value);
            if (NG_Funciones.Instanciar().Borrar(index))
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