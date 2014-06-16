<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileList.aspx.cs" Inherits="FP_ONLINEREP.FileList" %>

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
        <div class="codrops-top">
            <a>
                <strong>Hello, </strong><label id="uName" runat="server"></label>
            </a>
            <span class="right">
                <asp:LinkButton ID="logout" runat="server" OnClick="Logout" Text="Logout" />
            </span>
            <div class="clr"></div>
        </div>
        <header>
            <h1><span>(LOGO AND SITE NAME WILL GO HERE)</span></h1>
            <nav class="codrops-demos">
                <a href="Upload.aspx">Upload</a>
                <a href="Home.aspx">Home</a>
                <a href="FileList.aspx" class="current-demo">File List</a>
            </nav>
        </header>
        <section>
            <div id="container_demo" >
                    <!-- hidden anchor to stop jump http://www.css3create.com/Astuce-Empecher-le-scroll-avec-l-utilisation-de-target#wrap4  -->
                    <a class="hiddenanchor" id="toregister"></a>
                    <a class="hiddenanchor" id="tologin"></a>
                    <div id="wrapper">
                        <div id="login" class="animate form">
                                <h1>File List</h1> 
                                <asp:GridView ID="gvFiles" AutoGenerateColumns="true" runat="server" CssClass="GridViewStyle">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server"
                                                NavigateUrl='<%# Eval("FileId", "GetFile.aspx?ID={0}") %>'
                                                Text="Download">
                                            </asp:HyperLink>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink3" runat="server"
                                                NavigateUrl='<%# Eval("FileId", "DeleteFile.aspx?ID={0}") %>'
                                                Text="Delete">
                                            </asp:HyperLink>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                                
                            
                        </div>

						
                    </div>
                </div>
        </section>
    </div>
    </form>
</body>
</html>
