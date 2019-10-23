<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="barangubah.aspx.cs" Inherits="SistemPengelolaanBarang.panel.ubahbarang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aplikasi Pengelolaan Barang</title>
	<meta charset="utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	<link rel="stylesheet" type="text/css" href="../assets/style.css"/>
	<link rel="stylesheet" type="text/css" href="../assets/BootstrapV4.1.3/css/bootstrap.css"/>
	<script type="text/javascript" src="../assets/Jquery/jquery-3.2.1.js"></script>
	<script type="text/javascript" src="../assets/BootstrapV4.1.3/js/bootstrap.js"></script>
	<script type="text/javascript" src="../assets/js.js"></script>
	<link rel="stylesheet" href="../assets/Font Awesome/css/font-awesome.css"/>
</head>
<body>
    <div class="container-fluid">
        <form id="form1" runat="server">
		<div class="row ">
			<div class="col-lg-2 nopadding">
				<div class="nav-side-menu">
					<div class="brand">Aplikasi Pengelolaan Barang</div>
					<i class="fa fa-bars fa-2x toggle-btn" data-toggle="collapse" data-target="#menu-content"></i>
					<div class="menu-list p-3">
						<div class="px-1"><span class="fa fa-user"></span> <b>Administrator</b></div>
						<ul id="menu-content" class="menu-content collapse out pl-2">
							<li class="p-1 mt-1">
								<a href="index.aspx"><i class="fa fa-home"></i> Beranda </a>
							</li>
							<li class="p-1">
								<a href="barang.aspx"><i class="fa fa-pencil-square-o"></i> Daftar Produk</a>
							</li>
							<li class="p-1">
								<a href="user.aspx"><i class="fa fa-pencil-square-o"></i> Daftar Akun</a>
							</li>
							<li class="p-1">
								<a href="laporan.aspx"><i class="fa fa-pencil-square-o"></i> Laporan</a>
							</li>
							<li class="p-1">
								<a><i class="fa fa-sign-out"></i>
                                    <asp:Button ID="Button1" runat="server" Text="Keluar" cssClass="btn btn-outline-light" OnClick="btnlogout"/></a>
							</li>
						</ul>
					</div>
				</div>
			</div>
			<div class="col-lg-10">
                <div class="info-page">
					<h5 class="ml-2 mt-2"><strong><i>&nbsp<i class="fa fa-suitcase"></i> Input Data Baru Untuk Update Data Lama </i></strong></h5>
					<hr/>
				</div>
                <div class="row py-2">
                    <div class="col-lg-2"><asp:Label runat="server">Nama Produk</asp:Label></div>
                    <div class="col-lg-10">
                        <div class="form-group">
                            <asp:TextBox ID="txtNama" runat="server" class="form-control" TextMode="SingleLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-2"><asp:Label runat="server">Keterangan</asp:Label></div>
                    <div class="col-lg-10">
                        <div class="form-group">
                        <asp:TextBox ID="txtKet" runat="server" class="form-control" TextMode="SingleLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="text-right">
						    <asp:Button ID="btnUbah" runat="server" Text="UBAH" OnClick="btnInput_Click" cssClass="btn btn-success"/>
					    </div>
                    </div>
                </div>
            </div>
		</div>
        </form>
	</div>
</body>
</html>
