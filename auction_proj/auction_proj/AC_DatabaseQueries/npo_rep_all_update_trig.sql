--can't change account email
create trigger npo_rep_all_update_trigger
	on NPO_Rep_All
	instead of update
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
					update NPO_Rep_Account
						set account_password = @account_password where account_email = @account_email
					update NPO_Rep_Org
						set org = @org where account_email = @account_email
					delete from #ttable where account_email = @account_email
				end
		end
	end