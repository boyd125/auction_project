drop table Bid
drop table Item
drop table Auction
drop table Bidder

--get all auctions
select org from Auction

--get all items from an auction
select item_name from Item
	where auction = 'someauction'

--update bidder email
update Bidder
	set account_email = 'example.com'
		where account_email = 'otherexample.com'

--update bidder phone
update Bidder
	set phone = '8888888888'
		where account_email = 'otherexample.com'
