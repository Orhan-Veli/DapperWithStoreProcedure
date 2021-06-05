Create Proc CreateBook
@Id uniqueidentifier,
@Name nvarchar(50),
@Category nvarchar(50),
@WriterId uniqueidentifier
as
begin
set @Id = newid();
insert into Writers values(@Id,@Name,@Category,@WriterId);
end