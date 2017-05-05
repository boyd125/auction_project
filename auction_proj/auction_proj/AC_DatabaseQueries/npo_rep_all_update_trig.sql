--can't change account email
create trigger npo_rep_all_update_trigger
	on NPO_Rep_All
	instead of update
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
					update NPO_Rep_Account
						set account_password = @account_password where account_email = @account_email
					update NPO_Rep_Name
						set full_name = @full_name where rep = @account_email
					update NPO_Rep_Phone 
						set phone = @phone where rep = @account_email
					delete from #ttable where account_email = @account_email
				end
		end
	end