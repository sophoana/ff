/*
 This file contains SQL statements that will be executed before the database comparison, but not 
 by the VS publish; instead by an msbuild target or other step of the build server.
 
 This can be used for cases where refactoring requires changes to the target database prior
 to the publish step's comparison to source. 

 Each statement needs to be idempotent.
  https://www.simple-talk.com/sql/database-administration/using-migration-scripts-in-database-deployments/	

*/