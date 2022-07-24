------- Inserting Contact In AddressBook ------
Create Procedure spAddressBook
(
 @FirstName nvarchar(200),
 @LastName nvarchar(200),
 @Address varchar,
 @City varchar,
 @State varchar,
 @Zip int,
 @PhoneNumber bigint,
 @Email varchar
 )
 As
 Insert into AddressBookAdo(FirstName,LastName,Address,City,State,Zip, Phone,Email)
 values(@FirstName, @LastName, @Address, @City, @State, @Zip, @PhoneNumber, @Email );

 Insert Into AddressBookAdo Values('Vivek','Singh','Andheri','Mumbai','Maharashtra',455445,98584933,'vivek@gmail.com')
 Insert Into AddressBookAdo Values('Siddhant','Singh','NewMarket','Bhopal','MP',432445,98523933,'siddhant@gmail.com')
 Insert Into AddressBookAdo Values('Shobhit','Singh','Vijaynagar','Indore','MP',422222,983958233,'shobhit@gmail.com')



