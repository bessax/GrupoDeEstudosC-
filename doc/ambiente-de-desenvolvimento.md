# Ambiente de Desenvolvimento

O ambiente de desenvolvimento é composto por um container Docker, que contém todas as ferramentas necessárias para o desenvolvimento do projeto.

Será necessário instalar algumas ferramentas:

### [🐳 Docker](https://www.docker.com/)

Usado para criar o container de desenvolvimento.
Recomendo a versão [Docker Desktop](https://www.docker.com/products/docker-desktop/).
Caso encontre dificuldades na instalação, use a [documentação oficial](https://docs.docker.com/desktop/).

### [📄 Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers)

Editor de código usado para desenvolver o projeto.

### [🏗️ Dev Containers](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers)

Extensão do Visual Studio Code que permite usar o Docker para criar um ambiente de desenvolvimento.
Instale após concluir a instalação do Visual Studio Code.

## Começando a Desenvolver

### 1. Clone o repositório

```sh
git clone ~/brunoaragao/ByteBank.git
```

### 2. Abra o projeto no Visual Studio Code

```sh
code ByteBank
```

### 3. Abra o projeto no container

Uma notificação será exibida no canto inferior direito do Visual Studio Code, clique em **Reopen in Container**.

Ou use o atalho **Ctrl** + **Shift** + **P** e digite o comando: `> Dev Containers: Reopen in Container`.

⚠️ A primeira vez que o container é compilado pode levar alguns minutos.
Você pode clicar em *show log* para acompanhar o progresso.