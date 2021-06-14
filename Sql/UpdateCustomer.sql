USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 14.06.2021 22:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateCustomer](
@Id uniqueidentifier,
@Name nvarchar(50),
@LastName nvarchar(50)
)as
begin 
update Customers
set [Name] = @Name,
LastName = @LastName
where Id = @Id
end