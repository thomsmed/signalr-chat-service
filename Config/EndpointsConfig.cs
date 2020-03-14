using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Routing;
using SignalRChat.Hubs;

namespace SignalRChat.Config {
    public static class EndpointsConfig {
        public static void Configure(IEndpointRouteBuilder endpoints) {
            endpoints.MapHub<ChatHub>("/chat", options => {
                options.Transports = HttpTransportType.WebSockets;
            });
            endpoints.MapGet("/nickname", async context =>
            {
                await context.Response.WriteAsync("Smed1");
            });
        }
    }
}