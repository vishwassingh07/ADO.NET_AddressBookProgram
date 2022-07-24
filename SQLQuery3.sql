-------- Updating cotact details -------

Create Procedure spUpdateContactDetails
@FirstName varchar(200),
@City varchar(200),
@State varchar(100)
AS
Update AddressBookAdo Set City = @City,State = @State Where FirstName = @FirstName;