<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="MultiUserAddressBook_AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .gridview{
            overflow:scroll;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div class="container"> 
            <div class="row">
                <div class="col-md-6">
                    <h2 style="align-content:center ; color:lightcoral">Contact List</h2>
                </div> 
                <div class="col-md-6" style="text-align:right">
                    <br />
                    <asp:HyperLink ID="hlAddContact" runat="server" NavigateUrl="/AdminPanel/Contact/Add" CssClass="btn btn-dark">Add Contact</asp:HyperLink>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <br />
                    <b><asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="false"></asp:Label></b>
                </div>
            </div>
            <br />
            <div class="container">
            <div class="row text-center">
                <div class="col-md-12 text-center gridview">
                    <asp:GridView ID="gvContact" runat="server" CssClass="table table-hover" OnRowCommand="gvContact_RowCommand" AutoGenerateColumns="false" >
                        <Columns>
                            <asp:TemplateField HeaderText="Delete Record">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit Record">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%# "/AdminPanel/Contact/Edit/" + Eval("ContactID").ToString().Trim() %>'  CssClass="btn btn-warning">Edit</asp:HyperLink> 
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:BoundField DataField="ContactID" HeaderText="ContactID" />
                             <asp:BoundField DataField="CountryName" HeaderText="CountryName" />
                            <asp:BoundField DataField="StateName" HeaderText="StateName" />
                            <asp:BoundField DataField="CityName" HeaderText="CityName" />
                            <asp:BoundField DataField="ContactCategoryName" HeaderText="Name" />
                             <asp:BoundField DataField="ContactName" HeaderText="ContactName" />
                            <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                            
                            <asp:TemplateField HeaderText="Images">
                                <ItemTemplate>
                                <asp:Image runat="server" ID="imgContactPhotoPath" ImageUrl='<%# Eval("ContactPhotoPath") %>' Height="100" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Age" HeaderText="Age" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />

                            
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

