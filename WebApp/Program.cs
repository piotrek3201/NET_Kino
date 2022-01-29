using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using UseCases;
using UseCases.DataStorePluginInterfaces;
using WebApp.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


builder.Services.AddDbContext<CinemaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AccountContext>(); 

builder.Services.AddDbContext<AccountContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AccountContextConnection")));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
    options.AddPolicy("CashierOnly", p => p.RequireClaim("Position", "Cashier"));
});

//Dependency injection for in-memory data store
/*
builder.Services.AddScoped<IScreeningRoomRepository, ScreeningRoomInMemoryRepository>();
builder.Services.AddScoped<IMovieRepository, MovieInMemoryRepository>();
builder.Services.AddScoped<IShowingRepository, ShowingInMemoryRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationInMemoryRepository>();
builder.Services.AddScoped<ITicketRepository, TicketInMemoryRepository>();
*/

//Dependency injection for EF Core
builder.Services.AddScoped<IScreeningRoomRepository, ScreeningRoomRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IShowingRepository, ShowingRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();


//Dependency injection for use cases and repositories
builder.Services.AddTransient<IViewScreeningRoomsUseCase, ViewScreeningRoomsUseCase>();
builder.Services.AddTransient<IAddScreeningRoomUseCase, AddScreeningRoomUseCase>();
builder.Services.AddTransient<IGetScreeningRoomByIdUseCase, GetScreeningRoomByIdUseCase>();
builder.Services.AddTransient<IEditScreeningRoomUseCase, EditScreeningRoomUseCase>();
builder.Services.AddTransient<IDeleteScreeningRoomUseCase, DeleteScreeningRoomUseCase>();

builder.Services.AddTransient<IViewMoviesUseCase, ViewMoviesUseCase>();
builder.Services.AddTransient<IGetMovieByIdUseCase, GetMovieByIdUseCase>();
builder.Services.AddTransient<IAddMovieUseCase, AddMovieUseCase>();
builder.Services.AddTransient<IEditMovieUseCase, EditMovieUseCase>();
builder.Services.AddTransient<IDeleteMovieUseCase, DeleteMovieUseCase>();

builder.Services.AddTransient<IViewShowingsUseCase, ViewShowingsUseCase>();
builder.Services.AddTransient<IAddShowingUseCase, AddShowingUseCase>();
builder.Services.AddTransient<IGetShowingByIdUseCase, GetShowingByIdUseCase>();
builder.Services.AddTransient<IEditShowingUseCase, EditShowingUseCase>();
builder.Services.AddTransient<IDeleteShowingUseCase, DeleteShowingUseCase>();
builder.Services.AddTransient<IGetFutureShowingsUseCase, GetFutureShowingsUseCase>();
builder.Services.AddTransient<IGetShowingsByDayUseCase, GetShowingsByDayUseCase>();
builder.Services.AddTransient<IGetFutureShowingsByMovieUseCase, GetFutureShowingsByMovieUseCase>();
builder.Services.AddTransient<IGetPastShowingsUseCase, GetPastShowingsUseCase>();

builder.Services.AddTransient<IAddReservationUseCase, AddReservationUseCase>();
builder.Services.AddTransient<IConfirmReservationUseCase, ConfirmReservationUseCase>();
builder.Services.AddTransient<IDeleteReservationByPositionUseCase, DeleteReservationByPositionUseCase>();
builder.Services.AddTransient<IGetReservationsByShowingIdUseCase, GetReservationsByShowingIdUseCase>();
builder.Services.AddTransient<IGetReservationsByTicketUseCase, GetReservationsByTicketUseCase>();
builder.Services.AddTransient<IDeleteExpiredReservationsByShowingIdUseCase, DeleteExpiredReservationsByShowingIdUseCase>();

builder.Services.AddTransient<IAddTicketUseCase, AddTicketUseCase>();
builder.Services.AddTransient<IDeleteTicketByIdsUseCase, DeleteTicketByIdsUseCase>();
builder.Services.AddTransient<IGetTicketsByMailUseCase, GetTicketsByMailUseCase>();
builder.Services.AddTransient<IFinalizeTicketUseCase, FinalizeTicketUseCase>();
builder.Services.AddTransient<IGetTicketByQRStringUseCase, GetTicketByQRStringUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");
});

app.Run();
