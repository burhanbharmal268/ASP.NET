<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="MultiUserAddressBook_AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div>
        <div class="container"> 
            <div class="row">
                <div class="col-md-6">
                    <h2 style="align-content:center ; color:lightcoral">State List</h2>
                </div> 
                <div class="col-md-6" style="text-align:right">
                    <br />
                    <asp:HyperLink ID="hlAddState" runat="server" NavigateUrl="/AdminPanel/State/Add" CssClass="btn btn-dark">Add State</asp:HyperLink>
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
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvState" runat="server" CssClass="table table-hover" OnRowCommand="gvState_RowCommand" AutoGenerateColumns="false" >
                        <Columns>
                            <asp:TemplateField HeaderText="Delete Record">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit Record">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%# "/AdminPanel/State/Edit/" + Eval("StateID").ToString().Trim() %>'  CssClass="btn btn-warning">Edit</asp:HyperLink> 
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:BoundField DataField="StateID" HeaderText="StateID" />
                             <asp:BoundField DataField="CountryName" HeaderText="CountryName" />
                            <asp:BoundField DataField="StateName" HeaderText="StateName" />
                             <asp:BoundField DataField="StateCode" HeaderText="StateCode" />

                            
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

