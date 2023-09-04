namespace EventManagement.Extensions
{
    public static  class AddAuthentication
    {
        public static WebApplicationBuilder addAuthorizationExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("Role", "Admin");
                });
            });
            return builder;
        }
    }
}
