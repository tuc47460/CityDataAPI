<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cities_Page.aspx.cs" Inherits="Project4.Cities_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <title>Cities Explorer</title>
</head>
<body>
    <%--bootstrap 4 JQuery Code--%>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <form id="form1" runat="server">


        <div class="row mt-3">
            <div class="col-2"></div>
            <div class="col-8">
                <h1>City Information</h1>
            </div>
            <div class="col-2"></div>
        </div>
        <div class="row mt-3">
            <div class="col-1"></div>
            <div class="col-1">
                <asp:Button ID="btnAdd" CssClass="btn btn-success mt-4" runat="server" Text="Add City" Font-Size="16" Width="100%" OnClick="btnAdd_Click" />
            </div>
            <div class="col-2">
                <asp:Label ID="Id" runat="server" Text="Id" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtId" ReadOnly="true" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="lblName" runat="server" Text="Name" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtName" ReadOnly="true" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="lblState" runat="server" Text="State" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtState" ReadOnly="true" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-2"></div>
        </div>
        <div class="row mt-3">
            <div class="col-2"></div>
            <div class="col-2">
                <asp:Label ID="lblPop" runat="server" Text="Population" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtPop" ReadOnly="true" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Label ID="lblMedHI" runat="server" Text="Median Household Income" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtMedHI" ReadOnly="true" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Label ID="lblPercOwn" runat="server" Text="%Home Owners" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtPercOwn" ReadOnly="true" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Label ID="lblPercRent" runat="server" Text="%Home Renters" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtRent" ReadOnly="true" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-2"></div>
        </div>
        <div class="row mt-3">
            <div class="col-2"></div>
            <div class="col-3">
                <asp:Label ID="lblMaleMedAge" runat="server" Text="Male Median Age" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtMaleMedAge" ReadOnly="true" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="lblFemaleMedAge" runat="server" Text="Female Median Age" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtFemaleMedAge" ReadOnly="true" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Label ID="lblUnemploymentRate" runat="server" Text="Unemployment Rate" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtUnemploymentRate" ReadOnly="true" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-2"></div>
        </div>
        <div class="row mt-3">
            <div class="col-2"></div>
            <div class="col-4">
                <asp:Label ID="lblBurgRate" runat="server" Text="Burglary Rate" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtBurgRate" ReadOnly="true" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-4">
                <asp:Label ID="lblVehTheftRate" runat="server" Text="Motor Vehicle Theft Rate" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtVehTheftRate" ReadOnly="true" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-2"></div>
        </div>
        <div class="row mt-3">
            <div class="col-2"></div>
            <div class="col-8">
                <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" Visible="False" Font-Size="16" Width="100%" OnClick="btnSubmit_Click" />
            </div>
            <div class="col-2"></div>
        </div>
        <div class="row mt-3">
            <div class="col-2"></div>
            <div class="col-8">
                <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" Visible="False" Font-Size="16" Width="100%" OnClick="btnCancel_Click" />
            </div>
            <div class="col-2"></div>
        </div>





        <div class="row mt-3">
            <div class="col-2"></div>
            <div class="col-8">
                <h1>Search</h1>
            </div>
            <div class="col-2"></div>
        </div>


        <div class="row mt-3">
            <div class="col-1"></div>
            <div class="col-1">
                <asp:Button ID="btnEdit" CssClass="btn btn-success mt-4" runat="server" Text="Edit City" Font-Size="16" Width="100%" OnClick="btnEdit_Click" />

            </div>
            <div class="col-4">
                <asp:Label ID="lblSearchName" runat="server" Text="City Name" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtSearchName" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-4">
                <asp:Label ID="lblSearchState" runat="server" Text="City State" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtSearchState" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>
            <div class="col-2"></div>
        </div>

        <div class="row mt-3 mb-5">
            <div class="col-2"></div>
            <div class="col-8">
                <asp:Button ID="btnSearch1" CssClass="btn btn-info" runat="server" Text="Search" Font-Size="16" Width="100%" OnClick="btnSearch1_Click" />
            </div>
            <div class="col-2"></div>
        </div>

        <div class="row mt-3">
            <div class="col-2"></div>
            <div class="col-3">
                <asp:Label ID="lblSearchType" runat="server" Text="Search Type" Font-Size="16"></asp:Label>
                <br />
                <asp:DropDownList CssClass="btn btn-info dropdown-toggle" ID="ddlSearchType" runat="server" Font-Size="16">
                    <asp:ListItem Value="CitiesByFemaleMedianAge">Female Median Age</asp:ListItem>
                    <asp:ListItem Value="CitiesByMaleMedianAge">Male Median Age</asp:ListItem>
                    <asp:ListItem Value="CitiesByBurglaryRate">Burglary Rate</asp:ListItem>
                    <asp:ListItem Value="CitiesByVehicleTheftRate">Motor Vehicle Theft Rate</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-3">
                <asp:Label ID="lblOp" runat="server" Text="Search Operation" Font-Size="16"></asp:Label>
                <br />
                <asp:DropDownList CssClass="btn btn-info dropdown-toggle" ID="ddlSearchOp" runat="server" Font-Size="16">
                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                    <asp:ListItem Value="!=">Not equal to</asp:ListItem>
                    <asp:ListItem Value="<">Less than</asp:ListItem>
                    <asp:ListItem Value=">">Greater than</asp:ListItem>
                    <asp:ListItem Value="<=">Less than or equal to</asp:ListItem>
                    <asp:ListItem Value=">=">Greater than or equal to</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-2">
                <asp:Label ID="lblTargetVal" runat="server" Text="Target Value" Font-Size="16"></asp:Label>
                <asp:TextBox ID="txtTargetVal" CssClass="form-control" runat="server" Font-Size="16" Width="100%"></asp:TextBox>
            </div>

            <div class="col-2"></div>
        </div>
        <div class="row mt-3 mb-5">
            <div class="col-2"></div>
            <div class="col-8">
                <asp:Button ID="btnSearch2" CssClass="btn btn-info" runat="server" Text="Search" Font-Size="16" Width="100%" OnClick="btnSearch_Click" />
            </div>
            <div class="col-2"></div>
        </div>
        <div class="row mt-3 mb-5">
            <div class="col-2"></div>
            <div class="col-8">
                <asp:Label ID="lblWarning" CssClass="btn-danger" runat="server" Text="Target Value" Font-Size="16" Visible="False"></asp:Label>
            </div>
            <div class="col-2"></div>
        </div>





        <div runat="server" id="container">
        </div>
    </form>
</body>
</html>
