insert into Bidder_All values ('new@account.com', 'password', 'New Name', '123-124-1423',
	'2345-2534-5324-5243', '2354 St.', 'Town', 'Oblivion', '99999')

insert into Employee_All values ('amy@auctioncentral.com', 'awesomeamy', 'Amy Adams')

insert into NPO_Rep_All values ('carl@toysfortots.org', 'tottoys', 'Carl Evans', '354-435-6754')

insert into Auction_All values ('Toys For Tots', 'carl@toysfortots.org', '05/06/2017 13:00:00', 'amy@auctioncentral.com', 
		20, 'Gonna be a lot of toys')

--insert into Auction_All values ('Toys For Teens', 'carl@toysfortots.org', '05/06/2017 16:00:00', 'amy@auctioncentral.com', 
--		20, 'Gonna be a lot of toys')

--insert into Auction_All values ('Toys For Toddlers', 'carl@toysfortots.org', '05/06/2017 06:00:00', 'amy@auctioncentral.com', 
--		20, 'Gonna be a lot of toys')

insert into Item_All (item_name, auction, quantity, start_bid, donor, sell_price, condition, comments, photo)
	values
		('Transformer', 'Toys For Tots', 1, 20.00, 'Optimus Prime', 15.00, 'New', 'It''s cool', null),
		('Yo-Yo', 'Toys For Tots', 1, 13.00, 'Cool Kid', null, 'Okay', null, null),
		('Snake Skin Boots', 'WWO', 2, 30.00, 'Hunter Guy', null, 'Good', null, null),
		('Med Kit', 'Red Cross', 1, 3.00, 'Nurse', null, 'Fine', null, null),
		('Piggy Bank', 'UNICEF', 1, 2.50, 'Generous Guy', null, 'Brand new', null, null)

--delete from Auction_All
--	where org = 'Toys For Tots'

--insert into Auction_All values ('Toys For Tots', 'carl@toysfortots.org', '10/06/2017 13:00:00', 'amy@auctioncentral.com', 
--		20, 'Gonna be a lot of toys')