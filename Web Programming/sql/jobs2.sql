drop table if exists ld_jobs2;
drop table if exists ld_employers2;
drop table if exists ld_users2;
drop table if exists ld_apps2;

create table ld_jobs2 (
    id int not null auto_increment UNIQUE,
    employerId int not null references ld_employers2(id),
	title varchar(80) not null,
	startdate timestamp,
	enddate timestamp,
	description text default '',
	location varchar(80) not null,
	salary INT not null,
    primary key (id)
);

create table ld_employers2 (
	id int not null auto_increment UNIQUE,
	name varchar(80) not null UNIQUE,
	industry varchar(80) not null,
	description text default '',
	primary key (id)
);

create table ld_users2 (
	employerId int not null references ld_employers2(id),
	email varchar(80) not null UNIQUE,
	password varchar(40) not null,
	realname varchar(40) not null,
	catagory varchar(40) not null,
	phone int not null,
	imagedata blob default "",
	imagename varchar(80) default "",
	imagetype varchar(80) default "",
	details text default "",
	primary key (email),
	key (password)
);

create table ld_apps2 (
	applicant varchar(40) not null references ld_users2(realname),
	jobId int not null references ld_jobs2(id),
	letter text default '',
	appdate timestamp
);

insert into ld_jobs2 (employerId, title, description, location, salary)
values
(1,
 "Supervisor",
 "Full time",
 "Springwood",
 "29000"),
(2,
 "Outdoor Manager",
 "Full time",
 "Garden City",
 "1"),
(3,
 "Register Operator",
 "Part time position",
 "Mount Gravatt",
 "10000"),
(4,
 "Talented Individuals",
 "Marketing team; Full time, contract",
 "Brisbane City",
 "30000"),
(2,
 "Babies R Us Manager",
 "Full time",
 "Garden City",
 "1"),
(2,
 "Store Manager",
 "Full time",
 "Garden City",
 "111111"),
(2,
 "Deputy Store Manager",
 "Full time",
 "Garden City",
 "1"),
(1,
 "Sales Floor",
 "Part time",
 "Garden City",
 "10000"),
(1,
 "Change room staff",
 "Full time",
 "Garden City",
 "15000"),
(2,
 "Register Operator",
 "Full time",
 "Springwood",
 "12000"),
(4,
 "Superman",
 "Fight crime when you want!",
 "Planet Earth",
 "1000000");

insert into ld_employers2 (name, industry, description)
values
("K-Mart",
 "Retail",
 "K-Mart franchise"),
("Toys R Us",
 "Retail",
 "Toys R Us"),
("Woolworths",
 "Retail",
 "Fresh food people"),
("IBM",
 "Info Tech",
 "Computing");
 
insert into ld_users2 (email, password, catagory, employerId, realname)
values
("Admin",
"Ad4O69cwrPVg.",
"administrator",
"0",
"Administrator"),
("Manager",
"MaqhfRMmrq85U",
"manager",
"2",
"Manager"),
("Manager2",
"MaqhfRMmrq85U",
"manager",
"1",
"Manager2"),
("User",
"UsYDL.aGwJlKs",
"user",
"0",
"Random"),
("User2",
"UsYDL.aGwJlKs",
"user",
"0",
"Person");