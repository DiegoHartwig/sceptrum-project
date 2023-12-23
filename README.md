# Sceptrum Project

Sceptrum é um projeto pessoal, com o objetivo de colocar em prática conceitos e tecnologias como: .NET, Clean Architecture, CQRS, Domain Driven Design, Dominios Ricos, Event Sourcing, Design Patterns, SOLID, entre outros. Projeto em desenvolvimento


Instruções:

- Instalação do banco de dados:

	docker pull mcr.microsoft.com/mssql/server

	docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=SqlServer2022!' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-CU8-ubuntu

- Para rodar o projeto:

	docker-compose up --build

