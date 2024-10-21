using SupportLayer.JwtUtils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region jwt服务注册
//获取配置
builder.Services.Configure<JwtTokenOptions>(builder.Configuration.GetSection("JwtTokenOptions"));
//服务-接口绑定
builder.Services.AddTransient<ICustomJwtService, CustomJwtService>();
JwtTokenOptions tokenOptions = new JwtTokenOptions
{
    Issuer = "issuer",
    Audience = "audience",
    SecurityKey = "key"
};
//绑定jwt token可选项
builder.Configuration.Bind("JwtTokenOptions", tokenOptions);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
