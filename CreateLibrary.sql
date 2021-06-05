create proc CreateLibrary
@Id uniqueidentifier,
@Name nvarchar(50),
@Address uniqueidentifier
as
begin
set @Id = NEWID();
insert into Libraries values(@Id,@Name,@Address);
end