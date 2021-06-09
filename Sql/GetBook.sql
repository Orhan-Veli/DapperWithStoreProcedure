alter proc GetBook(
@BookId uniqueidentifier
)as
begin
select b.[Name] as bookname,w.[Name] as writername,w.LastName as writerlastname,c.[Name] as categoryname
from Books as b
inner join Writers as w on w.Id = b.WriterId
inner join CategoryBookRelation as cr on cr.BookId = b.Id
inner join Category as c on c.Id = cr.CategoryId
where b.Id = @BookId
end

