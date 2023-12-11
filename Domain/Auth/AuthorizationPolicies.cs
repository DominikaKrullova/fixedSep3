using Microsoft.Extensions.DependencyInjection;
 using System.Security.Claims;
 public static class AuthorizationPolicies
 {
     public static void AddPolicies(IServiceCollection services)
     {
         services.AddAuthorizationCore(options =>
         {
             options.AddPolicy("MustBeVia", a =>
                 a.RequireAuthenticatedUser().RequireClaim("Domain", "via"));
     
             options.AddPolicy("MustBeTeacher", a =>
                 a.RequireAuthenticatedUser().RequireClaim("Role", "Teacher"));
             
             options.AddPolicy("MustBeTeacher", a =>
                 a.RequireAuthenticatedUser().RequireClaim("Role", "Student"));
         });
     }
 }