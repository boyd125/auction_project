create trigger bidder_all_insert_trig
	on Bidder_All
	instead of insert
	as
	begin
		declare @account_email varchar(50)
		declare @account_password varchar(50)
		declare @full_name varchar(50)
		declare @phone varchar(12)
		declare @credit_card varchar(19)
		declare @street varchar(50)
		declare @city varchar(50)
		declare @us_state varchar(50)
		declare @zip varchar(50)
		select * into #ttable from inserted
		begin
			while(exists(select account_email from #ttable))
				begin
					select top 1 @account_email = account_email from #ttable
					select top 1 @account_password = account_password from #ttable
					select top 1 @full_name = full_name from #ttable
					select top 1 @phone = phone from #ttable
					select top 1 @credit_card = credit_card from #ttable
					select top 1 @street = street from #ttable
					select top 1 @city = city from #ttable
					select top 1 @us_state = us_state from #ttable
					select top 1 @zip = zip from #ttable

					insert into Bidder_Account values(@account_email, @account_password)
					insert into Bidder_Name values (@account_email, @full_name)
					insert into Bidder_Phone values (@account_email, @phone)
					insert into Bidder_Payment values (@account_email, @credit_card)
					insert into Bidder_Street_Address values (@account_email, @street)
					insert into Full_Address values (@street, @city, @us_state, @zip)
					delete from #ttable where account_email = @account_email
				end
		end
	end

