create trigger bid_insert_trig
	on Bid 
	instead of insert
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

					if (exists(select bidder, auction, item from Bid where bidder = @bidder and auction = @auction 
						and auction = @auction))
						begin
							update Bid
								set bid = @bid where bidder = @bidder and auction = @auction and item = @item
							delete from #ttable where bidder = @bidder
							break
						end

					insert into Bid
						values (@bidder, @auction, @item, @bid)
					delete from #ttable where bidder = @bidder
				end
		end
	end