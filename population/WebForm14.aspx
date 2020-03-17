<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="WebForm14.aspx.cs" Inherits="population.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="align-items:center" left="25%" class="auto-style10">
        <tr>
            <td>
                 <asp:Label ID="Label1" runat="server" Text="Create Application"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="Label2" runat="server" Text="HouseHold member 1 of 1"></asp:Label>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="First Name"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="MI"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Last Name"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Suffix"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="fname" runat="server"></asp:TextBox>
            </td>
          
            <td>
                <asp:TextBox ID="mi" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="lname" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="-1">select</asp:ListItem>
                    <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Miss</asp:ListItem>
                    <asp:ListItem>Mrs</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr><td>
            <asp:Label ID="Label9" runat="server" Text="Date of Birth(mm/dd/yyyy)"></asp:Label></td>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Gender"></asp:Label>

            </td>
        </tr>
        
        <tr>
            <td>
                <asp:TextBox ID="dob" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RadioButton ID="male" runat="server" GroupName="gender"/><asp:Label ID="Label7" runat="server" Text="Male"></asp:Label>
            </td>
            <td>
                <asp:RadioButton ID="female" runat="server" GroupName="gender"/><asp:Label ID="Label8" runat="server" Text="Female"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>

            </td>
            <td>

            </td>
            <td>
                <asp:Button ID="Button1" BackColor="GreenYellow" runat="server" Text="Add Member" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button2" BackColor="GreenYellow" runat="server" Text="Save & exit" OnClick="Button2_Click" />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        
        




    </table>
   

    <asp:GridView ID="GridView1" runat="server"></asp:GridView>


</asp:Content>
