create proc DeleteWriter(
@WriterId uniqueidentifier
)as
begin 
delete from Books where WriterId = @WriterId
delete from Writers where Id = @WriterId
end