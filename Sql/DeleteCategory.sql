create proc DeleteCategory(
@CategoryId uniqueidentifier
)as
begin
delete from CategoryBookRelation where CategoryId = @CategoryId 
delete from Category where Id = @CategoryId
end