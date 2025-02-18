# Etapa 1: Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar os arquivos do projeto e restaurar as dependências
COPY *.sln ./
COPY GatewayPagamentos/*.csproj ./GatewayPagamentos/
RUN dotnet restore GatewayPagamentos/GatewayPagamentos.csproj

# Copiar todo o código e fazer o build
COPY . .
RUN dotnet publish GatewayPagamentos/GatewayPagamentos.csproj -c Release -o /app/out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copiar apenas os arquivos necessários do build anterior
COPY --from=build /app/out .

# Expor a porta (necessário para o Render)
EXPOSE 8080

# Definir comando de inicialização
CMD ["dotnet", "GatewayPagamentos.dll"]
