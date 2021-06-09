create proc DeleteAddress(
@CountryId uniqueidentifier,
@StateId uniqueidentifier,
@CountyId uniqueidentifier,
@DistrictId uniqueidentifier
)
as
begin 
	if(@CountryId != null)
		begin		
			delete from District where CountyId = @CountyId
			delete from County where StateId = @StateId
			delete from dbo.State where CountryId = @CountryId
			delete from Country where Id = @CountryId
		end
	else if(@StateId != null)
		begin
			delete from District where CountyId = @CountyId
			delete from County where StateId = @StateId
			delete from dbo.State where Id = @StateId 
		end
	else if(@CountyId != null)
		begin
			delete from District where CountyId = @CountyId
			delete from County where Id = @CountyId  
		end
	else if(@DistrictId != null)
		begin
			delete from District where Id = @DistrictId
		end
end
