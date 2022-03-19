<%@ Page Title="Contact List" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactPhotoList.aspx.cs" Inherits="AdminPanel_ContactPhoto_ContactPhotoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Contact Photo List</h2>
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
                <asp:HyperLink runat="server" ID="hplAddContact" Text="Add New Contact with Photo" NavigateUrl="~/AdminPanel/ContactPhoto/ContactPhotoAddEdit.aspx" CssClass="btn btn-dark"></asp:HyperLink>
            </div>
            <div>
            <asp:GridView ID="gvContact" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvContact_RowCommand">
              
                <Columns>
                    <%--

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%#"~/AdminPanel/ContactPhoto/ContactPhotoAddEdit.aspx?ContactPhotoID=" + Eval("ContactPhotoID").ToString().Trim()%>' />
                        </ItemTemplate>
                    </asp:TemplateField>--%>


                    <asp:BoundField DataField="ContactPhotoID" HeaderText="ID" />
                    <asp:BoundField DataField="ContactName" HeaderText="Name" />
<%--                    <asp:BoundField DataField="ContactPhotoPath" HeaderText="Photo" />--%>
                    <asp:TemplateField HeaderText="Images">
                        <ItemTemplate>
                            <asp:Image runat="server" ID="imgContactPhotoPath" ImageUrl='<%# Eval("ContactPhotoPath") %>' Height="100" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactPhotoID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>



                    

                                                            
                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

