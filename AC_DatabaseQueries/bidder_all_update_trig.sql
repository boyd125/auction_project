--can't change email
create trigger bidder_all_update_trig
	on Bidder_All
	instead of update
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
					update Bidder_Account
						set account_password = @account_password where account_email = @account_email
					update Bidder_Name
						set full_name = @full_name where bidder = @account_email
					update Bidder_Phone
						set phone = @phone where bidder = @account_email
					update Bidder_Payment
						set credit_card = @credit_card where bidder = @account_email
					update Bidder_Street_Address
						set street = @street where bidder = @account_email
					update Full_Address
						set city = @city, us_state = @us_state, zip = @zip where street = @street
					delete from #ttable where account_email = @account_email
				end
			end
		end

--update Bidder_All set full_name = 'Phoenix Wrong' where account_email = 'aceattorney@gmail.com'