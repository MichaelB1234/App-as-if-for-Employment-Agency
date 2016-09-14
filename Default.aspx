<%@ Page Language="C#"  MasterPageFile="~/Pictures.master"  MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Piclist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" Runat="Server">
    <style type="text/css">
.gridview .EditRowStyle {
    background-color: rgba(241,235,215,0.1);
    color: rgba(0,0,0,1.0);
    font-weight:700;    
    border: 2px inset rgba(0,0,0,0.2);    
}
.gridview .FooterStyle {
    background-color: rgba(241,235,215,0.1);
    font-weight:700;
    font-size:large;
    color: rgba(0,0,0,1.0);
    border: 2px inset rgba(0,0,0,0.2);
}
.gridview .HeaderStyle {
    background-color: rgba(241,235,215,0.1);
    font-weight:700;
    font-size:medium;
    color: rgba(0,255,0,1.0);
    border: 2px inset rgba(0,0,0,0.2);
}

.gridview .PagerStyle {
    background-color: rgba(241,235,215,0.1);
    font-weight:700;
    font-size:x-large;
    align-content: center;
    color: rgba(0,0,0,1.0);
    border: 2px inset rgba(0,0,0,0.2);
}
.gridview .RowStyle {
    background-color: transparent;
    color: rgba(0,255,0,1.0);
    font-weight:700;
    font-size:x-small;
    border: 2px inset rgba(0,0,0,0.2);
}
.gridview .AlternatingRowStyle {
    background-color: transparent;
    color: rgba(0,0,255,1.0);
    font-weight:700;
    font-size:x-small;
    border: 2px inset rgba(0,0,0,0.2);
   }
.gridview .SelectedRowStyle {
    background-color: rgba(255,255,255,0.1);
    color: rgba(0,0,0,1.0);
    font-weight:700;
    font-size:x-small;
    border: 2px inset rgba(0,0,0,0.2);
   }
.gridview .SortedAscendingCellStyle {
    background-color: rgba(224,224,224,0.1);
    color: rgba(0,0,0,1.0);
    font-weight:700;
    font-size:x-small;
   border: 2px inset rgba(0,0,0,0.2);
}
.gridview .SortedAscendingHeaderStyle {
    background-color: rgba(24,24,24,0.7);
     color: rgba(0,0,0,1.0);
    font-weight:700;
    font-size:x-small;
   border: 2px inset rgba(0,0,0,0.2);
}
.gridview .SortedDescendingCellStyle {
      background-color: rgba(25,25,25,0.1);
       color: rgba(0,0,0,1.0);
    font-weight:700;
    font-size:x-small;
   border: 2px inset rgba(0,0,0,0.2);
}
 .gridview .SortedDescendingHeaderStyle {

   background-color:  rgba(224,224,224,0.7);
    color: rgba(0,0,0,1.0);
    font-weight:700;
    font-size:x-small;
   border: 2px inset rgba(0,0,0,0.2);
 }         
.gridview-pager {
        background-color:rgba(255,255,255,.3);
        padding:2px;
        margin:2% auto;
}
.gridview-pager a{
        margin:auto 1%;
        background-color:rgba(200,200,172,.3);
        padding:5px 10px 5px 10px;
        color:rgba(255,255,255,1.0);
        text-decoration:none;
        -moz-box-shadow:1px 1px 1px #111;
        -webkit-box-shadow:1px 1px 1px #111;
        box-shadow:1px 1px 1px #111;
} 
.gridview-pager a:hover {
        background-color:rgba(253,227,167,.3);
        color:rgba(255,255,255,1.0);
}    
.gridview-pager span {
        background-color:rgba(88,157,203,.3);
        color:rgba(255,255,255,1.0);
        -moz-box-shadow:1px 1px 1px #111;
        -webkit-box-shadow:1px 1px 1px #111;
        box-shadow:1px 1px 1px #111;
        padding:5px 10px 5px 10px;
}
body {
       background-color: #F7F7F2;
       font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
}
.control-label {
       text-align:right;
}
.form-group select {
       max-width:100%;
}
.section-header {
        text-align: center; 
        background-color: rgba(255,255,255,.3); 
        color:rgb(0,255,0);
        height: 25px; 
        line-height: 25px;
}
.glyphicon-calendar {
       color: #E05711;
}

.modal-body .form-horizontal .col-sm-2,
.modal-body .form-horizontal .col-sm-10 
    {
    width: 100%;
}

