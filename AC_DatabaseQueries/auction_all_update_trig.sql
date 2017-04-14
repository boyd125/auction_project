--can't change org
create trigger auction_all_update_trig
	on Auction_All
	instead of update
	as
	begin
		declare @org varchar(50)
		declare @contact varchar(50)
		declare @phone varchar(12)
		declare @date_time datetime
		declare @intake varchar(19)
		declare @exp_num_items int
		declare @comments varchar(500)
		select * into #ttable from inserted
		begin
			while(exists(select org from #ttable))
				begin
					select top 1 @org = org from #ttable
					select top 1 @contact = contact from #ttable
					select top 1 @phone = phone from #ttable
					select top 1 @date_time = date_time from #ttable
					select top 1 @intake = intake from #ttable
					select top 1 @exp_num_items = exp_num_items from #ttable
					select top 1 @comments = comments from #ttable
					update Auction_Contact
						set contact = @contact where org = @org
					update Auction_Contact_Phone
						set phone = @phone where contact = @contact
					update Auction_Date_Time
						set date_time = @date_time where org = @org
					update Auction_Intake
						set intake = @intake where org = @org
					update Auction_Exp_Num_Items
						set exp_num_items = @exp_num_items where org = @org
					update Auction_Comments
						set comments = @comments where org = @org
					delete from #ttable where org = @org
				end
			end
		end

--update Auction_All set intake = 'Jenkins' where org = 'WWO'