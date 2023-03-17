add-migration IdentityMigration -context AuthenticationContext
update-database -context AuthenticationContext


add-migration GolfClappMigration -context GolfClappContext
update-database -context GolfClappContext


Probar register y seguir con el tutorial login jwt...
https://www.endpointdev.com/blog/2022/06/implementing-authentication-in-asp.net-core-web-apis/


https://medium.com/@ajidejibola/authentication-and-authorization-in-net-6-with-jwt-and-asp-net-identity-2566e75851fe
https://www.c-sharpcorner.com/article/jwt-authentication-and-authorization-in-net-6-0-with-identity-framework/