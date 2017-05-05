create trigger auction_all_insert_trig
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
			while(exists(select org from #ttable))
				begin
					select top 1 @org = org from #ttable
					select top 1 @contact = contact from #ttable
					select top 1 @date_time = date_time from #ttable
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

