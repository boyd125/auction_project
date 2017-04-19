--create tables

--base tables

create table Auction_Org(
	org varchar(50),
	primary key(org)
)

create table Employee_Account(
	account_email varchar(50),
	account_password varchar(50)
	primary key(account_email)
)

create table NPO_Rep_Account(
	account_email varchar(50),
	account_password varchar(50),
	primary key (account_email)
)

create table Item_Auction_ID(
	item_name varchar(50),
	auction varchar(50),
	id int,
	primary key(id)
)

create table Bidder_Account(
	account_email varchar(50),
	account_password varchar(50),
	primary key(account_email)
)

--foreign tables

create table Auction_Contact(
	org varchar(50),
	contact varchar(50),
	foreign key(org) references Auction_Org(org),
	foreign key(contact) references NPO_Rep_Account(account_email),
	primary key(org, contact)
)

create table Auction_Date_Time(
	org varchar(50),
	date_time datetime,
	foreign key(org) references Auction_Org(org),
	primary key(org)
)

create table Auction_Intake(
	org varchar(50),
	intake varchar(50),
	foreign key(org) references Auction_Org(org),
	foreign key(intake) references Employee_Account(account_email),
	primary key(org, intake)
)

create table Auction_Exp_Num_Items(
	org varchar(50),
	exp_num_items int,
	foreign key(org) references Auction_Org(org),
	primary key(org)
)

create table Auction_Comments(
	org varchar(50),
	comments varchar(500),
	foreign key(org) references Auction_Org(org),
	primary key(org)
)

create table Employee_Name(
	employee varchar(50),
	full_name varchar(50),
	foreign key (employee) references Employee_Account (account_email),
	primary key (employee)
)

create table NPO_Rep_Name(
	rep varchar(50),
	full_name varchar(50),
	foreign key(rep) references NPO_Rep_Account(account_email),
	primary key(rep)
)

create table NPO_Rep_Phone(
	rep varchar(50),
	phone varchar(14),
	foreign key(rep) references NPO_Rep_Account(account_email),	
	primary key(rep)
)

create table Item_Quantity(
	id int,
	quantity int,
	foreign key(id) references Item_Auction_ID(id),
	primary key (id)
)

create table Item_Start_Bid(
	id int,
	start_bid decimal(10, 2),
	foreign key(id) references Item_Auction_ID(id),
	primary key (id)
)

create table Item_Donor(
	id int,
	donor varchar(50),
	foreign key(id) references Item_Auction_ID(id),
	primary key (id)
)

create table Item_Sell_Price(
	id int,
	sell_price decimal(10, 2),
	foreign key(id) references Item_Auction_ID(id),
	primary key (id)
)

create table Item_Condition(
	id int,
	condition varchar(50),
	foreign key(id) references Item_Auction_ID(id),
	primary key (id)
)

create table Item_Comments(
	id int,
	comments varchar(500),
	foreign key(id) references Item_Auction_ID(id),
	primary key (id)	
)

create table Item_Photo(
	id int,
	photo varchar(500),
	foreign key(id) references Item_Auction_ID(id),
	primary key (id)
)

create table Bidder_Name(
	bidder varchar(50),
	full_name varchar(50),
	foreign key(bidder) references Bidder_Account(account_email),
	primary key(bidder)
)

create table Bidder_Phone(
	bidder varchar(50),
	phone varchar(14),
	foreign key(bidder) references Bidder_Account(account_email),
	primary key(bidder)
)

create table Bidder_Payment(
	bidder varchar(50),
	credit_card varchar(19),
	foreign key(bidder) references Bidder_Account(account_email),
	primary key(bidder)
)

create table Bidder_Street_Address(
	bidder varchar(50),
	street varchar(50)
	foreign key(bidder) references Bidder_Account(account_email),
	primary key(street)
)

create table Full_Address(
	street varchar(50),
	city varchar(50),
	us_state varchar(50),
	zip varchar(50),
	foreign key(street) references Bidder_Street_Address(street) on update cascade,
	primary key(street)
)

create table Bid(
	bidder varchar(50),
	auction varchar(50),
	item int,
	bid decimal(10, 2),
	foreign key(bidder) references Bidder_Account(account_email),
	foreign key(auction) references Auction_Org(org),
	foreign key(item) references Item_Auction_ID(id),
	primary key(bidder, auction, item)
)


--select org from Auction_Contact where contact = 'email'