--can't change account email
create trigger emplyee_all_update_trig
	on Employee_All
	instead of update
	as
	begin
		declare @account_email varchar(50)
		declare @account_password varchar(50)
		declare @full_name varchar(50)
		select * into #ttable from inserted
		begin
			while(exists(select account_email from #ttable))
				begin
					select top 1 @account_email = account_email from #ttable
					select top 1 @account_password = account_password from #ttable
					select top 1 @full_name = full_name from #ttable
					update Employee_Account	
						set account_password = @account_password where account_email = @account_email
					update Employee_Name
						set full_name = @full_name where employee = @account_email
					delete from #ttable where account_email = @account_email
				end
		end
	end