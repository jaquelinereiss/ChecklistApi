<div align="center">
   <img src="https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white"/>
   <img src="https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
   <img src="https://img.shields.io/badge/ASP.NET%20Core-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white"/>
   <img src="https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=for-the-badge"/>
   <img src="https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white"/>
   <img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black"/>
</div>

# ✅ Checklist API

API REST desenvolvida em **ASP.NET Core 8** para gerenciamento de checklists, seguindo os princípios da **Clean Architecture**, com autenticação, persistência em PostgreSQL e documentação automática via Swagger.


O projeto foi desenvolvido com foco em:

- Separação de responsabilidades
- Código limpo e organizado
- Facilidade de manutenção
- Escalabilidade
- Testabilidade

A API permite o gerenciamento de checklists através de operações CRUD, utilizando PostgreSQL hospedado no Supabase como banco de dados.


# ∴ Arquitetura

O projeto segue o padrão **Clean Architecture**, separando as responsabilidades em camadas independentes.

```
Checklist.Api
│
├── Controllers
├── Middlewares
├── Configurations
│
Checklist.Application
│
├── DTOs
├── Interfaces
├── Services
├── Exceptions
│
Checklist.Domain
│
├── Entities
├── Enums
├── Common
│
Checklist.Infrastructure
│
├── Context
├── Repositories
├── Migrations
├── DependencyInjection
```

# ☼ Tecnologias

- Linguagem: C#
- Framework: .NET 8 e ASP.NET Core Web API
- Banco de Dados: PostgreSQL e Supabase
- ORM: Entity Framework Core,  EF Core Migrations e LINQ
- Arquitetura: Clean Architecture, Repository Pattern, DTO Pattern e Dependency Injection
- API: REST API, Swagger, JSON, Controllers e Middleware
- Programação: Async/Await, Interfaces e Programação Assíncrona
- Versionamento: Git


# ♢ Estrutura do Projeto

```
Checklist.Api
│
├── Controllers
├── Program.cs
├── appsettings.json
│
Checklist.Application
│
├── DTOs
├── Interfaces
├── Services
├── Exceptions
│
Checklist.Domain
│
├── Common
├── Entities
└── Enums
│
Checklist.Infrastructure
│
├── Context
├── DependencyInjection
├── Migrations
└── Repositories
```

# ⛬ Funcionalidades

- Criar, atualizar, excluir e listar checklists do usuário autenticado
- Criar e listar notes do usuário autenticado
- Persistência em PostgreSQL
- Documentação automática com Swagger
- Validação de dados
- Tratamento centralizado de exceções
- Operações assíncronas
- Arquitetura em camadas

# ▹ Como executar

### Clone o projeto

```bash
git clone https://github.com/jaquelinereiss/ChecklistApi.git
```

Entre na pasta

```bash
cd ChecklistApi
```

### Configure o banco

No arquivo **appsettings.json** configure sua Connection String.

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=...;Database=...;Username=...;Password=..."
}
```

### Execute as migrations

```bash
dotnet ef database update
```

### Execute a aplicação

```bash
dotnet run
```

# ▿ Documentação

Após iniciar a aplicação, acesse:

```
https://localhost:{porta}/swagger
```

A documentação é gerada automaticamente utilizando o Swagger.


# ⁂ Padrões utilizados

- Clean Architecture
- SOLID
- Repository Pattern
- DTO Pattern
- Dependency Injection
- Inversion of Control
- Entity Framework Core
- RESTful API
- Programação Assíncrona
- Tratamento global de exceções
- Separação de responsabilidades


#

<div align="center">
  <p>Desenvolvido por Jaqueline Reis.</p>
  <a href="https://github.com/jaquelinereiss">
    <img src="https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white" />
  </a>
  <a href="https://www.linkedin.com/in/jaquelinereiz">
    <img src="https://img.shields.io/badge/LinkedIn-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white" />
  </a>
</div>
