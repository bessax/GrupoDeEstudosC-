<h1 align="center"> Grupo de estudos - Discord de alunos </h1>
<h3 align="center">Desenvolvimento de projetos de estudos na plataforma .NET e linguagem C#. 😄</h3>

## 📚 Sobre o projeto

O projeto tem como objetivo criar uma aplicação bancária, onde o usuário poderá criar uma conta, fazer depósitos, transferências e saques. O projeto está sendo desenvolvido em grupo, com o objetivo de compartilhar conhecimentos e experiências.

## 📝 Conteúdo

- [Sobre o projeto](#-sobre-o-projeto)

## Configuração do ambiente

### 📋 Pré-requisitos

- [.NET 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Sql Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

### 🎲 Configuração do banco de dados

A configuração do banco de dados é feita através do arquivo appsettings.json, que fica na raiz do projeto. O arquivo já está configurado para o banco de dados **Sql Server** local, mas caso queira utilizar outro banco de dados, basta alterar a string de conexão.

```json
"ConnectionStrings": {
    "ByteBankConnection": "Server=(localdb)\\mssqllocaldb;Database=bytebank;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

## 🚀 Como executar o projeto

```bash
# Clone este repositório
$ git clone https://github.com/bessax/GrupoDeEstudosC-.git

# Acesse a pasta do projeto no terminal/cmd
$ cd GrupoDeEstudosC-

# Execute a aplicação em modo de desenvolvimento
$ dotnet run

# O servidor inciará na porta:5039 - acesse http://localhost:5039
```

## 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/) - Linguagem
- [.NET](https://docs.microsoft.com/pt-br/dotnet/) - Framework
- [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/) - ORM
- [Swagger](https://swagger.io/) - Documentação da API

<!-- Author -->

## ✒️ Autor

- **André Bessa** - _Desenvolvedor_ - [bessax](https://github.com/bessax)
