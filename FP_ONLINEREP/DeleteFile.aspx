<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteFile.aspx.cs" Inherits="FP_ONLINEREP.DeleteFile" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>Home</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/> 
    <meta name="description" content="Login and Registration Form with HTML5 and CSS3" />
    <meta name="keywords" content="html5, css3, form, switch, animation, :target, pseudo-class" />
    <meta name="author" content="Codrops" />
    <link rel="shortcut icon" href="../favicon.ico"/> 
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/style.css" />
	<link rel="stylesheet" type="text/css" href="css/animate-custom.css" />
    <link rel="stylesheet" type="text/css" href="css/Site.css" />
</head>
<body>
    <form id="form_container" runat="server">
    <div class="container">
            <!-- Codrops top bar -->
            <div class="codrops-top">
                <strong> FP .NET</strong>
                <div class="clr"></div>
            </div><!--/ Codrops top bar -->
            <header>
                <h1><span>(LOGO AND SITE NAME GO HERE)</span></h1>
				<nav class="codrops-demos">
				</nav>
            </header>
            <section>				
                <div id="container_demo" >
                    <!-- hidden anchor to stop jump http://www.css3create.com/Astuce-Empecher-le-scroll-avec-l-utilisation-de-target#wrap4  -->
                    <a class="hiddenanchor" id="toregister"></a>
                    <a class="hiddenanchor" id="tologin"></a>
                    <div id="wrapper">
                        <div id="login" class="animate form">
                            
                            <asp:Label ID="error" runat="server"></asp:Label><br />
                            <asp:Label ID="name" runat="server"></asp:Label><br />
                            <asp:Label ID="type" runat="server"></asp:Label><br />
                            <asp:Label ID="size" runat="server"></asp:Label><br />
                            <p class="change_link">
                                <a  href="#toregister" class="to_register">Delete</a>
                            </p>
                            
                        </div> 
                        <div id="register" class="animate form">
                                <h1> Are You Sure To Want To Delete This Item? </h1> 
                                
                                <p class="change_link">  
                                    <asp:LinkButton ID="delete" runat="server" Text="Yes" OnClick="Unnamed_Click"></asp:LinkButton>
                                    <a href="FileList.aspx" class="to_register"> Back </a>
								</p>
                            
                        </div>
						
                    </div>
                </div>  
            </section>
        </div>
    </form>
</body>
</html>
