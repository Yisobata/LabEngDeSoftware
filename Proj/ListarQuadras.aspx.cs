using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LabEngSoft
{
    public partial class ListQuadras : System.Web.UI.Page
    {
        // In-memory data store (temporary replacement for database)
        private static List<Court> _courts = new List<Court>
        {
            new Court { Id = 1, Endereco = "Rua A, 123", TipoQuadra = "Futebol", DataCadastro = DateTime.Now.AddDays(-5) },
            new Court { Id = 2, Endereco = "Av. B, 456", TipoQuadra = "Vôlei", DataCadastro = DateTime.Now.AddDays(-3) },
            new Court { Id = 3, Endereco = "Praça C, 789", TipoQuadra = "Basquete", DataCadastro = DateTime.Now.AddDays(-1) }
        };

     

      
      

          private void BindGrid()
        {
            var courts = CourtRepository.GetAll();

            // Store values needed for editing in DataKeys
            gvQuadras.DataKeyNames = new[] { "Id", "Endereco", "Nome" };
            gvQuadras.DataSource = courts;
            gvQuadras.DataBind();
        }
        private void ShowMessage(string message, bool isError = false)
        {
            // Find or add this control in your ASPX:
            // <asp:Label ID="lblMessage" runat="server" CssClass="alert" Visible="false"></asp:Label>

            Label lblMessage = (Label)FindControl("lblMessage");
            if (lblMessage != null)
            {
                lblMessage.Text = message;
                lblMessage.CssClass = isError ? "alert alert-danger" : "alert alert-success";
                lblMessage.Visible = true;

                // Optional: Auto-hide after 5 seconds
                ScriptManager.RegisterStartupScript(this, GetType(), "hideMessage",
                    "setTimeout(function() { document.getElementById('" + lblMessage.ClientID + "').style.display = 'none'; }, 5000);",
                    true);
            }
        }

        protected void ddlTipoQuadra_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvQuadras_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvQuadras.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvQuadras_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                Response.Redirect($"CadastroQuadra.aspx?Id={e.CommandArgument}");
            }
            else if (e.CommandName == "DeleteRow")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                _courts.RemoveAll(c => c.Id == id);
                BindGrid();
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroQuadra.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid("DataDesc"); // Default sort
            }
        }

        private void BindGrid(string sortExpression)
        {
            gvQuadras.DataSource = CourtRepository.GetAllSorted(sortExpression);
            gvQuadras.DataBind();
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(ddlSort.SelectedValue);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Maintain sorting during search
            BindGrid(ddlSort.SelectedValue);
        }
        protected void gvQuadras_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Put the row in edit mode
            gvQuadras.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvQuadras_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                // Your update logic here...
                ShowMessage("Quadra atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                ShowMessage($"Erro ao atualizar: {ex.Message}", true);
            }
        }

        protected void gvQuadras_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Your delete logic here...
                ShowMessage("Quadra removida com sucesso!");
            }
            catch (Exception ex)
            {
                ShowMessage($"Erro ao remover: {ex.Message}", true);
            }
        }

        protected void gvQuadras_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel edit mode
            gvQuadras.EditIndex = -1;
            BindGrid();
        }

    }



}