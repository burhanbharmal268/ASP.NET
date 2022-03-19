<%@ Page Title="State List" Language="C#" MasterPageFile="~/Content/AddressBook.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-md-12">
            <h2>State List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="col-md-12">
            <div> 
                <asp:HyperLink runat="server" ID="hplAddState" Text="Add New State" NavigateUrl="~/AdminPanel/State/StateAddEdit.aspx" CssClass="btn btn-dark"></asp:HyperLink>
            </div>
            <div>
            <asp:GridView ID="gvState" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvState_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-danger btn-sm" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%#"~/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID").ToString().Trim()%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="StateID" HeaderText="ID" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                    <asp:BoundField DataField="StateName" HeaderText="State Name" />
                    <asp:BoundField DataField="StateCode" HeaderText="Code" />
                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

