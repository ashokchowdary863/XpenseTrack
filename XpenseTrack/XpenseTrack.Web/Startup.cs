using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XpenseTrack.Users.Services;

namespace XpenseTrack.Web {
  public class Startup {
    public Startup( IConfiguration configuration ) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices( IServiceCollection services ) {
      services.AddCors();
      services.AddControllers();
      services.AddSwaggerGen();
      services.AddScoped<IUserService, UserService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure( IApplicationBuilder app, IWebHostEnvironment env ) {
      if ( env.IsDevelopment() ) {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
      // specifying the Swagger JSON endpoint.
      app.UseSwaggerUI( c => {
        c.SwaggerEndpoint( "/swagger/v1/swagger.json", "XPenseTrack API V1" );
      } );
      app.UseCors( x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader() );

      app.UseRouting();

      app.UseMiddleware<JwtMiddleware>();

      app.UseEndpoints( endpoints => {
        endpoints.MapControllers();
      } );
    }
  }
}
