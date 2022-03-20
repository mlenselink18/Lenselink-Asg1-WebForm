<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lenselink_Asg1_WebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lenselink Asg1 Web Form Calculator</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>
                Michael Lenselink Asg1 Web Form
            </h1>
        </div>
        <asp:Panel ID="PanelCalculator" runat="server" Height="229px">
            *non-numeric input is converted to zero*<br />
            <br />
            <asp:TextBox ID="TextBoxInput1" runat="server"></asp:TextBox>
            &nbsp;&nbsp;<asp:Label ID="LabelOperator" runat="server" Text="Label" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBoxInput2" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp; =&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBoxOutput" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelError" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="+" />
            &nbsp;<asp:Button ID="ButtonSubtract" runat="server" OnClick="ButtonSubtract_Click" Text="-" />
            &nbsp;<asp:Button ID="ButtonMultiply" runat="server" OnClick="ButtonMultiply_Click" Text="*" Width="22px" />
            &nbsp;<asp:Button ID="ButtonDivide" runat="server" OnClick="ButtonDivide_Click" Text="/" />
            <br />
            <br />
            <asp:Button ID="ButtonOne" runat="server" OnClick="NumberButton_Click" Text="1" />
            <asp:Button ID="ButtonTwo" runat="server" OnClick="NumberButton_Click" Text="2" />
            <asp:Button ID="ButtonThree" runat="server" OnClick="NumberButton_Click" Text="3" />
            <br />
            <asp:Button ID="ButtonFour" runat="server" OnClick="NumberButton_Click" Text="4" />
            <asp:Button ID="ButtonFive" runat="server" OnClick="NumberButton_Click" Text="5" />
            <asp:Button ID="ButtonSix" runat="server" OnClick="NumberButton_Click" Text="6" />
            <br />
            <asp:Button ID="ButtonSeven" runat="server" OnClick="NumberButton_Click" Text="7" />
            <asp:Button ID="ButtonEight" runat="server" OnClick="NumberButton_Click" Text="8" />
            <asp:Button ID="ButtonNine" runat="server" OnClick="NumberButton_Click" Text="9" />
            <br />
            &nbsp;<asp:Button ID="ButtonNegative" runat="server" OnClick="NumberButton_Click" Text="-" />
            <asp:Button ID="ButtonZero" runat="server" OnClick="NumberButton_Click" Text="0" />
            <asp:Button ID="ButtonDot" runat="server" OnClick="NumberButton_Click" Text="." />
            <br />
            <br />
            <asp:Button ID="ButtonSolve" runat="server" OnClick="ButtonSolve_Click" Text="=" />
&nbsp;
            <asp:Button ID="ButtonReset" runat="server" OnClick="ButtonReset_Click" style="height: 29px" Text="CE" />
        </asp:Panel>
    </form>
</body>
</html>
