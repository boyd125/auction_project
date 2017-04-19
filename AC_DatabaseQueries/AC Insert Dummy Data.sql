set nocount on

--base tables
insert into Auction_Org(org)
	values
		('WWO'), 
		('UNICEF'), 
		('Red Cross')

insert into Employee_Account(account_email, account_password)
	values
		('shaggy@auctioncentral.org', 'zoinks'),
		('velma@auctioncentral.org', 'jinkies')

insert into NPO_Rep_Account(account_email, account_password)
	values
		('scooby@wwo.org', 'scoobysnacks'),
		('daphne@unicef.org', 'foundtrap'),
		('fred@redcross.org', 'splitup')

insert into Item_Auction_ID(item_name, auction, id)
	values
		('Faux Fur Coat', 'WWO', 0001),
		('Finger Painting', 'UNICEF', 0002),
		('Bandages', 'Red Cross', 0003)

insert into Bidder_Account(account_email, account_password)
	values
		('edgeworth@aol.com', 'steelsamurai'),
		('aceattorney@gmail.com', 'objection'),
		('mayafey@yahoo.com', 'mysticmaya')

--foreign key tables

insert into Auction_Contact(org, contact)
	values
		('WWO', 'scooby@wwo.org'),
		('UNICEF', 'daphne@unicef.org'),
		('Red Cross', 'fred@redcross.org')

insert into Auction_Date_Time(org, date_time)
	values
		('WWO', '01/01/2017 13:00:00'),
		('UNICEF', '02/02/2017 14:00:00'),
		('Red Cross', '03/03/2017 15:00:00')

insert into Auction_Intake(org, intake)
	values
		('WWO', 'shaggy@auctioncentral.org'),
		('UNICEF', 'velma@auctioncentral.org'),
		('Red Cross', 'velma@auctioncentral.org')

insert into Auction_Exp_Num_Items(org, exp_num_items)
	values
		('WWO', 50),
		('UNICEF', 100),
		('Red Cross', 200)

insert into Auction_Comments(org, comments)
	values
		('WWO', null),
		('UNICEF', null),
		('Red Cross', null)

insert into Employee_Name(employee, full_name)
	values
		('shaggy@auctioncentral.org', 'Shaggy Rogers'),
		('velma@auctioncentral.org', 'Velma Dinkly')

insert into NPO_Rep_Name(rep, full_name)
	values
		('scooby@wwo.org', 'Scooby Doo'),
		('daphne@unicef.org', 'Daphne Blake'),
		('fred@redcross.org', 'Fred Jones')

insert into NPO_Rep_Phone(rep, phone)
	values
		('scooby@wwo.org', '(666) 666-6666'),
		('daphne@unicef.org', '(777) 777-7777'),
		('fred@redcross.org', '(888) 888-8888')

insert into Item_Quantity(id, quantity)
	values
		(0001, 1),
		(0002, 2),
		(0003, 5)

insert into Item_Start_Bid(id, start_bid)
	values
		(0001, 50.00),
		(0002, 0.25),
		(0003, 10.00)

insert into Item_Donor(id, donor)
	values
		(0001, 'Kate McKinnon'),
		(0002, 'Bobby'),
		(0003, 'Dr.Who')

insert into Item_Sell_Price(id, sell_price)
	values
		(0001, 75.00),
		(0002, 6.00),
		(0003, 40.00)

insert into Item_Condition(id, condition)
	values
		(0001, 'New'),
		(0002, 'New'),
		(0003, '900 years old')

insert into Item_Comments(id, comments)
	values 
		(0001, null),
		(0002, null),
		(0003, null)
		
insert into Item_Photo(id, photo)
	values
		(0001, null),
		(0002, null),
		(0003, null)

insert into Bidder_Name(bidder, full_name)
	values
		('edgeworth@aol.com', 'Miles Edgeworth'),
		('aceattorney@gmail.com', 'Pheonix Wright'),
		('mayafey@yahoo.com', 'Maya Fey')

insert into Bidder_Phone(bidder, phone)
	values
		('edgeworth@aol.com', '(222) 222-2222'),
		('aceattorney@gmail.com', '(333) 333-3333'),
		('mayafey@yahoo.com', '(444) 444-4444')

insert into Bidder_Payment(bidder, credit_card)
	values
		('edgeworth@aol.com', '2222-2222-2222-2222'),
		('aceattorney@gmail.com', '3333-3333-3333-3333'),
		('mayafey@yahoo.com', '4444-4444-4444-4444')

insert into Bidder_Street_Address(bidder, street)
	values
		('edgeworth@aol.com', '1234 Blah Street'),
		('aceattorney@gmail.com', '5678 Foo Avenue'),
		('mayafey@yahoo.com', '9012 Bar Lane')

insert into Full_Address(street, city, us_state, zip)
	values
		('1234 Blah Street', 'Pittsburgh', 'Pennsylvania', 12345),
		('5678 Foo Avenue', 'Los Angeles', 'California', 90123),
		('9012 Bar Lane', 'Anchorage', 'Alaska', 25349)

insert into Bid(bidder, auction, item, bid)
	values
		('edgeworth@aol.com', 'WWO', 0001, 50.01),
		('aceattorney@gmail.com', 'UNICEF', 0002, 5.00),
		('mayafey@yahoo.com', 'Red Cross', 0003, 20.00)



