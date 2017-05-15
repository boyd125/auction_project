--drop views
if(object_id('Bidder_All')) is not null
	drop view Bidder_All
if(object_id('Auction_All')) is not null
	drop view Auction_All
if(object_id('Item_All')) is not null
	drop view Item_All
if(object_id('Employee_All')) is not null
	drop view Employee_All
if(object_id('NPO_Rep_All')) is not null
	drop view NPO_Rep_All
if(object_id('User_All')) is not null
	drop view User_All

--drop tables with foreign keys
drop table Auction_Contact
drop table Auction_Date_Time
drop table Auction_Last_Date_Time
drop table Auction_Intake
drop table Auction_Exp_Num_Items
drop table Auction_Comments

drop table Employee_Name

drop table NPO_Rep_Name
drop table NPO_Rep_Phone

drop table Item_Quantity
drop table Item_Start_Bid
drop table Item_Donor
drop table Item_Sell_Price
drop table Item_Condition
drop table Item_Comments
drop table Item_Photo

drop table Full_Address

drop table Bidder_Name
drop table Bidder_Phone
drop table Bidder_Payment
drop table Bidder_Street_Address

drop table Bid

--drop base tables
drop table Auction_Org
drop table Employee_Account
drop table NPO_Rep_Account
drop table Item_Auction_ID
drop table Bidder_Account


