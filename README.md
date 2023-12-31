﻿ # Exemplo de CRUD de Produtos
  
 Isso é um CRUD, utilizando como exemplo um sistema de gerenciamento de Produtos. A API é feita em .NET 6, seguindos os principios de arquitetura limpa (Clean Arquitecture), utilizando Entity Framework Core, Docker. O banco de dados utilizado foi o SQL Server.
 A front foi criado utilizando a versão 13 do Angular. 
 
 ## Executando a API
 1. Instale a versão mais atual do [.NET SDK](https://dotnet.microsoft.com/download)
 2. Instale a versão mais atual do [Docker](https://docs.docker.com/desktop/install/windows-install)
 3. Após isso, com o docker executando na máquina, abra o prompt de comando na raiz do projeto da API e execute os seguintes comandos:
  *  `docker compose build` *esse comando irá executar o build do projeto;*
  *  `docker compose up` *esse comando irá subir os containers da WebApi e do Banco de dados*
 4. Após o banco de dados subir com sucesso, é necessário rodar os seguintes comandos na pasta .\API\src\Apps\ProductsSystem.Api
  * ` dotnet tool install --global dotnet-ef ` *rode esse comando caso não tenha o dotnet entity framework core instalado*
  * ` dotnet ef migrations add InitialCreate ` *esse comando irá criar os migrations baseado na esturutra de tabelas da API*
  * ` dotnet ef database update` *esse comando irá criar as tabelas necessárias*
    
Com isso, o docker irá subir o conteiner do banco de dados e da API. Assim que a API for executada pela primeira vez, ela executará o Migration, criando as tabelas no banco.
Você poderá acessar o swagger da API a partir do endereço: http://localhost:5005/swagger;

 ## Executando o Front End
 1. Instale a versão mais atual do [Node](https://nodejs.org/en/download/)
 2. Siga o passo a passo para a instalação do [Angular Cli](https://angular.io/cli)
 3. Após isso, abra o prompt de comando na raiz do projeto Angular e execute os seguintes comandos:
    *  `npm install`  *esse comando irá instlar as bibliotecas necessárias para rodar o projeto;*
    *  `ng serve` *esse comando irá dar o start na aplicação, que poderá ser acessada pelo caminho:* http://localhost:4200/Home
 
