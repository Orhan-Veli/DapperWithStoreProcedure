USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[GetBook]    Script Date: 12.06.2021 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GetBook](
@Id uniqueidentifier 
)as
begin
if(@Id != null)
begin
select b.[Name] as bookname,w.[Name] as writername,w.LastName as writerlastname,c.[Name] as categoryname
from Books as b
inner join Writers as w on w.Id = b.WriterId
inner join CategoryBookRelation as cr on cr.BookId = b.Id
inner join Category as c on c.Id = cr.CategoryId
where b.Id = @Id
end
else
begin 
select b.[Name] as bookname,w.[Name] as writername,w.LastName as writerlastname,c.[Name] as categoryname
from Books as b
inner join Writers as w on w.Id = b.WriterId
inner join CategoryBookRelation as cr on cr.BookId = b.Id
inner join Category as c on c.Id = cr.CategoryId
end
end

