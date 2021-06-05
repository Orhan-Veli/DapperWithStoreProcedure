create proc CreateLibraries(
@Name nvarchar(50),
@AddressId uniqueidentifier
)as
begin
declare @Id uniqueidentifier
set @Id = NEWID();
insert into Libraries values(@Id,@Name,@AddressId);
end
