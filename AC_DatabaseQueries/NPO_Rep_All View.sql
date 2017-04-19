create view NPO_Rep_All
	as
		select NPO_Rep_Account.account_email, NPO_Rep_Account.account_password, full_name, phone
			from NPO_Rep_Account, NPO_Rep_Name, NPO_Rep_Phone
				where NPO_Rep_Account.account_email = NPO_Rep_Name.rep
				and NPO_Rep_Account.account_email = NPO_Rep_Phone.rep