<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="FP_ONLINEREP.Profile" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8" />
    <title>Welcome To Our Website</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/> 
    <meta name="description" content="Login and Registration Form with HTML5 and CSS3" />
    <meta name="keywords" content="html5, css3, form, switch, animation, :target, pseudo-class" />
    <meta name="author" content="Codrops" />
    <link rel="shortcut icon" href="../favicon.ico"/> 
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link rel="stylesheet" type="text/css" href="css/style.css" />
	<link rel="stylesheet" type="text/css" href="css/animate-custom.css" />
</head>
<body>
    <div class="container">
        <div class="codrops-top">
            <a>
                <strong>Hello, </strong><label id="uName" runat="server"></label>
            </a>
            <div class="clr"></div>
        </div>
        <header>
            <nav class="codrops-demos">
               
            </nav>
        </header>
        <section>
        <form id="container_form" runat="server" onsubmit="SignUp_Click" autocomplete="on">
            <div id="container_demo">
                <a class="hiddenanchor" id="toregister"></a>
                <a class="hiddenanchor" id="tologin"></a>
                <div id="wrapper">
                    
                    <div id="login" class="animate form" >
                        
                            <h1> Change Password </h1>
                            <ul id="errorlist" runat="server"></ul>                
                            <p> 
                                <label for="old_password" class="youpasswd" data-icon="p">Old password </label>
                                <input id="old_password" runat="server" name="old_password" required="required" type="password" placeholder="eg. X8df!90EO"/>
                            </p>
                            <p> 
                                <label for="new_password" class="youpasswd" data-icon="p">New password </label>
                                <input id="new_password" runat="server" name="new_password" required="required" type="password" placeholder="eg. X8df!90EO"/>
                            </p>
                            <p> 
                                <label for="password_confirm" class="youpasswd" data-icon="p">Please confirm your password </label>
                                <input id="password_confirm" runat="server" name="password_confirm" required="required" type="password" placeholder="eg. X8df!90EO"/>
                            </p>
                            <p class="signin button"> 
                                <asp:Button ID="ChangeButton" runat="server" Text="Save" OnClick="ChangeButton_Click" />
							    
							</p>
                            <p class="change_link">  
							    
								<a href="Home.aspx" class="to_register"> Back </a>
							</p>
                        
                    </div>
                    
                </div>
            </div>
            </form>
        </section>
    </div>

</body>
</html>