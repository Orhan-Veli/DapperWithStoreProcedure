create proc UpdateAddress(
@CountryId uniqueidentifier,
@CountryName nvarchar(50),
@StateId uniqueidentifier,
@StateName nvarchar(50),
@CountyId uniqueidentifier,
@CountyName nvarchar(50),
@DistrictId uniqueidentifier,
@DistrictName nvarchar(50)
)as
begin 
if(@CountryId != null)
begin
Update Country
set [Name] = @CountyName
where Id = @CountryId
end
if(@StateId != null)
begin
Update State
set [Name] = @StateName
where Id = @StateId
end
if(@CountyId != null )
begin
Update County
set [Name] = @CountyName
where Id = @CountyId
end
if(@DistrictId != null)
begin
Update District
set [Name] = @DistrictName
where Id = @DistrictId
end
end