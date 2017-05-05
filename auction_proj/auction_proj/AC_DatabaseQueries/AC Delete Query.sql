----drop views
--if(object_id('Bidder_All')) is not null
--	delete Bidder_All
--if(object_id('Auction_All')) is not null
--	delete Auction_All
--if(object_id('Item_All')) is not null
--	delete Item_All
--if(object_id('Employee_All')) is not null
--	delete Employee_All
--if(object_id('NPO_Rep_All')) is not null
--	delete NPO_Rep_All
--if(object_id('User_All')) is not null
--	delete User_All

--drop tables with foreign keys
delete Auction_Contact
delete Auction_Date_Time
delete Auction_Intake
delete Auction_Exp_Num_Items
delete Auction_Comments

delete Employee_Name

delete NPO_Rep_Name
delete NPO_Rep_Phone

delete Item_Quantity
delete Item_Start_Bid
delete Item_Donor
delete Item_Sell_Price
delete Item_Condition
delete Item_Comments
delete Item_Photo

delete Full_Address

delete Bidder_Name
delete Bidder_Phone
delete Bidder_Payment
delete Bidder_Street_Address

delete Bid

--drop base tables
delete Auction_Org
delete Employee_Account
delete NPO_Rep_Account
delete Item_Auction_ID
delete Bidder_Account


