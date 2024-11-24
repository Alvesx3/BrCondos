# TaskManager 📝

TaskManager é uma aplicação web construída usando **Blazor WebAssembly** e **ASP.NET Core 8**. A aplicação permite a gestão de tarefas com funcionalidades de autenticação, CRUD (criar, ler, atualizar e deletar) de tarefas, e integração com banco de dados.

## Funcionalidades 🔧

- **CRUD de Tarefas**: Adicione, edite e exclua tarefas.
- **Autenticação JWT**: Acesso seguro através de tokens JWT.
- **Status das Tarefas**: Organize as tarefas com diferentes status.
- **Swagger**: Documentação da API via Swagger para fácil teste de endpoints.

## Tecnologias ⚙️

- **Frontend**: Blazor WebAssembly
- **Backend**: ASP.NET Core 8 com Entity Framework
- **Banco de Dados**: SQL Server
- **Autenticação**: JWT (JSON Web Token)
- **Swagger**: Para documentação da API RESTful

## Requisitos 📋

- **.NET 8** ou superior
- **SQL Server** (ou compatível)
- Navegador moderno (Google Chrome, Firefox, Edge)

## Estrutura do Projeto 🗂️

### Backend (API)

O backend é responsável por gerenciar as tarefas, fornecer a autenticação JWT e expor os endpoints RESTful.

- **Controllers**: Endpoints para as operações CRUD de tarefas.
- **Services**: Lógica de negócios e validações.
- **DataContext**: Configuração do banco de dados e ORM (Entity Framework).
- **JWT**: Implementação de autenticação JWT.

### Frontend (Blazor WebAssembly)

O frontend é construído com Blazor, oferecendo uma interface rica e interativa com as funcionalidades de gerenciamento de tarefas.

- **Pages**: Páginas para visualização e interação com as tarefas (como `Lista de Tarefas`, `Editar Tarefa`, etc).
- **Services**: Serviços para comunicação com o backend e gerenciamento do estado da autenticação.
- **Autenticação**: Gerenciamento de token JWT para acesso seguro às páginas.

## Como Rodar o Projeto 🚀

### Passo 1: Configurar o Banco de Dados 💾

1. Crie um banco de dados no **SQL Server** chamado `TaskManager`.
2. Atualize a string de conexão no arquivo `appsettings.json` do backend:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=TaskManager;Trusted_Connection=True;"
   }

### Passo 2: Rodar o Backend 💻
No diretório do backend, execute o seguinte comando para restaurar as dependências:

dotnet restore
Execute o comando para criar as migrações e atualizar o banco de dados:

dotnet ef database update
Para rodar o backend, use o comando:

dotnet run
A API estará disponível em http://localhost:5201 (ou https://localhost:7160 para HTTPS).

### Passo 3: Rodar o Frontend 🌐
No diretório do frontend, execute o comando para restaurar as dependências:

dotnet restore
Para rodar o frontend, use:

dotnet run
A aplicação Blazor será aberta em http://localhost:7140.

### Passo 4: Acessar a Aplicação 👩‍💻👨‍💻
Login: Ao iniciar o frontend, você será redirecionado para a página de login onde um token JWT será gerado.
Tarefas: Após o login, você poderá visualizar, criar, editar e excluir tarefas.

### Passo 5: Documentação da API 📑
A API utiliza Swagger para documentação e testes dos endpoints.

Acesse o Swagger em: http://localhost:5201/swagger (ou https://localhost:7160/swagger para HTTPS).
Estrutura de Diretórios 📂

TaskManager/
├── TaskManager.Client/   # Blazor WebAssembly (Frontend)
│   ├── Pages/            # Páginas de Blazor
│   ├── Services/         # Serviços para comunicação com a API
│   └── wwwroot/          # Arquivos estáticos (CSS, JS, etc)
├── TaskManager.Api/      # Backend ASP.NET Core (API)
│   ├── Controllers/      # Endpoints API
│   ├── DataContext/      # Contexto de banco de dados (EF Core)
│   ├── Models/           # Modelos de dados
│   ├── Services/         # Lógica de negócios
│   └── appsettings.json  # Configurações da aplicação
└── README.md             # Documentação do projeto

### LoginFixo
Usuário = user
Senha = password
