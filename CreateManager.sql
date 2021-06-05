create proc CreateManagers(
@Name nvarchar(50),
@LastName nvarchar(50),
@LibraryId uniqueidentifier,
@AddressId uniqueidentifier
)as
begin
Declare @Id uniqueidentifier
set @Id = NEWID()
insert into Managers values(@Id,@Name,@LastName,@LibraryId,@AddressId)
end