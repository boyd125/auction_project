insert into Bidder_All values ('new@account.com', 'password', 'New Name', '123-124-1423',
	'2345-2534-5324-5243', '2354 St.', 'Town', 'Oblivion', '99999')

insert into Employee_All values ('amy@auctioncentral.com', 'awesomeamy', 'Amy Adams')

insert into NPO_Rep_All values ('carl@toysfortots.org', 'tottoys', 'Carl Evans', '354-435-6754')

insert into Auction_All values ('Toys For Tots', 'carl@toysfortots.org', '05/05/2017 13:00:00', 'amy@auctioncentral.com', 
		20, 'Gonna be a lot of toys')

insert into Item_All (item_name, auction, quantity, start_bid, donor, sell_price, condition, comments, photo)
	values
		('Transformer', 'Toys For Tots', 1, 20.00, 'Optimus Prime', 15.00, 'New', 'It''s cool', null)