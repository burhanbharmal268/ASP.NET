<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactWiseContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactWiseContactCategory_ContactWiseContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>ContactWise  List</h2>
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
                <asp:HyperLink runat="server" ID="hplAddContact" Text="Add New Contact" NavigateUrl="~/AdminPanel/ContactWiseContactCategory/ContactWiseContactCategoryAddEdit.aspx" CssClass="btn btn-dark"></asp:HyperLink>
            </div>
            <div>
            <asp:GridView ID="gvContact" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvContact_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%#"~/AdminPanel/ContactWiseContactCategory/ContactWiseContactCategoryAddEdit.aspx?ContactID=" + Eval("ContactID").ToString().Trim()%>' />
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:BoundField DataField="ContactID" HeaderText="ID" />
                    <asp:BoundField DataField="ContactName" HeaderText="Name" />
                    <asp:TemplateField HeaderText="Images">
                        <ItemTemplate>
                            <asp:Image runat="server" ID="imgContactPhotoPath" ImageUrl='<%# Eval("ContactPhotoPath") %>' Height="100" />
                        </ItemTemplate>
                    </asp:TemplateField>



                    

                                                            
                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

