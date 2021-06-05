Create proc CreateManager
@Id uniqueidentifier,
@Name nvarchar(50),
@LastName nvarchar(50),
@LibraryId uniqueidentifier,
@AddressId uniqueidentifier
as
begin
set @Id = NEWID();
insert into Managers values(@Id,@Name,@LastName,@LibraryId,@AddressId);
end
