create view Auction_All
	as
		select Auction_Org.org org, Auction_Contact.contact contact, date_time, Auction_Intake.intake intake, 
		exp_num_items, comments
			from Auction_Org, Auction_Contact, Auction_Date_Time, Auction_Intake, Auction_Exp_Num_Items,
			Auction_Comments
				where Auction_Org.org = Auction_Contact.org and Auction_Org.org = Auction_Date_Time.org 
				and Auction_Org.org = Auction_Intake.org and Auction_Org.org = Auction_Exp_Num_Items.org
			    and Auction_Org.org = Auction_Comments.org