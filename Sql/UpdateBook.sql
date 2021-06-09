create proc UpdateBook(
@BookId uniqueidentifier,
@BookName nvarchar(50),
@WriterId uniqueidentifier
)as
begin
if(@BookId != null)
begin
Update Books
set [Name] = @BookName
where Id = @BookId
end
if(@WriterId != null)
begin
Update Books
set WriterId = @WriterId
where Id = @BookId
end
end
