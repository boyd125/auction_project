create view Bidder_All
	as
		select Bidder_Account.account_email account_email, Bidder_Account.account_password account_password, full_name, phone,
		credit_card, Bidder_Street_Address.street street, city, us_state, zip
			from Bidder_Account, Bidder_Name, Bidder_Phone, Bidder_Payment, Bidder_Street_Address, Full_Address
				where Bidder_Account.account_email = Bidder_Name.bidder and Bidder_Account.account_email = Bidder_Phone.bidder
				and Bidder_Account.account_email = Bidder_Payment.bidder and Bidder_Account.account_email = Bidder_Street_Address.bidder
				and Bidder_Street_Address.street = Full_Address.street
				
					