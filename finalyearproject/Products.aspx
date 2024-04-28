<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="finalyearproject.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="stylesheets/user/Products.css" rel="stylesheet" />
    <div class="Product-body">
    <h1 class="heading">All Products</h1>
        <div class="all-products">
            <asp:Repeater ID="RepeaterProduct" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <a class="anchor-tag" href="ViewProduct.aspx?ProductID=<%# Eval("ProductID") %>">
                            <img src="Images/ProductImages/<%# Eval("ProductID") %>/<%# Eval("ImageName") %><%# Eval("Extension") %>" class="card-img-top" alt="<%# Eval("ImageName") %>">
                            <div class="card-body">
                                <p class="product-name"><%# Eval("ProductName") %></p>
                                <h5 class="brand-name">by <%# Eval("BrandName") %></h5>
                                <p class="product-details"><%# Eval("ProductDetails") %></p>
                            </div>
                            <div class="product-price">
                            <p class="product-price-inside">Just At <%# Eval("ProductSellPrice","{0:c}") %>/-</p>
                                </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
    </div>
        </div>
</asp:Content>
