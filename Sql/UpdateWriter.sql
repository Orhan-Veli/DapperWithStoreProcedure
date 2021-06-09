create proc UpdateWriter(
@Id uniqueidentifier,
@Name nvarchar(50),
@LastName nvarchar(50)
)as
begin
if(@Id != null)
begin
Update Writers
set [Name] = @Name,
LastName = @LastName
where Id = @Id
end
end