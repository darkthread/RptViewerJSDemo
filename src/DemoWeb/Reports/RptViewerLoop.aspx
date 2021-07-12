<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptViewerLoop.aspx.cs" Inherits="DemoWeb.Reports.RptViewerLoop" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ReportViewer Infinite Loop</title>
    <style>
        html, body, form, #divReport {
            height: 100%;
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="divReport">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="100%" Width="100%">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
