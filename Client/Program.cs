using FitnessTrackMono.Client;
using FitnessTrackMono.Client.Services.MeasurementsService;
using FitnessTrackMono.Client.Services.MealService;
using FitnessTrackMono.Client.Services.WorkoutService;
using FitnessTrackMono.Client.Services.ExerciseService;
using FitnessTrackMono.Client.Services.TrackedWorkoutService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("FitnessTrackMono.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("FitnessTrackMono.ServerAPI"));
builder.Services.AddScoped<IMeasurementsService, MeasurementsService>();
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<ITrackedWorkoutService, TrackedWorkoutService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
