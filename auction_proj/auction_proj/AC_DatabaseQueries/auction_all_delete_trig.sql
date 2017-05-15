--also delete rep info

alter trigger auction_all_delete_trig
	on Auction_All
	instead of delete
	as
	begin
		declare @org varchar(50)
		declare @contact varchar(50)
		declare @date_time datetime
		declare @intake varchar(19)
		declare @exp_num_items int
		declare @comments varchar(500)

		declare @rep varchar(50)

		select * into #ttable from deleted
		begin
			while(exists(select org from #ttable))
				begin
					select top 1 @org = org from #ttable
					select top 1 @contact = contact from #ttable
					select top 1 @date_time = date_time from #ttable
					select top 1 @intake = intake from #ttable
					select top 1 @exp_num_items = exp_num_items from #ttable
					select top 1 @comments = comments from #ttable  
					
					--save to last auction table
					update Auction_Last_Date_Time
						set date_time = @date_time where org = @org
					
					delete from Auction_Date_Time
						where org = @org
					delete from Auction_Intake
						where org = @org
					delete from Auction_Exp_Num_Items
						where org = @org
					delete from Auction_Comments
						where org = @org

					--org referenced in Bid
					delete from Bid
						where auction = @org

					--base tables
					delete from Auction_Contact
						where org = @org
					delete from Auction_Org
						where org = @org
					delete from #ttable where org = @org
				end
			end
		end

--delete from Auction_All where org = 'WWO'