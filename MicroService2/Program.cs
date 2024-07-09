using DotNetCore.CAP;
using MicroService2;
using Savorboard.CAP.InMemoryMessageQueue;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCap(x =>
{
    x.UseInMemoryStorage();
    //x.UseInMemoryMessageQueue();
    /*x.UseRabbitMQ(opt =>
    {
        opt.ConnectionFactoryOptions = options =>
        {
            options.Ssl.Enabled = false;
            options.HostName = "fly.rmq.cloudamqp.com";
            options.UserName = "vfusdmvo";
            options.Password = "FvZR1nWM502aW_14qzRSxVUblSSkmqc1";
            options.VirtualHost = "vfusdmvo";
            options.Port = 5672;
        };
    });*/
    x.UseAzureServiceBus(opt =>
    {
        opt.ConnectionString = "Endpoint=sb://sbs-co-nop-sistecredito.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=UoBmYl4rcUhlPnpVM9PnjnYLNGXc+gava+ASbGgYGFA=";
        //AzureServiceBusOptions
    });
    x.UseDashboard();
});
builder.Services.AddTransient<OrderCreatedConsumer>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
