using System;
using System.Web.UI;

namespace LabEngSoft
{
    public partial class CadastrarQuadra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int courtId))
                {
                    LoadCourtData(courtId);
                }
            }
        }

        private void LoadCourtData(int id)
        {
            var court = CourtRepository.GetById(id);
            if (court != null)
            {
                txtNome.Text = court.Nome;
                txtEndereco.Text = court.Endereco;
                ddlTipoQuadra.SelectedValue = court.TipoQuadra;
                txtCapacidade.Text = court.Capacidade.ToString();
                txtValorHora.Text = court.ValorHora.ToString("0.00");
                txtDescricao.Text = court.Descricao;
                btnCadastrar.Text = "Atualizar Quadra";
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e) // Removed CourtRepository parameter
        {
            if (Page.IsValid)
            {
                try
                {
                    var court = new Court
                    {
                        Nome = txtNome.Text.Trim(),
                        Endereco = txtEndereco.Text.Trim(),
                        TipoQuadra = ddlTipoQuadra.SelectedValue,
                        Capacidade = Convert.ToInt32(txtCapacidade.Text),
                        ValorHora = Convert.ToDecimal(txtValorHora.Text),
                        Descricao = txtDescricao.Text.Trim()
                    };

                    if (int.TryParse(Request.QueryString["id"], out int existingId))
                    {
                        court.Id = existingId;
                        CourtRepository.Update(court); // Direct static call
                        ShowMessage("Quadra atualizada com sucesso!");
                    }
                    else
                    {
                        CourtRepository.Add(court); // Direct static call
                        ShowMessage("Quadra cadastrada com sucesso!");
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage($"Erro: {ex.Message}", true);
                }
            }
        }

        private void ShowMessage(string message, bool isError = false)
        {
            lblMensagem.Text = message;
            lblMensagem.CssClass = isError ? "alert alert-danger" : "alert alert-success";
            lblMensagem.Visible = true;
        }

        private void ClearForm()
        {
            txtNome.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            ddlTipoQuadra.SelectedIndex = 0;
            txtCapacidade.Text = string.Empty;
            txtValorHora.Text = string.Empty;
            txtDescricao.Text = string.Empty;
        }
    }
}