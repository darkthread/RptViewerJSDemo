<%@ Page Language="C#" %>
<script runat="server">
    void Page_Load(object sender, EventArgs e)
    {
        int delaySec;
        var d = Request["d"];
        if (d == "E") throw new ApplicationException("ERROR");
        if (int.TryParse(Request["d"], out delaySec))
        {
            System.Threading.Thread.Sleep(delaySec * 1000);
        }
        Response.Write(Guid.NewGuid().ToString());
    }
</script>