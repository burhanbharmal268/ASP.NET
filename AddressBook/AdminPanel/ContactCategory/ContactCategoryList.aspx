<%@ Page Title="Contact Category List" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact Category List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div> 
                <asp:HyperLink runat="server" ID="hplAddContactCategory" Text="Add New Contact Category" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx" CssClass="btn btn-dark"></asp:HyperLink>
            </div>
            <div>
            <asp:GridView ID="gvContactCategory" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvContactCategory_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%#"~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID=" + Eval("ContactCategoryID").ToString().Trim()%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="ContactCategoryID" HeaderText="ID" />
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Category Name" />
                    
                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

