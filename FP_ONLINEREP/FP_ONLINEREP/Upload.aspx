﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="FP_ONLINEREP.Upload" %>

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
    <style type="text/css">
    #dropZone {
        background: gray;
        border: black dashed 3px;
        width: auto;
        padding: 50px;
        text-align: center;
        color: white;
    }
</style>
    <script type="text/javascript">
        $(function () {
            $('#dropZone').filedrop({
                url: '@Url.Action("ActionResult")',
                paramname: 'fileInput',
                maxFiles: 5,
                dragOver: function () {
                    $('#dropZone').css('background', 'blue');
                },
                dragLeave: function () {
                    $('#dropZone').css('background', 'gray');
                },
                drop: function () {
                    $('#dropZone').css('background', 'gray');
                },
                afterAll: function () {
                    $('#dropZone').html('The file(s) have been uploaded successfully!');
                },
                uploadFinished: function (i, file, response, time) {
                    $('#uploadResult').append('<li>' + file.name + '</li>');
                }
            });
        });
</script>
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
            <h1><span>ONLINEREP</span></h1>
            <nav class="codrops-demos">
                <a href="Upload.aspx" class="current-demo">Upload</a>
                <a href="Home.aspx">Home</a>
                <a href="FileList.aspx">File List</a>
            </nav>
        </header>
        <section>
            <div id="container_demo">
                <div id="wrapper">
                    <input type="file" id="fileInput" name="fileInput" runat="server" />
                    
                    <asp:Button ID="btnUpload" Text="Upload File" runat="server"  OnClick="btnUpload_Click" />
                    <div id="dropZone">Drop your files here</div>
                <br/>
                Uploaded Files:
                <ul id="uploadResult">
                </ul>
                </div>
            </div>
        </section>
    </div>
    </form>
</body>
</html>

