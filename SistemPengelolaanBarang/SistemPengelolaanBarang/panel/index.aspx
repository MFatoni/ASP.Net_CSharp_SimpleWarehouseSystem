<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SistemPengelolaanBarang.panel.index" %>

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
	<script src="../assets/Chart/Chart.bundle.js"></script>
</head>
<body>
    <div class="container-fluid">
        <form runat="server">
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
								<a ><i class="fa fa-sign-out"></i>
                                    <asp:Button ID="Button1" runat="server" Text="Keluar" cssClass="btn btn-outline-light" OnClick="btnlogout"/></a>
							</li>
						</ul>
					</div>
				</div>
			</div>
			<div class="col-lg-10">
				<div class="info-page">
					<h5 class="ml-2 mt-2"><strong><i>&nbsp<i class="fa fa-home"></i> Beranda </i></strong></h5>
					<hr/>
				</div>
				<div class="row text-center mx-2">
					<div class="col-lg-5 mx-auto p-5 bg-light rounded my-2">
						<h4>Jumlah Barang Tersedia</h4>
						<h1>27</h1>
					</div>
					<div class="col-lg-5 mx-auto p-5 bg-light rounded my-2">
						<h4>Jumlah Barang Habis</h4>
						<h1>0</h1>
					</div>
				</div>
				<div class="row mx-2">
					<div class="col-lg-5 mx-auto bg-light rounded p-5 my-2">
						<h4 class="text-center ">Bagan Barang Masuk</h4><br/>
						<div class="row" >
							<canvas id="myChart" style="position: relative; height:40vh; width:100%"></canvas>
							<script>
								var ctx = document.getElementById("myChart").getContext('2d');
								var myChart = new Chart(ctx, {
									type: 'bar',
									data: {
										labels: ["Senin","Selasa","Rabu","Kamis","Jumat","Sabtu"],
										datasets: [
										{data: [6,3,2,9,6,5,3],
											backgroundColor: ['rgba(255, 99, 132, 0.2)','rgba(54, 162, 235, 0.2)','rgba(255, 206, 86, 0.2)','rgba(75, 192, 192, 0.2)','rgba(153, 102, 255, 0.2)','rgba(255, 159, 64, 0.2)','rgba(255, 99, 132, 0.2)','rgba(54, 162, 235, 0.2)','rgba(255, 206, 86, 0.2)','rgba(75, 192, 192, 0.2)','rgba(153, 102, 255, 0.2)','rgba(255, 159, 64, 0.2)'],
											borderColor: ['rgba(255,99,132,1)','rgba(54, 162, 235, 1)','rgba(255, 206, 86, 1)','rgba(75, 192, 192, 1)','rgba(153, 102, 255, 1)','rgba(255, 159, 64, 1)','rgba(255,99,132,1)','rgba(54, 162, 235, 1)','rgba(255, 206, 86, 1)','rgba(75, 192, 192, 1)','rgba(153, 102, 255, 1)','rgba(255, 159, 64, 1)'],
											borderWidth: 1}]
										},
										options: {
											scales: {yAxes: [{ticks: {beginAtZero:true}}]},
											legend: {
												display: false
											},
										}
									});
								</script>
							</div>
						</div>
						<div class="col-lg-5 mx-auto bg-light rounded p-5 my-2">
							<h4 class="text-center">Bagan Barang Keluar</h4><br/>
							<div class="row" >
								<canvas id="myChart1" style="position: relative; height:40vh; width:100%"></canvas>
								<script>
									var ctx = document.getElementById("myChart1").getContext('2d');
									var myChart = new Chart(ctx, {
										type: 'bar',
										data: {
											labels: ["Senin","Selasa","Rabu","Kamis","Jumat","Sabtu"],
											datasets: [
											{data: [4,6,4,2,6,9,2],
												backgroundColor: ['rgba(255, 99, 132, 0.2)','rgba(54, 162, 235, 0.2)','rgba(255, 206, 86, 0.2)','rgba(75, 192, 192, 0.2)','rgba(153, 102, 255, 0.2)','rgba(255, 159, 64, 0.2)','rgba(255, 99, 132, 0.2)','rgba(54, 162, 235, 0.2)','rgba(255, 206, 86, 0.2)','rgba(75, 192, 192, 0.2)','rgba(153, 102, 255, 0.2)','rgba(255, 159, 64, 0.2)'],
												borderColor: ['rgba(255,99,132,1)','rgba(54, 162, 235, 1)','rgba(255, 206, 86, 1)','rgba(75, 192, 192, 1)','rgba(153, 102, 255, 1)','rgba(255, 159, 64, 1)','rgba(255,99,132,1)','rgba(54, 162, 235, 1)','rgba(255, 206, 86, 1)','rgba(75, 192, 192, 1)','rgba(153, 102, 255, 1)','rgba(255, 159, 64, 1)'],
												borderWidth: 1}]
											},
											options: {
												scales: {yAxes: [{ticks: {beginAtZero:true}}]},
												legend: {
													display: false
												},
											}
										});
									</script>
								</div>
							</div>
						</div>
					</div>
				</div>
            </form>
			</div>
</body>
</html>
