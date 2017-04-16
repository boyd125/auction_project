create view NPO_Rep_All
	as
		select account_email, account_password, org
			from NPO_Rep_Account, NPO_Rep_Org
				where account_email = rep