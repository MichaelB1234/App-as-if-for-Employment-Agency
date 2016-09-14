<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginstatus.aspx.cs" Inherits="Account_loginstatus2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Pictures Login Status</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Stl/Style.css" type="text/css" rel="stylesheet">
	    <link href="../Style1.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body>
			<form id="Form1" method="post" runat="server">
			<TABLE align="center" id="Table1" class="tbl" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD class="maintgridheader">Login Status</TD>
				</TR>
				<TR>
					<TD id="rr">
						<asp:Label ID="lblmsg" runat="server" ForeColor="Cyan" Width="100%" Height="80px" CssClass="text" Font-Names="Cambria" Font-Size="11pt"></asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<asp:ImageButton id="icmdclose" runat="server" ImageUrl="../Images/Buttons/cancel.gif" OnClick="icmdclose_Click"></asp:ImageButton></TD>
				</TR>
		  </TABLE>
		</form>
	</body>
</HTML>

