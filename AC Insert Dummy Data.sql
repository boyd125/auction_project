set nocount on

insert into Auction(org, contact, contact_num, date_time, intake, exp_num_item, comments)
	values
		('WWO', 'Charlie Chaplin', '5555555555', '01/01/2017 13:00:00', 'Sally', 50, null), 
		('UNICEF', 'John Johnson', '6666666666', '02/02/2017 14:00:00', 'Sam', 100, null), 
		('Red Cross', 'Paul Paulson', '7777777777', '03/03/2017 15:00:00', 'Sarah', 200, null)

insert into Item(item_name, auction, quantity, start_bid, donor, sell_price, condition, comments, photo)
	values 
		('Faux Fur Coat', 'WWO', 1, 50.00, 'Kate McKinnon', 75.00, 'New', null, null),
		('Finger Painting', 'UNICEF', 2, 0.25, 'Bobby', 6.00, 'New', null, null),
		('Bandages', 'Red Cross', 5, 10.00, 'Dr.Who', 40.00, '900 years old', null, null)

insert into Bidder(bidder_email, bidder_password, first_name, last_name, phone, bidder_address, bidder_card)
	values
		('edgeworth@aol.com', 'steelsamurai', 'Miles', 'Edgeworth', '2222222222', '1234 Blah Street', '2222-2222-2222-2222'),
		('aceattorney@gmail.com', 'objection', 'Phoenix', 'Wright', '3333333333', '5678 Foo Avenue', '3333-3333-3333-3333'),
		('mayafey@yahoo.com', 'mysticmaya', 'Maya', 'Fey', '4444444444', '9012 Bar Lane', '4444-4444-4444-4444')

insert into Bid(bidder, auction, item, bid)
	values
		('edgeworth@aol.com', 'WWO', 'Faux Fur Coat', 50.01),
		('aceattorney@gmail.com', 'UNICEF', 'Finger Painting', 5.00),
		('mayafey@yahoo.com', 'Red Cross', 'Bandages', 20.00)

select * from Auction
select * from Item
select * from Bidder
select * from Bid