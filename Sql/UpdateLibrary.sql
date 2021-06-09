create proc UpdateLibrary(
@Id uniqueidentifier,
@Name nvarchar(50)
)as
begin
if(@Id != null)
begin
update Libraries
set [Name] = @Name
where Id = @Id
end
end