<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmReporte.aspx.cs" Inherits="TS.SSC.Portal.Reportes.frmReporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hlinkRetornar" runat="server" NavigateUrl="~/Reporte/Index">Retornar</asp:HyperLink>
        </div>

        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="rvReporte" runat="server" Height="600px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
