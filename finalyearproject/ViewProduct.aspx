<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="finalyearproject.ViewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="stylesheets/user/ViewProduct.css" rel="stylesheet" />
    <div class="view-product">
        <div class="view-product-inside">
            <div class="view-product-images">
                 
                <div class="sliders" style="height: 450px; width: 300px">
                   <div class="controls">
                        <span class="prev" onclick="moveSlide(-1)">❮</span>
                    </div>
                    <div class="image-container">
                    <asp:Repeater ID="RepeaterViewProduct" runat="server">
                        <ItemTemplate>
                            <img class="slide" src="Images/ProductImages/<%# Eval("ProductID") %>/<%# Eval("Name") %><%# Eval("Extension") %>" alt="<%# Eval("Name") %>" style="height: 100%; width: 100%; object-fit: contain;" />
                            
                        </ItemTemplate>
                    </asp:Repeater>
                        </div>
                    <div class="controls">
                        <span class="next" onclick="moveSlide(1)">❯</span>
                    </div>
                   
                </div>
                 
            </div>
            <asp:Repeater ID="RepeaterProductDetails" runat="server">
                <ItemTemplate>
                    <div class="view-product-content">
                        <h1 class="product-name"><%# Eval("ProductName") %></h1>
                        <h5 class="brand-name">by <%# Eval("Name") %></h5>
                        <h3 class="product-price">Just at Rs. <%# Eval("ProductSellPrice","{0:c}") %> /-</h3>
                        <span class="discount">10% off /-</span><br />
                        <asp:Button ID="BtnAddToCart" runat="server" Text="Add To Cart" OnClick="BtnAddToCart_Click" class="AddToCart"/>
                        <h4 style="margin-top: 10px;">Detail:</h4>
                        <p class="product-details" ><%# Eval("ProductDetails") %></p>
                        <h4>Description:</h4>
                        <p class="product-details"><%# Eval("ProductDescription") %></p>
                        <p><%# ((int)Eval("CashOnDelivery")==1)? "Cash On Delivery":" "  %></p>
                        <p><%# ((int)Eval("[30DaysReturn]")==1)? "30 Days Return":" "  %></p>
                    </div>


                    </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <script>
        let slideIndex = 0;
        const slides = document.getElementsByClassName("slide");

        function showSlides() {
            for (let i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slideIndex++;
            if (slideIndex > slides.length) { slideIndex = 1 }
            slides[slideIndex - 1].style.display = "block";
            setTimeout(showSlides, 2000); // Change image every 2 seconds
        }

        function moveSlide(n) {
            slideIndex += n;
            if (slideIndex > slides.length) { slideIndex = 1 }
            else if (slideIndex < 1) { slideIndex = slides.length }
            for (let i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slides[slideIndex - 1].style.display = "block";
        }

        showSlides();
    </script>
</asp:Content>
