/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if ('$(MergeReadOnlyLookupTables)' = 'Y')
begin
	RaisError ('Merging lookup tables', 0, 0) with log
	--Put all read-only lookup tables here
	:r .\dbo.UserLevels.Table.sql
end

if ('$(LoadSeedData)' = 'Y')
begin
	RaisError ('Loading seed data', 0, 0) with log
	:r .\dbo.Fruits.Table.sql
	:r .\dbo.FruitVarieties.Table.sql
	:r .\dbo.Locations.Table.sql
	:r .\dbo.Users.Table.sql
	:r .\dbo.Reviews.Table.sql
	:r .\dbo.Votes.Table.sql
end