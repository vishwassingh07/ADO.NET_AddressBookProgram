--------- Delete Contact -------
Create Procedure spDeleteConact
@FirstName varchar(200)
As
Delete From AddressBookAdo Where FirstName = @FirstName;