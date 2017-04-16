create view Employee_All
	as
		select account_email, account_password, full_name
			from Employee_Account, Employee_Name
				where account_email = employee
