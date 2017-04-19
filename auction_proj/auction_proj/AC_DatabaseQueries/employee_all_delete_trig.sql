create trigger employee_all_delete_trig
	on Employee_All
	instead of delete
	as
	begin
		declare @account_email varchar(50)
		declare @account_password varchar(50)
		declare @full_name varchar(50)
		select * into #ttable from deleted
		begin
			while(exists(select account_email from #ttable))
				begin
					select top 1 @account_email = account_email from #ttable
					select top 1 @account_password = account_password from #ttable
					select top 1 @full_name = full_name from #ttable
					delete from Employee_Name
						where employee = @account_email
					delete from Employee_Account
						where account_email = @account_email
					delete from #ttable where account_email = @account_email
				end
		end
	end