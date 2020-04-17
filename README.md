# Crud Operation Anglur9 and WebAPI
Crud Operation Angular 9 and Web API with download excel file


Configure application and change connection string  before run or as you using port to open app:

Frontend :
	1- need to change port to can access web Api
File on this path : src\app\prod.service.ts
uri2 = 'http://localhost:20862/';

2-  need to change port to can access downloads based on your pc port used
File on this path :   src\app\prod.downloadService.ts
 this.baseApiUrl = 'http://localhost:20862/';

              -----------------------------------------------------------------------------------------------------

Back End :
	1- inventorydemo\api\app_start\webapiconfig.cs
            //CORS config  
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", "*", "*"));

	2- InventoryDemo\API\Web.config
	Change connection string :
<connectionStrings>
    <add name="InventoryDBContext" connectionString="Data Source=HOMESERVER2012;Initial Catalog=InventoryDB;Integrated Security=True;MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />
  </connectionStrings>



To Run Application :
-------------------------------
Front End :
To run application :
ng serve --open --port=4200

Back End :
Project API > set as start up project .
To access swagger :
http://localhost:20862/swagger

DB using Sql server :
----------------------------
Can run script to crate DB :

Install node modules before run :
----------------------------------------------
npm install
npm install rxjs


add node module to angular v9

What I use :
--------------------

What version I using >>
C:\Users\Administrator\invAPP>ng --version

Angular CLI: 9.1.1
Node: 13.13.0
OS: win32 x64

Angular: 9.1.1
... animations, cli, common, compiler, compiler-cli, core, forms
... language-service, platform-browser, platform-browser-dynamic
... router
Ivy Workspace: Yes

Package                           Version
-----------------------------------------------------------
@angular-devkit/architect         0.901.1
@angular-devkit/build-angular     0.901.1
@angular-devkit/build-optimizer   0.901.1
@angular-devkit/build-webpack     0.901.1
@angular-devkit/core              9.1.1
@angular-devkit/schematics        9.1.1
@ngtools/webpack                  9.1.1
@schematics/angular               9.1.1
@schematics/update                0.901.1
rxjs                              6.5.5
typescript                        3.8.3
webpack                           4.42.0

