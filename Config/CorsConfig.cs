using Microsoft.AspNetCore.Cors.Infrastructure;

namespace SignalRChat.Config {
    public static class CorsConfig {
        public static string AllowAllOriginsCorsPolicy = "AllowAllOriginsCorsPolicy";
        public static string AllowKnownClientOriginsCorsPolicy = "AllowKnownClientOriginsCorsPolicy";
        public static void Configure(CorsOptions options) {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins(
                            "http://localhost:8008",
                            "https://localhost:8008")
                        .AllowCredentials();
                });
                
            options.AddPolicy(AllowAllOriginsCorsPolicy,
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

            options.AddPolicy(AllowKnownClientOriginsCorsPolicy,
                builder =>
                {
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins(
                            "http://localhost:8008",
                            "https://localhost:8008")
                        .AllowCredentials();
                });
        }
    }
}