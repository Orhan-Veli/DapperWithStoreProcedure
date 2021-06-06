create proc DeleteBooks(
@BookId uniqueidentifier
)as
begin
delete from CategoryBookRelation where BookId = @BookId
delete from BookLibraryRelation where BookId = @BookId
delete from Books where Id = @BookId 
end