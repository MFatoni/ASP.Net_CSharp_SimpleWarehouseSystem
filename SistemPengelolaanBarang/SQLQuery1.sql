create table users (nama varchar(50), gender varchar(15), alamat varchar(200), email varchar(50), password varchar(50));

alter table users add telepon varchar(20);
alter table users add password varchar(50);
alter table users drop column password;

create table barang (id_brg int IDENTITY(1,1) PRIMARY KEY, nama_barang varchar(100), jumlah int);
drop table barang;

select * from users;