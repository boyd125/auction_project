--can't change id
create trigger item_all_update_trig
	on Item_All
	instead of update
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
		select * into #ttable from inserted
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
					update Item_Auction_ID
						set item_name = @item_name, auction = @auction where id = @id
					update Item_Quantity
						set quantity = @quantity where id = @id
					update Item_Start_Bid
						set start_bid = @start_bid where id = @id
					update Item_Donor
						set donor = @donor where id = @id
					update Item_Sell_Price
						set sell_price = @sell_price where id = @id
					update Item_Condition
						set condition = @condition where id = @id
					update Item_Comments
						set comments = @comments where id = @id
					update Item_Photo
						set photo = @photo where id = @id
					delete from #ttable where id = @id
				end
		end
	end

--update Item_All set donor = 'McDuck' where quantity = 2