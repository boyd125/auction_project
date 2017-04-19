create trigger bid_update_trig
	on Bid 
	instead of update
	as
	begin
		declare @bidder varchar(50)
		declare @auction varchar(50)
		declare @item varchar(50)
		declare @bid decimal(10, 2)
		select * into #ttable from inserted
		begin
			while(exists(select bidder from #ttable))
				begin
					select top 1 @bidder = bidder from #ttable
					select top 1 @auction = auction from #ttable
					select top 1 @item = item from #ttable
					select top 1 @bid = bid from #ttable
					delete from Bid
						where bidder = @bidder and auction = @auction and item = @item
					insert into Bid values (bidder, auction, item, bid)
					delete from #ttable where bidder = @bidder

				end
		end
	end