<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="finalyearproject.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="stylesheets/user/default.css" rel="stylesheet" />

    <title>HAND-MADE</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>
        <div class="logo">
            <span class="logo-text1">HAND</span>
            <span class="logo-text2">MADE</span>
            <span ><img src="Assets/Icons/pagelines.svg" alt="leaf-img" class="leaf-img"/></span>
        </div>
        <div class="icons">
        
            <a class="shopping-cart" href="Cart.aspx"  runat="server">
            <img src="Assets/Icons/bag-shopping-solid.svg" alt="bag-shopping" />
                <span class="badge" id="PCount" runat="server"></span>
            </a>
                <asp:Button ID="BtnLogout" runat="server" Text="Logout" OnClick="BtnLogout_Click" cssclass="loginlogout" />
            <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" cssclass="loginlogout"/>
        </div>
    </header>
    <nav>
        <ul class="navbar">
            <li><a href="/">HOME</a></li>
            <li><a href="Products.aspx">PRODUCTS</a></li>
            <li><a href="#contact-us">CONTACT US</a></li>
            <li><a href="#about-us">ABOUT US</a></li>

        </ul>
    </nav>
        </div>
        <div>
            <div class="main-content">
                <h2 class="heading">Welcome to our store!</h2>
                <p>We specialize in handcrafted Candles, Soaps, and Resin Products.</p>
            </div>
            <div class="page-content-right">
                <img src="Assets/Images/homepage-Candle.jpg" class="page-content-img" />
                <div class="page-content-details">
                    <p>Welcome to <span>HANDMADE</span>, where every candle is crafted with care to bring you the finest fragrance and aroma experience! Transform your space into a haven of tranquility and warmth with our exquisite collection of hand-poured candles. Our passion for quality and attention to detail ensures that each candle radiates with captivating scents that linger long after they've been lit. Explore our range and discover the perfect scent to suit your mood, whether you crave the soothing notes of lavender, the invigorating aroma of citrus, or the cozy embrace of vanilla. Elevate your ambiance and indulge your senses with <span>HANDMADE</span>. Experience the magic of scent, one candle at a time.</p>
                    <a href="/Products.aspx" class="Button_ShopNow">Shop Now</a>
                </div>
            </div>
            <div class="page-content-left">
                <div class="page-content-details">
                    <p>Welcome to <span>HANDMADE</span>, your destination for luxurious, chemical-free herbal soaps crafted with the goodness of nature for radiant skin! Indulge in the pure essence of our handcrafted soaps, meticulously formulated to nurture and nourish your skin with the finest natural ingredients. Embrace the beauty of botanicals as our artisanal soaps cleanse, moisturize, and revitalize, leaving your skin feeling refreshed and rejuvenated. Say goodbye to harsh chemicals and hello to the gentle touch of nature's bounty with [Business Name]. Pamper yourself and your loved ones with the gift of wholesome skincare, because when it comes to your skin, only the best will do. Experience the difference that natural goodness can make, one soap at a time, with <span>HANDMADE</span>.</p>
                    <a href="/Products.aspx" class="Button_ShopNow">Shop Now</a>
                </div>
                <img src="Assets/Images/homepage-soap.jpg" class="page-content-img-left" />

            </div>
            <div class="page-content-right">
                <img src="Assets/Images/homepage-resinart.jpg" class="page-content-img" />
                <div class="page-content-details">
                    <p>Welcome to <span>HANDMADE</span>, where creativity knows no bounds and art comes to life through mesmerizing resin creations! Discover the enchanting world of resin artistry, where every piece is a unique expression of color, texture, and imagination. From stunning tabletop decor to captivating wall hangings, our handcrafted resin art pieces add a touch of elegance and sophistication to any space. Whether you're looking for a statement piece for your home or a heartfelt gift for someone special, our collection offers a diverse range of styles and designs to suit every taste. Dive into a world of endless possibilities with [Business Name], where each resin masterpiece is crafted with passion and precision. Let your imagination soar and transform your surroundings into a masterpiece of beauty with our exquisite resin art creations. Experience the magic of resin artistry today, only at <span>HANDMADE</span>.</p>
                    <a href="/Products.aspx" class="Button_ShopNow">Shop Now</a>
                </div>
            </div>

        </div>
        <div class="AboutUs" id="about-us">
            <h1 class="heading-aboutus">About Us</h1>
            <p class="AboutUsParagraph">
                Welcome to <span>HANDMADE</span>, your go-to destination for unique, handcrafted treasures that celebrate creativity, craftsmanship, and the human touch. We are passionate about supporting small businesses and artisans who pour their heart and soul into creating one-of-a-kind products that bring joy to everyday life.

                At <span>HANDMADE</span>, we believe in the power of handmade goods to tell stories, evoke emotions, and connect people. Whether it's a beautifully scented candle, a luxurious bar of soap, or a stunning piece of resin art, each item in our curated collection is a testament to the skill, dedication, and artistry of the talented individuals behind it.

                Our mission is simple: to provide a platform where small businesses can thrive, artisans can showcase their talents, and customers can discover unique treasures that can't be found anywhere else. By choosing handmade, you're not just purchasing a product – you're supporting a community of creators and helping to preserve traditional craftsmanship in a world that often prioritizes mass production.

                At <span>HANDMADE</span>, we're committed to fostering a sustainable and ethical marketplace. We prioritize environmentally friendly practices, fair wages for artisans, and transparency throughout our supply chain. When you shop with us, you can feel good knowing that your purchase has a positive impact on both the planet and the people behind the products.

                Thank you for joining us on this journey to celebrate the beauty of handmade craftsmanship. We invite you to explore our ever-growing collection, discover new favorites, and connect with the incredible artisans who make it all possible. Together, let's create a world where handmade reigns supreme and creativity knows no bounds.<br />

                Welcome to <span>HANDMADE</span> – where every purchase tells a story and every product is made with love.
            </p>
        </div>
        <div class="ContactUs" id="contact-us">
            <div class="ContactUs-head-section">
                <h1>Contact Us</h1>
                <p>Have any questions? We'd love to hear from you.</p>
            </div>
            <div class="ContactUs-body-section">
                <div class="ContactUs-body-section-items">
                    <h3 class="footer-body-heading">Help & Support</h3>
                    <p class="footer-body-content">Reach out to our dedicated support team for assistance with any inquiries or issues you may have.</p>
                    <button class="footer-body-button">Get Support</button>
                </div>
                <div class="ContactUs-body-section-items">
                     <h3 class="footer-body-heading">FeedBack</h3>
                    <p class="footer-body-content">Share your thoughts, suggestions, and ideas with us to help improve our services.</p>
                    <button class="footer-body-button">Share Feedback</button>
                </div>
                <div class="ContactUs-body-section-items">
                     <h3 class="footer-body-heading">FAQ</h3>
                    <p class="footer-body-content">Find answers to commonly asked questions to assist you promptly.</p>
                    <button class="footer-body-button">Explore FAQs</button>
                </div>
            </div>
        </div>
         <footer>
        <div class="footer-items">
            <img src="Assets/Icons/copyright-regular.svg" alt="copyright"/>
            <p>HAND MADE | All Right Reserved.</p>
        </div>
    </footer>
    </form>
</body>
</html>
