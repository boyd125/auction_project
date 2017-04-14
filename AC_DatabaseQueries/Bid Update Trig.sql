create trigger bid_update_trig
	on Bid 
	instead of insert 
	as
	begin
		declare @bidder varchar(50)
		declare @auction varchar(50)
		declare @item varchar(50)
		select * into #ttable from inserted
		begin
			while(exists(select bidder from #ttable))
				begin
					select top 1 @bidder = bidder from #ttable
					select top 1 @auction = auction from #ttable
					select top 1 @item = item from #ttable
					insert into Bidder_Account values(@bidder)
					insert into Auction_Org values(@auction)
					insert into Item_Auction values(@item)
					delete from #ttable where bidder = @bidder

				end
		end
	end