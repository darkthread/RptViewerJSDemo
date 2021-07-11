<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoReport.aspx.cs" Inherits="DemoWeb.Reports.DemoReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title></title>
    <style>
        html, body, form, #divReport {
            height: 100%;
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: none">
            <input type="text" id="st" name="st" readonly />
            <input type="text" id="ed" name="ed" readonly />
            <input type="text" id="s" name="s" readonly />
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="divReport">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="100%" Width="100%">
            </rsweb:ReportViewer>
        </div>
        <script>
            if (parent && parent.hideLoadingAnimation) parent.hideLoadingAnimation();
        </script>
    </form>
</body>
</html>
