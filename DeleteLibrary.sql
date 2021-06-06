create proc DeleteLibrary(
@LibraryId uniqueidentifier
)as
begin
delete from CustomerLibraryRelation where LibraryId = @LibraryId
delete from BookLibraryRelation where LibraryId = @LibraryId
delete from Libraries where Id = @LibraryId
end