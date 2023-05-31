# Refatorando o projeto
11/09/2021

## Dependências

Aqui vou listar as dependencias de desenvolvimento do projeto.

### [Identity Server](https://duendesoftware.com/)
O Identity Server está sendo usado para fazer a autenticação do usuário, ele é um servidor de identidade OpenID Connect e OAuth 2.0 para ASP.NET Core.

A ferramenta é gratuita para desenvolvimento, testes e projetos pessoais. Mas para produção é necessário adquirir uma licença.

### [MediatR](https://github.com/jbogard/MediatR/wiki)
O MediatR é uma biblioteca de mensagens simples em .NET. Ele ajuda a implementar o padrão Mediator para manter uma separação clara entre objetos de solicitação e manipuladores de solicitação.

### [FluentResults](https://github.com/altmann/FluentResults)
O FluentResults é uma biblioteca para lidar com resultados de operações de forma mais clara e objetiva.

#

## Padrões e Práticas

### [Mediator](https://refactoring.guru/pt-br/design-patterns/mediator)
O Mediator é um padrão de projeto comportamental que permite reduzir as dependências caóticas entre objetos. O padrão restringe comunicações diretas entre os objetos e os força a colaborar apenas através de um objeto mediador, reduzindo assim o acoplamento.

### [Aggregate](https://martinfowler.com/bliki/DDD_Aggregate.html)
O Aggregate permite que você modele um grupo de objetos como uma única unidade. O Aggregate é a raiz da hierarquia de objetos, e o único objeto que pode ser acessado de fora do Aggregate.

### [Repository](https://martinfowler.com/eaaCatalog/repository.html)
O Repository permite que você abstraia o acesso a dados. Ele permite que você crie uma abstração entre a camada de domínio e a camada de dados.

### [Unit of Work](https://martinfowler.com/eaaCatalog/unitOfWork.html)
O Unit of Work permite que você gerencie transações de banco de dados. Ele permite que você agrupe várias operações de banco de dados em uma única transação.

### [SeedWork](https://martinfowler.com/bliki/Seedwork.html)
O SeedWork permite que você crie uma base para o seu domínio. Ele permite que você crie classes base para as suas entidades, objetos de valor, eventos de domínio, etc.