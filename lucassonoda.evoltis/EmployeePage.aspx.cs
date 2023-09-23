using Autofac.Integration.Web.Forms;
using BusinessLogic.Employee;
using lucassonoda.evoltis.EmployeeUltils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace lucassonoda.evoltis
{
    [InjectProperties]
    public partial class EmployeePage : System.Web.UI.Page
    {
        public IEmployeeService Service { get; set; }
        private EmployeeForm _form;
        protected void Page_Load(object sender, EventArgs e)
        {
            _form = new EmployeeForm(EmployeeID, EmployeeName, EmployeeSurname, EmployeeEmail, EmployeeSalary);
            if (!IsPostBack)
            {
                GridViewEmpleados.DataSource = Service.FindAll();
                GridViewEmpleados.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text))
                BindGridView(Service.FindAll);
            else
                BindGridView(() => Service.FindByName(SearchBox.Text));
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            SearchBox.Text = string.Empty;
            BindGridView(Service.FindAll);
        }

        protected void GridViewEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int employeeId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                _form.Bind(Service.FindById(employeeId));
                ModalPopupExtender.Show();

            }
            else if (e.CommandName == "Eliminar")
            {
                Service.Delete(employeeId);
                BindGridView(Service.FindAll);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            rptErrores.DataSource = Array.Empty<string>();
            rptErrores.DataBind();
            var errors = _form.HasErrors();
            if (errors.Any())
            {
                rptErrores.DataSource = errors.Take(2);
                rptErrores.DataBind();
                ModalPopupExtender.Show();
            }
            else
            {
                var entity = _form.Map();
                if (_form.IsEdition)
                    Service.Update(entity);
                else
                    Service.Create(entity);

                _form.Clear();
                ModalPopupExtender.Hide();
                BindGridView(Service.FindAll);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            _form.Clear();
            rptErrores.DataSource = Array.Empty<string>();
            rptErrores.DataBind();
            ModalPopupExtender.Hide();
        }

        private void BindGridView(Func<IEnumerable<EmployeeDTO>> callback)
        {
            GridViewEmpleados.DataSource = callback();
            GridViewEmpleados.DataBind();
        }

    }
}