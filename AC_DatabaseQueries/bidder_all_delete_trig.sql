--triggers on delete
create trigger bidder_all_delete_trig
	on Bidder_All
	instead of delete
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
		select * into #ttable from deleted
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
					
					--foreign key tables
					delete from Bidder_Name
						where bidder = @account_email
					delete from Bidder_Phone
						where bidder = @account_email
					delete from Bidder_Payment
						where bidder = @account_email
					delete from Full_Address
						where street = @street
					delete from Bid
						where bidder = @account_email

					--base tables
					delete from Bidder_Street_Address
						where bidder = @account_email
					delete from Bidder_Account
						where account_email = @account_email
					delete from #ttable where account_email = @account_email
				end
			end
		end

--test delete
--delete from Bidder_All where account_email = 'aceattorney@gmail.com'