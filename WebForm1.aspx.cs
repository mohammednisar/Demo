﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Pservice PS = new Pservice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();

            }
        }

        private void FillGrid()
        {
            GridView1.DataSource = PS.GetAllStates();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                PS.StateName = ((TextBox)GridView1.HeaderRow.FindControl("TextBox2")).Text;
                PS.InsertNewState(PS);
                FillGrid();

            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FillGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FillGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            PS.StateID = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);
            PS.StateName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            PS.UpdateState(PS);

            GridView1.EditIndex = -1;
            FillGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            PS.StateID = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);
            PS.DeleteState(PS);
            FillGrid();
        }
    }
}