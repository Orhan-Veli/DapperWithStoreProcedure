create proc DeleteManager(
@ManagerId uniqueidentifier
)as
begin
delete from Managers where Id = @ManagerId 
end