--do not insert id
create trigger item_all_insert_trig
	on Item_All
	instead of insert
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
			while(exists(select item_name from #ttable))
				begin
					select top 1 @item_name = item_name from #ttable
					select top 1 @auction = auction from #ttable
					select top 1 @quantity = quantity from #ttable
					select top 1 @start_bid = start_bid from #ttable
					select top 1 @donor = donor from #ttable
					select top 1 @sell_price = sell_price from #ttable
					select top 1 @condition = condition from #ttable
					select top 1 @comments = comments from #ttable
					select top 1 @photo = photo from #ttable

					--generate random id
					select @id = cast(rand()*(10000 - 1) + 1 as int)
					while(exists(select id from Item_All where id = @id))
						select @id = cast(rand()*(10000 - 1) + 1 as int)

					insert into Item_Auction_ID values (@item_name, @auction, @id)
					insert into Item_Quantity values (@id, @quantity)
					insert into Item_Start_Bid values (@id, @start_bid)
					insert into Item_Donor values (@id, @donor)
					insert into Item_Sell_Price values (@id, @sell_price)
					insert into Item_Condition values (@id, @condition)
					insert into Item_Comments values (@id, @comments)
					insert into Item_Photo values (@id, @photo)
					delete from #ttable where item_name = @item_name
				end
		end
	end
