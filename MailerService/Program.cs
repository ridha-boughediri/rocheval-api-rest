using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configure email service using environment variables
var smtpServer = builder.Configuration["Email:SmtpServer"];
var port = int.Parse(builder.Configuration["Email:Port"]);
var username = builder.Configuration["Email:Username"];
var password = builder.Configuration["Email:Password"];

builder.Services.AddSingleton(new EmailService(smtpServer, port, username, password));
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
