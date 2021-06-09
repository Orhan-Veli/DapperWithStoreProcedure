create proc UpdateManager(
@Id uniqueidentifier,
@Name nvarchar(50),
@LastName nvarchar(50),
@LibraryId uniqueidentifier
)as
begin
if(@Id != null)
begin
update Managers
set [Name] = @Name,
LastName = @LastName,
LibraryId = @LibraryId
where Id = @Id
end
end