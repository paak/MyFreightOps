Migration Runners

Command Line Runner
https://github.com/schambers/fluentmigrator/wiki/Command-Line-Runner-Options

Migrate.exe /conn "Data Source=db\db.sqlite;Version=3;" /provider sqlite /assembly your.migrations.dll /verbose

migrate --conn "server=.\SQLEXPRESS;uid=testfm;pwd=test;Trusted_Connection=yes;database=FluentMigrator" --provider sqlserver2008 --assembly "..\Migrations\bin\Debug\Migrations.dll" --task migrate --output --outputFilename migrated.sql

migrate -c "server=.\SQLEXPRESS;uid=testfm;pwd=test;Trusted_Connection=yes;database=FluentMigrator" -db sqlserver2008 -a "..\Migrations\bin\Debug\Migrations.dll" -t migrate -o -of migrated.sql

migrate -c "server=.\SQLEXPRESS;uid=sa;pwd=dbadmin;Trusted_Connection=yes;database=WINConnect20130423" -db sqlserver2008 -a "F:\Projects\WINConnectV2\Sources\Development\WINportal\WINConnect.DbMigration\bin\Debug\WINConnect.DbMigration.dll" -t migrate

// [Bank]
// The below line of code works for me in order to execute the code.
migrate -c "server=.\SQLEXPRESS;uid=sa;pwd=dbadmin;database=WINConnect20130423" -db sqlserver2008 -a "F:\Projects\WINConnectV2\Sources\Development\WINportal\WINConnect.DbMigration\bin\Debug\WINConnect.DbMigration.dll" -t migrate

// [Bank]
// The below line of code used to rollback execution of script.
migrate -c "server=.\SQLEXPRESS;uid=sa;pwd=dbadmin;database=WINConnect20130423" -db sqlserver2008 -a "F:\Projects\WINConnectV2\Sources\Development\WINportal\WINConnect.DbMigration\bin\Debug\WINConnect.DbMigration.dll" -t rollback

migrate -c "Data Source=(local);Initial Catalog=WINConnect20130423;User ID=sa;Password=dbadmin;Persist Security Info=True;MultipleActiveResultSets=True"
	-db sqlserver2012 -a "..\Migrations\bin\Debug\WINConnect.DbMigration.dll" -t migrate -o -of WINConnect.DbMigration.sql

//[Jobby]
migrate -c "Data Source=JOB-PC\SQL2012;uid=sa;pwd=dbadmin;database=sea.winwebconnect.com" -db sqlserver2008 -a "D:\WINConnectV2\Sources\RC310\WINConnectR3\WINConnect.DbMigration\bin\Debug\WINConnect.DbMigration.dll" -t migrate
migrate -c "Data Source=TEMP-PC\SQLEXPRESS;uid=sa;pwd=dbadmin;database=WINConnect3" -db sqlserver2008 -a "D:\WINConnectV2\Sources\Development\WINportal\WINConnect.DbMigration\bin\Debug\WINConnect.DbMigration.dll" -t rollback
// [Joe]
// This works for me ( full paths )
C:\Users\Joe\Documents\WIN\WINConnectV2\Sources\Main\WINportal\packages\FluentMigrator.1.1.0.0\tools\migrate -c "server=.\SQLEXPRESS;uid=sa;pwd=dbadmin;database=WINConnect2" -db sqlserver2012 -a "C:\Users\Joe\Documents\WIN\WINConnectV2\Sources\Development\WINportal\WINConnect.DbMigration\bin\Debug\WINConnect.DbMigration.dll" -t migrate

//D:\tfs_WINConnectV2\Sources\Development\WINportal\packages\FluentMigrator.1.1.1.0\tools
// Paak
migrate -c "server=(local);uid=sa;pwd=dbadmin;database=WINConnect" -db sqlserver2008 -a "D:\tfs_WINCOnnect\WINConnectV2\Sources\Development\WINportal\WINConnect.DbMigration\bin\Release\WINConnect.DbMigration.dll" -t migrate
// Paak
migrate -c "server=(local);uid=sa;pwd=dbadmin;database=WINConnect" -db sqlserver2008 -a "D:\tfs_WINCOnnect\WINConnectV2\Sources\Development\WINportal\WINConnect.DbMigration\bin\Release\WINConnect.DbMigration.dll" -t rollback
