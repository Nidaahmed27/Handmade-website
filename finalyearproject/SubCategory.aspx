<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubCategory.aspx.cs" Inherits="finalyearproject.SubCategory" MasterPageFile="~/admin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="stylesheets/admin/Category.css" rel="stylesheet" />
    <div class="AddProduct-container-body">
        <div class="AddProduct-container">
            <h2 class="container-heading">ADD SUB-CATEGORY</h2>
            <div class="form-items" style="margin-bottom:0px;">
                <asp:Label ID="lblMainCategoryID" runat="server" Text="MAIN CATEGORY:" class="label-text"></asp:Label><br />
                <asp:DropDownList ID="DdlMainCategoryID" runat="server" Class="input-area" ></asp:DropDownList><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMainCategoryID" runat="server" ControlToValidate="DdlMainCategoryID" ErrorMessage="*please provide Main Category " ForeColor="#ffe4e1"></asp:RequiredFieldValidator>
            </div>
            <div class="form-items">
                <asp:Label ID="lblSubCategory" runat="server" Text="SUB-CATEGORY:" class="label-text"></asp:Label>
                <asp:TextBox ID="TxtSubCategoryName" runat="server" Class="input-area"></asp:TextBox>
            </div>
            <asp:Button ID="BtnAddSubCategory" runat="server" Text="Add" OnClick="BtnAddSubCategory_Click" CssClass="submit-btn" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCategory" runat="server" ControlToValidate="TxtSubCategoryName" ErrorMessage="*please provide Sub-Category" ForeColor="#ffe4e1"></asp:RequiredFieldValidator>
        </div>

        <div class="Category-Table">
            <h1 class="table-heading">SUB-CATEGORY</h1>
            <asp:Repeater ID="RepeaterSubCategory" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Sub Category</th>
                                <th>Main Category</th>
                                <th>Edit</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("SubCategoryID") %></td>
                        <td><%# Eval("SubCategoryName") %></td>
                        <td><%# Eval("CategoryName") %></td>
                        <td>
                            <asp:HiddenField ID="HiddenFieldSubCategoryID" runat="server" value='<%# Eval("SubCategoryID") %>' />
                            <asp:Button ID="BtnRemoveSubCategory" runat="server" Text="Remove  Sub-Category" OnClick="BtnRemoveSubCategory_Click" class="delete-btn" /></td>
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
