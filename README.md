# ASP.NET Core API Versioning Demo

A comprehensive demonstration of API versioning in ASP.NET Core using URL path versioning with Swagger documentation.

## 🚀 Features

- **URL Path Versioning**: Clean versioning using URL segments (e.g., `/api/v1.0/Hello`, `/api/v2.0/Hello`)
- **Swagger Integration**: Interactive API documentation with version-specific endpoints
- **Version Discovery**: Automatic API version reporting in response headers
- **Deprecation Support**: Mark older API versions as deprecated
- **Multiple Controllers**: Separate controllers for different API versions
- **Clean Architecture**: Well-organized project structure

## 🛠️ Technology Stack

- **.NET 9.0**: Latest .NET framework
- **ASP.NET Core**: Web API framework
- **Microsoft.AspNetCore.Mvc.Versioning**: API versioning library
- **Swashbuckle.AspNetCore**: Swagger/OpenAPI documentation
- **Microsoft.AspNetCore.OpenApi**: OpenAPI specification support

## 📋 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio Code, Visual Studio, or any preferred IDE
- Git (for cloning the repository)

## 🏃‍♂️ Quick Start

### 1. Clone the Repository
```bash
git clone https://github.com/mphiliseni/API-Versioning-.git
cd API-Versioning-/APIVersion
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Build the Project
```bash
dotnet build
```

### 4. Run the Application
```bash
dotnet run
```

The API will be available at `https://localhost:5238` (or the port shown in the console output).

## 📖 API Endpoints

### Version 1.0 (Deprecated)
- **GET** `/api/v1.0/Hello` - Returns greeting from version 1.0
- **Response**: `"👋 Hello API - Version 1"`

### Version 2.0 (Current)
- **GET** `/api/v2.0/Hello` - Returns greeting from version 2.0  
- **Response**: `"👋 Hello API - Version 2"`

### Documentation
- **Swagger UI**: `/swagger` - Interactive API documentation
- **OpenAPI Spec**: `/swagger/{version}/swagger.json` - OpenAPI specification for each version

## 🔧 Configuration

### API Versioning Setup

The API versioning is configured in `Program.cs`:

```csharp
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
```

### Controller Versioning

Controllers are versioned using attributes:

```csharp
[ApiVersion("1.0", Deprecated = true)]  // V1 - Deprecated
[ApiVersion("2.0")]                     // V2 - Current
[Route("api/v{version:apiVersion}/[controller]")]
```

## 📁 Project Structure

```
APIVersion/
├── Controllers/
│   ├── V1/
│   │   └── HelloController.cs    # Version 1.0 controller (deprecated)
│   └── V2/
│       └── HelloController.cs    # Version 2.0 controller
├── Options/
│   └── ConfigureSwaggerOptions.cs # Swagger configuration
├── Properties/
│   └── launchSettings.json       # Launch configuration
├── Program.cs                    # Application startup
├── ApiVersion.csproj            # Project file
└── appsettings.json             # Application settings
```

## 🧪 Testing the API

### Using curl

```bash
# Test Version 1.0
curl -X GET "https://localhost:5238/api/v1.0/Hello"

# Test Version 2.0
curl -X GET "https://localhost:5238/api/v2.0/Hello"

# Check API versions (look for api-supported-versions header)
curl -I "https://localhost:5238/api/v2.0/Hello"
```

### Using Swagger UI

1. Navigate to `https://localhost:5238/swagger`
2. Select the API version from the dropdown
3. Expand the endpoint and click "Try it out"
4. Execute the request to see the response

## 🔍 Key Features Explained

### Version Discovery
The API reports supported versions in the `api-supported-versions` response header, making it easy for clients to discover available versions.

### Deprecation Handling
Version 1.0 is marked as deprecated using the `Deprecated = true` parameter, which will be reflected in the API documentation and response headers.

### URL Path Versioning
This implementation uses URL path versioning (`/api/v{version}/controller`), which is:
- **SEO Friendly**: Easy to cache and index
- **Clear**: Version is explicitly visible in the URL
- **Routing Friendly**: Works well with ASP.NET Core routing

### Swagger Integration
Each API version gets its own Swagger document, allowing for:
- Version-specific documentation
- Different schemas per version
- Clear separation of concerns

## 🚀 Deployment

### Development
```bash
dotnet run --environment Development
```

### Production
```bash
dotnet publish -c Release -o ./publish
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📚 Additional Resources

- [ASP.NET Core API Versioning Documentation](https://github.com/Microsoft/aspnet-api-versioning)
- [Microsoft Docs: API Versioning](https://docs.microsoft.com/en-us/aspnet/core/web-api/advanced/versioning)
- [Swagger/OpenAPI Documentation](https://swagger.io/docs/)

## 🐛 Troubleshooting

### Port Already in Use
If you get a "port already in use" error:
```bash
# Find the process using the port
lsof -i :5238

# Kill the process (replace PID with actual process ID)
kill -9 <PID>
```

### Build Errors
Ensure all NuGet packages are restored:
```bash
dotnet clean
dotnet restore
dotnet build
```

---

**Made with ❤️ using ASP.NET Core and API Versioning**
