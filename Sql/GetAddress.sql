create proc GetAddress(
@CountryId uniqueidentifier
)as
begin
	if(@CountryId = null)
		begin
		  select [Name] from Country
		end
	else
		begin
		select [Name] from Country where Id = @CountryId		
		end
end