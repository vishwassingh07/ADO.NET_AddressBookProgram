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