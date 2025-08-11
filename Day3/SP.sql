create or alter procedure proc_firstProcedure
as
begin
	print 'Hello World'
end

proc_firstProcedure

create or alter procedure proc_Greet(@p_name varchar(20))
as
begin
	print concat('Hello ',@p_name)
end

proc_Greet 'Ramu'

create or alter proc proc_GetTitlesByPublisher(@p_pubname varchar(50))
as
begin
	select pub_name 'Publisher Name', title 'Book Name' from
	publishers p join titles t on p.pub_id = t.pub_id
	where pub_name = @p_pubname;

end
proc_GetTitlesByPublisher 'Binnet & Hardley'


select * from publishers

create table Users
(username varchar(50) primary key,
password varbinary(max) not null,
role varchar(20))


Create master key Encryption by password = 'ThisIsMyStrogKey@2025';

create symmetric key UserPassKey
with algorithm = AES_256
encryption by password = 'ThisIsMyStrogKey@2025';


create or alter proc proc_InsertUserEncryptPassword(
@p_username varchar(50),
@p_password varchar(20),
@p_role varchar(20))
as
begin
	open symmetric key UserPassKey
	Decryption by password = 'ThisIsMyStrogKey@2025';

	insert into users values(@p_username,ENCRYPTBYKEY(KEY_GUID('UserPassKey'),@p_password),@p_role)

	close symmetric key UserPassKey
end


proc_InsertUserEncryptPassword 'ramu','ramu_123','admin'

select * from users

create or alter proc proc_GetUsersWithDecryptedPassword
as
begin
	open symmetric key UserPassKey
	Decryption by password = 'ThisIsMyStrogKey@2025';

	select username,convert(varchar(max),DECRYPTBYKEY(password)) 'Decrypted PAssword',role
	from users;
	close symmetric key UserPassKey
end

proc_GetUsersWithDecryptedPassword

--creating our own datatype
create type UserTableType as Table
(username varchar(50),
password varchar(20),
role varchar(20))

drop proc proc_InsertUserEncryptPassword
--using the type in sp for insert
create or alter proc proc_InsertUserBulkEncryptPassword(@userList UserTableType readonly)
as
begin
	open symmetric key UserPassKey
	Decryption by password = 'ThisIsMyStrogKey@2025';

	insert into users 
	select username,
	ENCRYPTBYKEY(KEY_GUID('UserPassKey'),password),
	role from @userList;

	close symmetric key UserPassKey
end


--creatinga  varuiable for our type and populating it, then using as parameter in sp
declare @bulkUSers UserTableType
Begin
insert into @bulkUSers values
('bimu','bimu_123','user'),
('somu','somu_123','admin'),
('komu','komu_123','user')

exec proc_InsertUserBulkEncryptPassword @userList =@bulkUSers
end

create proc proc_ExampleOut(@p_name varchar(10),@p_greet varchar(20) out)
as
begin
     set @p_greet = (select concat('hello ',@p_name))
end

declare 
@message varchar(10)
begin
   exec proc_ExampleOut 'Ramu', @message out
   print @message
end

create table User_Staging
(username varchar(50),
password varchar(20),
role varchar(20))


drop proc BulkInsertFromCsv

Create proc BulkInsertFromCsv(@filePath nvarchar(500))
as
begin
	truncate table User_Staging;
	declare 
	 @sqlStatement nvarchar(max) = '
	Bulk insert User_Staging
	from ''' + @filePath + ''' 
	with
	(FIELDTERMINATOR ='','',
	ROWTERMINATOR = ''\n'',
	FIRSTROW =2);';

	exec sp_executesql @sqlStatement;
	open symmetric key UserPassKey
	Decryption by password = 'ThisIsMyStrogKey@2025';

	insert into users 
	select username,
	ENCRYPTBYKEY(KEY_GUID('UserPassKey'),password),
	role from User_Staging;

	close symmetric key UserPassKey
	truncate table User_Staging;
end

BulkInsertFromCsv 'C:\Corp\Gynosys\Hexaware_17Jul2025\Participants\Day3\users.csv'
