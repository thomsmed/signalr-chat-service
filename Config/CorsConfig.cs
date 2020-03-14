using Microsoft.AspNetCore.Cors.Infrastructure;

namespace SignalRChat.Config {
    public static class CorsConfig {
        public static string MyAllowAllOriginsPolicy = "MyAllowAllOriginsPolicy";
        public static string MyAllowChatClientOriginsPolicy = "MyAllowChatClientOriginsPolicy";
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
                
                options.AddPolicy(MyAllowAllOriginsPolicy,
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

                options.AddPolicy(MyAllowChatClientOriginsPolicy,
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