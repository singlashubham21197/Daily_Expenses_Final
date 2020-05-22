1. Open the Solution in Visual Studio
2. Build the project 
3. Navigate to tools ans select Nuget Package manager -> Package Manager Console (PMC)
4. On the console execute the following command
Update-Database -Context Daily_Expenses_IdentityContext


5. On the console execute the following command

  Update-Database -Context Daily_Expenses_DataContext



6. After migration is successful Run the project 

7 if you login as admin  from the following credentials will be able to see the Expenses,  
Monlthly reports and User Accounts  Links  
User : admin@expenses.com
Password: 1qaz2wsX@

8. Also you can login with the following credentials to visit the site as a User
 Can add daily expenses and generate montly reports. Also you can sign up as a user with the "User Sign up link"

 User : harry@expenses.com
Password: 1qaz2wsX@



9 if you need to create another  admin login with the admin credentials on step 7 above and
Click in "Register admin user" register a new admin 





The identity  authentication code used in the project were obtained by following URLS

Introduction to Identity on ASP.NET Core
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.0&tabs=visual-studio
