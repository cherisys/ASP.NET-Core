//Scaffolding Command

dotnet ef dbcontext scaffold 
"server=(LocalDB)\MSSQLLocalDB;database=ZoomShoesDb" 
"Microsoft.EntityFrameworkCore.SqlServer" 
--output-dir "Models/Scaffold" 
--context ScaffoldContext 
--project ExistingDB


//Re-Scaffolding Command
dotnet ef dbcontext scaffold 
"Server=(localdb)\MSSQLLocalDB;Database=ZoomShoesDb"
"Microsoft.EntityFrameworkCore.SqlServer" 
--output-dir "Models/Scaffold" 
--context ScaffoldContext 
--project ExistingDB
--force --no-build

// --force arguments tells EF Core to replace existing Data Models classes by new ones.
// --no-build prevents the application from being build before the scaffolding process is performed.

