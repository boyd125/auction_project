create trigger npo_rep_all_insert_trigger
	on NPO_Rep_All
	instead of insert
	as
	begin
		declare @account_email varchar(50)
		declare @account_password varchar(50)
		declare @full_name varchar(50)
		declare @phone varchar(12)
		select * into #ttable from inserted
		begin
			while(exists(select account_email from #ttable))
				begin
					select top 1 @account_email = account_email from #ttable
					select top 1 @account_password = account_password from #ttable
					select top 1 @full_name = full_name from #ttable
					select top 1 @phone = phone from #ttable
					insert into NPO_Rep_Account values (@account_email, @account_password)
					insert into NPO_Rep_Name values (@account_email, @full_name)
					insert into NPO_Rep_Phone values (@account_email, @phone)
					delete from #ttable where account_email = @account_email
				end
		end
	end