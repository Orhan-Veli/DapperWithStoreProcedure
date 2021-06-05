Create Proc CreateWriter
@Id uniqueidentifier,
@Name nvarchar(50),
@LastName nvarchar(50),
@AddressId uniqueidentifier
as
begin
set @Id = newid();
insert into Writers values(@Id,@Name,@LastName,@AddressId);
end