create trigger npo_rep_all_insert_trigger
	on NPO_Rep_All
	instead of insert
	as
	begin
		declare @account_email varchar(50)
		declare @account_password varchar(50)
		declare @org varchar(50)
		select * into #ttable from inserted
		begin
			while(exists(select account_email from #ttable))
				begin
					select top 1 @account_email = account_email from #ttable
					select top 1 @account_password = account_password from #ttable
					select top 1 @org = org from #ttable
					insert into NPO_Rep_Account values (@account_email, @account_password)
					insert into NPO_Rep_Org values (@account_email, @org)
					delete from #ttable where account_email = @account_email
				end
		end
	end