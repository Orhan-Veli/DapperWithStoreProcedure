create proc updatecategory(
@CategoryId uniqueidentifier,
@Name nvarchar(50)
)as
begin
if(@CategoryId != null)
begin
update Category
set [Name] = @Name
where Id = @CategoryId
end
end