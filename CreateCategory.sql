create proc CreateCategory(
@Name nvarchar(50)
)
as
begin
declare @Id uniqueidentifier
set @Id = NEWID()
insert into obs.Category values(@Id,@Name)
end