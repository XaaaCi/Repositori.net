<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FP_ONLINEREP.Register" %>

<!DOCTYPE html>

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
            <strong>FP .NET</strong>
            <div class="clr"></div>
        </div>
        <header>
            <h1>Login and Registration Form <span>(LOGO AND SITE NAME WILL GO HERE)</span></h1>
            <nav class="codrops-demos">
                <a href="LoginAndRegister.aspx">Login</a>
                <a href="Register.aspx" class="current-demo">Register</a>
                <a href="Disclaimer.aspx">Disclaimer</a>
            </nav>
        </header>
        <section>
        <form id="container_form" runat="server" onsubmit="SignUp_Click" autocomplete="on">
            <div id="container_demo">
                <a class="hiddenanchor" id="toregister"></a>
                <a class="hiddenanchor" id="tologin"></a>
                <div id="wrapper">
                    
                    <div id="login" class="animate form" >
                        
                            <h1> Sign up </h1>
                            <ul id="errorlist" runat="server"></ul>
                            <p>
                                <label for="usernamesignup" class="uname" data-icon="u">Your username</label>
                                <input id="usernamesignup" runat="server" name="usernamesignup" required="required" type="text" placeholder="mysuperusername690" />
                            </p>
                            <p> 
                                <label for="emailsignup" class="youmail" data-icon="e" > Your email</label>
                                <input id="emailsignup" runat="server" name="emailsignup" required="required" type="email" placeholder="mysupermail@mail.com"/> 
                            </p>
                            <p> 
                                <label for="passwordsignup" class="youpasswd" data-icon="p">Your password </label>
                                <input id="passwordsignup" runat="server" name="passwordsignup" required="required" type="password" placeholder="eg. X8df!90EO"/>
                            </p>
                            <p> 
                                <label for="passwordsignup_confirm" class="youpasswd" data-icon="p">Please confirm your password </label>
                                <input id="passwordsignup_confirm" runat="server" name="passwordsignup_confirm" required="required" type="password" placeholder="eg. X8df!90EO"/>
                            </p>
                            <p class="signin button"> 
                                <asp:Button ID="SignUp" runat="server" Text="Sign Up" OnClick="SignUp_Click" />
							    
							</p>
                            <p class="change_link">  
							    Already a member ?
								<a href="LoginAndRegister.aspx" class="to_register"> Go and log in </a>
							</p>
                        
                    </div>
                    
                </div>
            </div>
            </form>
        </section>
    </div>

</body>
</html>