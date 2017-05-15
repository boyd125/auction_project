create trigger item_all_update_trig
	on Item_All
	instead of delete
	as
	begin
		declare @item_name varchar(50)
		declare @auction varchar(50)
		declare @id int
		declare @quantity int
		declare @start_bid int
		declare @donor varchar(50)
		declare @sell_price decimal(2)
		declare @condition varchar(50)
		declare @comments varchar(500)
		declare @photo varchar(500)
		select * into #ttable from deleted
		begin
			while(exists(select id from #ttable))
				begin
					select top 1 @item_name = item_name from #ttable
					select top 1 @auction = auction from #ttable
					select top 1 @id = id from #ttable
					select top 1 @quantity = quantity from #ttable
					select top 1 @start_bid = start_bid from #ttable
					select top 1 @donor = donor from #ttable
					select top 1 @sell_price = sell_price from #ttable
					select top 1 @condition = condition from #ttable
					select top 1 @comments = comments from #ttable
					select top 1 @photo = photo from #ttable
					delete from Item_Quantity
						where id = @id
					delete from Item_Start_Bid
						where id = @id
					delete from Item_Donor
						where id = @id
					delete from Item_Sell_Price
						where id = @id
					delete from Item_Condition
						where id = @id
					delete from Item_Comments
						where id = @id
					delete from Item_Photo
						where id = @id

					--bid dependency
					delete from Bid
						where item = @id

					--base tables
					delete from Item_Auction_ID
						where id = @id

					delete from #ttable where id = @id
				end
		end
	end

