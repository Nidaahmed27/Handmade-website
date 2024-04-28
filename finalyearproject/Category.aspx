<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="finalyearproject.Category"  MasterPageFile="~/admin.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="stylesheets/admin/Category.css" rel="stylesheet" />
    <div class="AddProduct-container-body">
    <div class="AddProduct-container">
        <h2 class="container-heading">ADD CATEGORY</h2>
        <div class="form-items">
    <asp:Label ID="lblCategory" runat="server" Text="CATEGORY:" class="label-text"></asp:Label><br />
    <asp:TextBox ID="TxtCategoryName" runat="server" Class="input-area"></asp:TextBox>
    </div>
   <asp:Button ID="BtnAddCategory" runat="server" Text="Add" CssClass="submit-btn" OnClick="BtnAddCategory_Click" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server" ControlToValidate="TxtCategoryName" ErrorMessage="*please provide Category" ForeColor="#ffe4e1"></asp:RequiredFieldValidator>
   </div>

        <div class="Category-Table">
            <h1 class="table-heading">All CATEGORY</h1>
            <asp:Repeater ID="RepeaterCategory" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Category</th>
                                <th>Edit</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td ID="categoryID" runat="server"><%# Eval("CategoryID") %></td>
                        <td><%# Eval("CategoryName") %></td>
                        <asp:HiddenField ID="HiddenFieldCategoryID" runat="server" Value='<%# Eval("CategoryID") %>' />
                         <td> <asp:Button ID="BtnRemoveCategory" runat="server" Text="Remove Category" OnClick="BtnRemoveCategory_Click" class="delete-btn"  /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
        </table>
                </FooterTemplate>
            </asp:Repeater>


        </div>
    </div>
</asp:Content>
