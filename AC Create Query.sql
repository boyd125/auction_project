create table Auction(
	org varchar(50),
	contact varchar(50),
	contact_num varchar(50),
	date_time datetime,
	intake varchar(50),
	exp_num_item int,
	comments varchar(500),
	primary key(org)
)

create table Item(
	item_name varchar(50),
	auction varchar(50),
	quantity int,
	start_bid decimal(2),
	donor varchar(50),
	sell_price decimal(2),
	condition varchar(50),
	comments varchar(500),
	photo varchar(100),
	primary key(item_name),
	foreign key(auction) references Auction(org)
)

create table Bidder(
	account_email varchar(50),
	account_password varchar(50),
	first_name varchar(50),
	last_name varchar(50),
	phone varchar(12),
	street varchar(50),
	city varchar(50),
	states varchar(50),
	zip varchar(50),
	credit_card varchar(19),
	primary key(email)
)

create table Bid(
	bidder varchar(50),
	auction varchar(50),
	item varchar(50),
	bid decimal(2),
	foreign key(bidder) references Bidder(account_email),
	foreign key(auction) references Auction(org),
	foreign key(item) references Item(item_name),
	primary key(bidder)
)


