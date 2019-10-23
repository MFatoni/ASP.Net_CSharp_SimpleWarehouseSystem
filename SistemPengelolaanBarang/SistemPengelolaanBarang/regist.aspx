<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="regist.aspx.cs" Inherits="SistemPengelolaanBarang.regist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aplikasi Pengelolaan Barang</title>
	<meta charset="utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	<link rel="stylesheet" type="text/css" href="assets/style.css"/>
	<link rel="stylesheet" type="text/css" href="assets/BootstrapV4.1.3/css/bootstrap.css"/>
	<script type="text/javascript" src="assets/Jquery/jquery-3.2.1.js"></script>
	<script type="text/javascript" src="assets/BootstrapV4.1.3/js/bootstrap.js"></script>
	<script type="text/javascript" src="assets/js.js"></script>
	<link rel="stylesheet" href="Assets/Font Awesome/css/font-awesome.css"/>
	<style type="text/css">
		body {
			background-image: url(assets/img/backgroundgudang.jpg);
			background-attachment: fixed;
			background-position: center;
			background-repeat: no-repeat;
			background-size: cover;
		}
	</style>
</head>
<body>
    <div class="container text-white">
		<div class="row align-items-center justify-content-center" style="height:100vh;">     
			<div class="col-4 bg-main rounded p-3">
				<h1 class="text-center pt-2" style="font-size: 5em"><span class="fa fa-users"></span></h1>
				<form class="py-2" id="form1" runat="server">
					<div class="form-group">
                        <asp:TextBox ID="Nama" runat="server" placeholder="Nama" class="form-control" ></asp:TextBox>
					</div>
					<div class="form-group">
                        <textarea id="Alamat" name="Alamat" cols="20" rows="3" class="form-control" placeholder="Alamat"></textarea>
					</div>
					<div class="form-group">
						<asp:TextBox ID="Email" class="form-control" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
					</div>
					<div class="form-group">
						<asp:TextBox ID="Telepon" class="form-control" runat="server" placeholder="No Telepon"></asp:TextBox>
					</div>
					<div class="form-group">
						<asp:TextBox ID="Password" class="form-control" runat="server" TextMode="Password" placeholder="Kata Sandi"></asp:TextBox>
					</div>
					<div class="text-right">
                        <asp:Button ID="RegistAcc" runat="server" Text="DAFTAR" OnClick="Regist_Click" CssClass="btn btn-light" />
					</div>
					<small style="font-size: 11px"><br/><center>Sudah Punya Akun ? <a href="index.aspx">Login Disini</a></center></small>
				</form>
			</div>
		</div>
	</div>
</body>
</html>
