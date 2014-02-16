<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoWebApp.Default" Title="Automated Testing Challenge" %>

<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<%@ Import Namespace="DemoWebApp.Model" %>

<script runat="server">

    protected override void OnLoad(EventArgs args)
    {
        var directory = new DirectoryInfo(@"C:\Temp\DemoWebApp\");
        var clientFileInfos = directory.GetFiles();

        var db = new ClientDataContext();

        db.Accounts.RemoveRange(db.Accounts);
        db.Clients.RemoveRange(db.Clients);
        db.SaveChanges();
        
        foreach (var clientFile in clientFileInfos)
        {
            var json = File.ReadAllText(clientFile.FullName);
            var importClient = new JavaScriptSerializer().Deserialize<Client>(json);

            var existingClient = db.Clients.FirstOrDefault(x => x.Key == importClient.Key);
            if (existingClient == null)
            {
                db.Clients.Add(importClient);
            }
            else
            {
                existingClient.Address = importClient.Address;
                existingClient.Name = importClient.Name;
                
                // TODO: Update accounts
            }
        }
        
        db.SaveChanges();

        HttpContext.Current.Items["Clients"] = db.Clients.ToList();
    }

    protected static string TimeSinceNow(DateTime val)
    {
        var difference = DateTime.Now - val;
        var totalDays = difference.TotalDays;
        int years = (int)totalDays/365;
        int days = (int)totalDays % 365;
            
        return string.Format("{0} years, {1} days", years, days);
    }

</script>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS -->
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css">

    <!-- Optional theme -->
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap-theme.min.css">

    <!-- Just for debugging purposes. Don't actually copy this line! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>

<body>

    <form id="form1" runat="server">

    <div class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#"><%= Page.Title %></a>
            </div>
            <!--/.navbar-collapse -->
        </div>
    </div>

    <!-- Main jumbotron for a primary marketing message or call to action -->
    <div class="jumbotron">
        <div class="container">
            <h1>Client Account List</h1>
        </div>
    </div>

    <div class="container">

        <%
            var clients = HttpContext.Current.Items["Clients"] as List<Client>;
        %>

        <div class="row">
        <% foreach (var client in clients) { %>
            <div class="col-md-4">
                <h2><%= client.Name %></h2>
                <p><span class="text-muted">(Client for <%= TimeSinceNow(client.CreatedOn) %>)</span></p>
                <p><label>Address</label> <br/> <span><%= client.Address %></span> </p>
                <p><label>Accounts</label> (<%=client.Accounts.Count %>)
                    <ul>
                    <% foreach(var account in client.Accounts) { %>
                        <li>
                            <strong><%=account.AccountNumber %>:</strong>
                            <span>[<%= account.Type %>]</span>
                            <span><%= account.Balance.ToString("C") %></span>
                        </li>
                    <% } %>
                    </ul> 
                </p>
            </div>
        <% } %>
        </div>

        <hr>

        <footer>
            <p>&copy; Company 2014</p>
        </footer>
    </div>
    <!-- /container -->

    </form>


    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>

</body>
</html>

