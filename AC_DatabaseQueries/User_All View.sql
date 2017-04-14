create view User_All
	as 
		select account_email, account_password, account_type = 'bidder'
			from Bidder_All
		union
		select account_email, account_password, account_type = 'employee'
			from Employee_All
		union
		select account_email, account_password, account_type = 'npo_rep'
			from NPO_Rep_All