.modal-body .form-horizontal .control-label {
    text-align: left;
}
.modal-body .form-horizontal .col-sm-offset-2 {
    margin-left: 15px;
}
.action.btn {
    background-color:darkorange;
    color:rgba(255,255,255,.3);
}
.action.btn:hover {
    background-color:orange;
    color:rgba(255,255,255,.3);
}
#images
{ text-align:center;
    margin:5px; 
}
#images a
{
    margin:4px 7px 2px 4px;
    display:inline-block;
    text-decoration:none;
    
 }
#comments
{ text-align:center;
    margin:5px; 
}
#comments a
{
    margin:4px 7px 2px 4px;
    display:inline-block;
    text-decoration:none;
    
 }

</style>      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <asp:Panel ID="UpdatePanel1" runat="server" Style="color: rgba(0,0,0,1.0); align-content: center; font-weight: 700; background-color: rgba(0,0,0,.3);">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <div style="padding: 0px;">                
                <div style="vertical-align: top; padding: 0px 2px; float: left;">
                    <div>
                        <asp:Label CssClass="label-info" ID="Label19" Text="Candidate Name and Job Title" runat="server" BackColor="Transparent" ForeColor="White"></asp:Label>
                    </div>                    
                    <div>
                        <asp:TextBox ID="txtBeforeAdd" BackColor="Transparent" ForeColor="White" runat="server" ToolTip="About Candidate" Width="250" Height="100" MaxLength="1000" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                 <div style="vertical-align: top; padding: 0px 2px; float: left;">
                    <asp:Label CssClass="label-info" ID="Label1" Text="Upload File\s" runat="server" BackColor="Transparent" ForeColor="White"></asp:Label>
                    <asp:FileUpload ID="FileUploadInsert" runat="server" ToolTip="Upload File Dialog" AllowMultiple="True" BackColor="Transparent" ForeColor="White" />
                </div>              
                <div style="vertical-align: top; padding: 0px 2px; float: left">
                    <asp:Button Text="Add Candidate Row" CssClass="btn-primary" runat="server" OnClick="InsertPictures_Click"></asp:Button>
                </div>
                <asp:Panel runat="server" Style="max-height: 100px; max-width: 200px; float: right; padding: 0px 2px;">
                    <asp:Label CssClass="label-info" ID="MessageForUser" Text="Ready" runat="server" ForeColor="White" BackColor="Transparent"></asp:Label>
                </asp:Panel>
            </div>
            <br />
        </div>
        <div style="height: 10px; width: 100%"></div>
        <div class="col-lg-12 col-md-12 col-sm-12">
            <input id="Hidden1" type="hidden" value="" />
            <asp:GridView ID="PictureListGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MenuID,Retired" AllowPaging="False" AllowSorting="False" OnRowCancelingEdit="PictureListGridView_RowCancelingEdit" OnRowEditing="PictureListGridView_RowEditing" OnRowUpdating="PictureListGridView_RowUpdating" HorizontalAlign="Center" AlternatingRowStyle-VerticalAlign="Top" RowStyle-VerticalAlign="Top" SelectedRowStyle-VerticalAlign="Top" OnRowUpdated="PictureListGridView_RowUpdated" OnRowDeleting="PictureListGridView_RowDeleting" ShowHeaderWhenEmpty="True">
                <PagerStyle HorizontalAlign="Center" CssClass="gridview-pager" />
                <PagerSettings Mode="NumericFirstLast" Position="Top" />
                <AlternatingRowStyle CssClass="AlternatingRowStyle" />
                <HeaderStyle CssClass="HeaderStyle" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div style="vertical-align: top; padding: 5px 2px; float: left">
                                <asp:Button ID="EditButton"
                                    runat="server"
                                    CssClass="btn-primary"
                                    CommandName="Edit" Text=" Modify" />
                            </div>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div style="vertical-align: top; padding: 5px 2px;">
                                <div style="vertical-align: top; padding: 5px 2px;">
                                    <asp:Button ID="Cancel"
                                        runat="server"
                                        CssClass="btn-primary"
                                        CommandName="Cancel" Text=" Cancel" />
                                </div>
                                <div style="vertical-align: top; padding: 5px 2px;">
                                    <asp:Button ID="UpdateButton"
                                        runat="server"
                                        CssClass="btn-primary"
                                        CommandName="Update" Text=" Apply" />
                                </div>
                                <div style="vertical-align: top; padding: 5px 2px;">
                                    <asp:Button ID="DeleteButton"
                                        runat="server"
                                        CssClass="btn-primary"
                                        CommandName="Delete" Text=" Delete" />
                                </div>
                            </div>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:HiddenField ID="Hidden1"
                                Value='<%#ProcessMyDataItem(Eval("MenuItemID"))%>'
                                runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" EmploymentAgencyAppDemo " SortExpression="OpinionDescription" HeaderStyle-HorizontalAlign="Center" ControlStyle-ForeColor="White" HeaderStyle-ForeColor="White" FooterStyle-ForeColor="White" ItemStyle-ForeColor="White">
                        <ItemTemplate>
                            <div style="background-color: Transparent; color: White; vertical-align: top; padding: 0px 2px; float: left;">
                                <div id='images'>
                                    <%# PicsLink((Eval("MenuItemID")))%>
                                </div>
                                            
                                <%#ProcessMyDataItem(Eval("BeforeDescription"))%>                                
                                <div id='comments'>
                                   <%#OpinionDescription((Eval("MenuItemID")))%>
                                </div>                        
                            </div>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div style="vertical-align: top; padding: 0px 2px; float: left;">
                                <div>
                                    <asp:Label ID="Label18"
                                        Text="Files"
                                        runat="server" />
                                </div>
                                <div>
                                    <div id='images'>
                                        <%# PicsLink((Eval("MenuItemID")))%>
                                    </div>
                                    <div id='images2'>
                                        <%# PicsLinkDelete((Eval("MenuItemID")))%>
                                        
                                    </div>
                                </div>
                            </div>
                            <div style="vertical-align: top; padding: 0px 2px; float: left;">
                                <div>
                                    <asp:Label ID="Label13"
                                        Text="Candidate Name and Job Title"
                                        runat="server" />
                                </div>
                                <div id='Opinions'>
                                    <asp:TextBox ID="txtAsk"
                                        Text='<%#ProcessMyDataItem(Eval("BeforeDescription"))%>'
                                        runat="server" TextMode="MultiLine" Height="100" 
                                        Width="250" MaxLength="1000" BackColor="Transparent" ForeColor="White" />                                    
                                </div>
                                
                            </div>     
                            <div style="vertical-align: top; padding: 0px 2px; float: left;">
                                <div>
                                    <asp:Label ID="Label15"
                                        Text="Upload file/s"
                                        runat="server" />
                                </div>
                                <div>
                                    <asp:FileUpload ID="FileUpload" runat="server" BackColor="Transparent" ForeColor="White" AllowMultiple="True" />
                                </div>
                            </div>
                                                   
                            <div style="vertical-align: top; padding: 0px 2px; float: left;">
                                
                                 <div id='comments'>
                                   <%#OpinionDescription((Eval("MenuItemID")))%>
                                </div>                                   
                            </div>                           
                            <div style="vertical-align: top; padding: 0px 2px; float: left;">
                                <div>
                                    <asp:Label ID="Label14"
                                        Text="Candidate Comments"
                                        runat="server" />
                                </div>
                                <div>
                                    <asp:TextBox runat="server" ID="txtOpinion" 
                                        MaxLength="970" TextMode="MultiLine" Rows="5" 
                                        Width="500" BackColor="Transparent" Columns="194"></asp:TextBox>
                                </div>
                            </div>                           
                        </EditItemTemplate>
                        <ControlStyle ForeColor="White" />
                        <FooterStyle ForeColor="White" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle ForeColor="White" />
                    </asp:TemplateField>                 
                </Columns>
                <EditRowStyle CssClass="EditRowStyle" />
                <FooterStyle CssClass="FooterStyle" />
                <HeaderStyle CssClass="HeaderStyle" />
                <PagerStyle CssClass="PagerStyle" />
                <RowStyle CssClass="RowStyle" />
                <SelectedRowStyle CssClass="SelectedRowStyle" />
            </asp:GridView>
            <asp:SqlDataSource ID="ListSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT DISTINCT M.MenuItemID, M.MenuID, M.MenuCategoryID, M.MenuItemDescription, M.OpinionDescription, M.AfterDescription, M.Retired FROM MenuItems AS M INNER JOIN Files AS F ON M.MenuItemID = F.MenuItemID WHERE (ISNULL(M.Retired, 0) = 0) GROUP BY F.BeforeItem, F.AfterItem, M.MenuItemID, M.MenuID, M.MenuCategoryID, M.MenuItemDescription, M.OpinionDescription, M.AfterDescription, M.Retired"></asp:SqlDataSource>
            <br />
        </div>
    </asp:Panel>
</asp:Content>




