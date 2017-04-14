create view Item_All
	as
		select Item_Auction_ID.item_name item_name, Item_Auction_ID.auction auction, Item_Auction_ID.id id, 
		quantity, start_bid, donor, sell_price, condition, comments, photo
			from Item_Auction_ID, Item_Quantity, Item_Start_Bid, Item_Donor, Item_Sell_Price, Item_condition, 
			Item_Comments, Item_Photo
				where Item_Auction_ID.id = Item_Quantity.id and Item_Auction_ID.id = Item_Start_Bid.id
				and Item_Auction_ID.id = Item_Donor.id and Item_Auction_ID.id = Item_Sell_Price.id	
				and Item_Auction_ID.id = Item_Condition.id and Item_Auction_ID.id = Item_Comments.id
				and Item_Auction_ID.id = Item_Photo.id