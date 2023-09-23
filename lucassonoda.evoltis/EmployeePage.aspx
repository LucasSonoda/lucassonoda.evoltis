<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeePage.aspx.cs" Inherits="lucassonoda.evoltis.EmployeePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>

        <h3>Empleados</h3>

        <div class="d-flex flex-column">
            <div class="w-100 d-flex mb-2 justify-content-between"">
                <div class="d-flex w-100">
                    <asp:TextBox runat="server" ID="SearchBox" type="text" class="form-control form-control-sm w-25 me-2" placeholder="Ingrese un nombre" />
                    <asp:Button ID="SearchButton" runat="server" CssClass="btn btn-sm btn-light me-2" Text="Buscar"  OnClick="btnSearch_Click"/>
                    <asp:Button ID="ClearButton" runat="server" CssClass="btn btn-sm btn-light me-2" Text="Limpiar" OnClick="btnClear_Click"/>
                </div>
                <div class="w-25 text-end">
                    <asp:Button ID="CreateButton" runat="server" CssClass="btn btn-sm btn-success" Text="Nuevo" />
                </div>
            </div>
            <asp:GridView ID="GridViewEmpleados" runat="server"  OnRowCommand="GridViewEmpleados_RowCommand" AutoGenerateColumns="false" CssClass="table table-sm table-striped">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="Name" HeaderText="Nombre" />
                    <asp:BoundField DataField="Surname" HeaderText="Apellido" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="w-25 text-center" ItemStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-sm btn-secondary" />
                            <asp:Button runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este empleado?');" CssClass="btn btn-sm btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </main>

    <style>
        #modalPopup_backgroundElement {
            background-color: rgba(0 0 0 /.3);
        }
    </style>

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="CreateButton"
        PopupControlID="pnlEditarEmpleado" BackgroundCssClass="modalBackground" BehaviorID="modalPopup"  DropShadow="true"/>

    <div id="pnlEditarEmpleado" class="modalPopup" style="display: none;">
        <div class="modal show fade" data-bs-backdrop="static" data-bs-keyboard="false" style="display:block" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="staticBackdropLabel">Edicion Empleado</h5>
                <asp:Button runat="server" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" OnClick="btnCancelar_Click" />
              </div>
              <div class="modal-body p-2">
                <div>
                    <div class="d-flex w-100 gap-1">
                        <div class="mb-3 w-50">
                            <label for="EmployeeName" class="form-label">Nombre</label>
                            <asp:TextBox runat="server" ID="EmployeeName" CssClass="form-control form-control-sm" />
                        </div>
                        <div class="mb-3 w-50">
                            <label for="EmployeeSurname" class="form-label">Apellido</label>
                            <asp:TextBox runat="server" ID="EmployeeSurname" CssClass="form-control form-control-sm" />
                        </div>         
                    </div>
                    <div class="d-flex justify-content-lg-start">
                        <div class="w-75">
                            <label for="EmployeeEmail" class="form-label">Correo Electronico</label>
                            <asp:TextBox runat="server" ID="EmployeeEmail" CssClass="form-control form-control-sm" />
                        </div>
                        <div class="w-50">
                            <label for="EmployeeSalary" class="form-label">Salario</label>
                            <asp:TextBox runat="server" ID="EmployeeSalary" CssClass="form-control form-control-sm" type="number" step=".01" min="0" />
                        </div>
                    </div>
                    <asp:TextBox runat="server" ID="EmployeeID" CssClass="hiding" type="hidden" />
                     <div class="my-2 px-3 text-s" style="font-size:13px">
                        <asp:Repeater ID="rptErrores" runat="server">
                            <ItemTemplate>
                                <div class="text-danger"><%# Container.DataItem.ToString() %></div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
              </div>
              <div class="modal-footer">
                    <asp:Button runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-sm btn-light" UseSubmitBehavior="true" />
                    <asp:Button runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-sm btn-success" UseSubmitBehavior="false" />
              </div>
            </div>
          </div>
        </div>
    </div>
</asp:Content>
