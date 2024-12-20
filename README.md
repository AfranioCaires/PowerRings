# Lord of Rings - Sistema de Gerenciamento de Anéis de Poder

Este projeto é uma aplicação web para gerenciar os Anéis de Poder do universo de O Senhor dos Anéis, construída
utilizando Clean Architecture e CQRS.

## 🏗️ Arquitetura

O projeto está estruturado em camadas seguindo os princípios da Clean Architecture:

- LordOfRings.Domain: Contém as entidades e regras de negócio
- LordOfRings.App: Implementa os casos de uso e padrão CQRS
- LordOfRings.Infrastructure: Responsável pelo acesso a dados e implementações concretas
- LordOfRings.API: API REST com Swagger
- LordOfRings.Web: Interface web em ASP.NET Core MVC

## 🚀 Tecnologias

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server
- MediatR
- AutoMapper
- Swagger

-

## ⚙️ Pré-requisitos

- .NET 8.0 SDK
- SQL Server

## 📦 Como Executar

Clone o repositório:

``` bash
git clone https://github.com/AfranioCaires/PowerRings
```

Configure a string de conexão no arquivo appsettings.json da API:

``` json
{
   "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=LordOfRings;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
   }
}
```

3. Execute as migrações do banco de dados:
   ``` bash
   cd LordOfRings.API
   dotnet ef database update
   ```
   Execute a API (porta 5043):
   ``` bash
   dotnet run
   ```
   Em outro terminal, execute a aplicação Web (porta 5281):
   ``` bash
   cd ../LordOfRings.Web
   dotnet run
   ```
   Acesse:
   Web App: http://localhost:5281
   Swagger: http://localhost:5043/swagger
## 🎯 Funcionalidades
- Cadastro de Anéis de Poder
- Listagem de todos os anéis
- Edição de informações
- Remoção de anéis
- Validação de regras de negócio (limite de anéis por portador)
   
## 🏛️ Padrões Utilizados
- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- Repository Pattern
- Dependency Injection
- Unit of Work