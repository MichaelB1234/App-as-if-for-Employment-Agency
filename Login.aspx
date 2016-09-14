<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login2" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Employment Agency App Demo</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="jquery" name="Code_Language" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link type="text/css" rel="stylesheet" href='<% =Page.ResolveUrl("~/Content/bootstrap.min.css") %>' />
    <link type="text/css" rel="stylesheet" href='<% =Page.ResolveUrl("~/Content/bootstrap-flat.min.css") %>' />
</head>
<body id="picturebody" style="color: rgba(0,0,255,1.0); align-content: center; font-weight: 700; font-size: small; width: 100%; float: left;">
    <form id="Form1" method="post" runat="server">
        <asp:Panel runat="server" HorizontalAlign="Center">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div style="height: 60px;"></div>
                <div>
                    <div>
                        <div class="col-lg-3 -col-md-3 col-sm-3">
                        </div>
                        <div class="col-lg-6 -col-md-6 col-sm-6" style="border: 25px ridge rgba(0,0,0,.3);">

                            <div class="col-lg-12 -col-md-12 col-sm-12">
                                <div style="font-size: medium;">
                                    <img src="Images/Logo.png" alt="Logo" height="212" width="438" />
                                </div>
                            </div>
                            <div class="col-lg-12 -col-md-12 col-sm-12">
                                <div>
                                    <br />
                                    <asp:Label ID="lbluid" runat="server" Font-Names="Cambria" Font-Size="11pt" Width="117px">User Name:</asp:Label>
                                    <asp:TextBox ID="txtUserName" TabIndex="1" runat="server" MaxLength="50"
                                        CssClass="text" Width="179px" Font-Names="Cambria" Font-Size="11pt" OnTextChanged="txtFirstName_TextChanged"></asp:TextBox>
                                    <div>
                                        <br />
                                        <asp:Label ID="lblpin" runat="server" Font-Names="Cambria" Font-Size="11pt" Width="117px">Password:</asp:Label>
                                        <asp:TextBox ID="txtPassword" TabIndex="2" runat="server" MaxLength="50" TextMode="Password"
                                            CssClass="text" Width="180px" Font-Names="Cambria" Font-Size="11pt"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div style="width: 100%; height: 50px">
                                    <asp:Button CssClass="button btn btn-success" ID="cmdLogin" runat="server" BorderStyle="None" Text="Login" OnClick="cmdLogin_Click" />
                                    <br />
                                </div>
                                <div style="width: 100%; height: 50px">
                                    <asp:CheckBox ID="chkNewPwd" TabIndex="5"
                                        runat="server" EnableViewState="False"
                                        AutoPostBack="False" Text="Change Password" OnCheckedChanged="chkNewPwd_CheckedChanged"></asp:CheckBox>
                                </div>
                                <div>
                                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                </div>
                            </div>
                            <div class="col-lg-4 -col-md-3 col-sm-2">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </form>
    <%--<script src='<%= Page.ResolveUrl("~/Scripts/jquery-2.1.4.min.js") %>'></script>
    <script src='<%= Page.ResolveUrl("~/Scripts/bootstrap.min.js") %>'></script>--%>
    <script type="text/javascript">
        function setloginfocus() {
            $("#txtFirstName").focus();
        }
        function showchangepassword() {
            if (Form1.chkNewPwd.checked == true) {
                $("#Table2").show();
                $("#cmdUpdate").show();
            }
            else {
                $("#Table2").hide();
                $("#cmdUpdate").hide();
            }
        }
        {
            document.getElementById('picturebody').style.backgroundColor = '<%= Session["BackColour"].ToString() %>';
        }
    </script>
</body>
</html>
