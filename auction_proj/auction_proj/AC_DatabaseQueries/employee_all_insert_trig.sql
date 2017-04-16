create trigger employee_all_insert_trigger
	on Employee_All
	instead of insert
	as
	begin
		declare @account_email varchar(50)
		declare @account_password varchar(50)
		declare @full_name varchar(50)
		select * into #ttable from inserted
		begin
			while(exists(select account_email from #ttable))
				begin
					select top 1 @account_email = account_email
					select top 1 @account_password = account_password
					select top 1 @full_name = full_name
					insert into Employee_Account values (@account_email, @account_password)
					insert into Employee_Name values (@account_email, @full_name)
					delete from #ttable where account_email = @account_email
				end
		end
	end