var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddRepositoryService();
builder.Services.AddIdentityService(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseStaticFiles();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();