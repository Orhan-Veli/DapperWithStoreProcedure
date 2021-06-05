create proc CreateWriters(
@Name nvarchar(50),
@LastName nvarchar(50),
@AddressId uniqueidentifier
) as 
begin
declare @Id uniqueidentifier;
set @Id = NEWID();
insert into Writers values(@Id,@Name,@LastName,@AddressId);
end
