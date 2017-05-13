alter trigger auction_all_insert_trig
	on Auction_All
	instead of insert
	as
	begin
		declare @org varchar(50)
		declare @contact varchar(50)
		declare @date_time datetime
		declare @intake varchar(50)
		declare @exp_num_items int
		declare @comments varchar(500)
		select * into #ttable from inserted
		begin
			if ((select count(org) from Auction_Org)) = 25
				raiserror('Transaction failed: max number of auctions is 25', 0, 1) with nowait
				
			else
				while(exists(select org from #ttable))
					begin
						select top 1 @org = org from #ttable
						select top 1 @contact = contact from #ttable

						if (exists(select org from Auction_Contact where contact = @contact))
							begin
								raiserror('Transaction failed: Contact already exists with other org.', 0, 1) with nowait
								delete from #ttable where org = @org
								break
							end

						select top 1 @date_time = date_time from #ttable

						if ((select count(date_time) from Auction_Date_Time where datediff(day, date_time, @date_time) between -6 and 0) >= 5
							or (select count(date_time) from Auction_Date_Time where datediff(day, date_time, @date_time) between -5 and 1) >= 5
							or (select count(date_time) from Auction_Date_Time where datediff(day, date_time, @date_time) between -4 and 2) >= 5
							or (select count(date_time) from Auction_Date_Time where datediff(day, date_time, @date_time) between -3 and 3) >= 5
							or (select count(date_time) from Auction_Date_Time where datediff(day, date_time, @date_time) between -2 and 4) >= 5
							or (select count(date_time) from Auction_Date_Time where datediff(day, date_time, @date_time) between -1 and 5) >= 5
							or (select count(date_time) from Auction_Date_Time where datediff(day, date_time, @date_time) between 0 and 6) >= 5)
							begin
								raiserror('Transaction failed: max number of auctions per seven day period is 5', 0, 1) with nowait
								delete from #ttable where org = @org
								break
							end

						if ((select count(date_time) from Auction_Date_Time where cast(date_time as date) = cast(@date_Time as date)) = 2)
							begin
								raiserror('Transaction failed: max number of auctions per day is 2', 0, 1) with nowait
								delete from #ttable where org = @org
								break
							end

						if((select count(date_time) from Auction_Date_Time where abs(datediff(hour, date_time, @date_time)) <= 2) > 0)
							begin
								raiserror('Transaction failed: no auctions can be within 2 hours of each other', 0, 1) with nowait
								delete from #ttable where org = @org
								break
							end

						else
							select top 1 @intake = intake from #ttable
							select top 1 @exp_num_items = exp_num_items from #ttable
							select top 1 @comments = comments from #ttable
							insert into Auction_Org values(@org)
							insert into Auction_Contact values (@org, @contact)
							insert into Auction_Date_Time values (@org, @date_time)
							insert into Auction_Intake values (@org, @intake)
							insert into Auction_Exp_Num_Items values (@org, @exp_num_items)
							insert into Auction_Comments values (@org, @comments)
							delete from #ttable where org = @org
					end
		end
	end

