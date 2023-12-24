# Sceptrum Project

Sceptrum é um projeto pessoal, com o objetivo de colocar em prática conceitos e tecnologias como: 
.NET, Clean Architecture, CQRS, Domain Driven Design, Dominios Ricos, Event Sourcing, Design Patterns, SOLID, Vue.js...

Projeto em desenvolvimento

Diego Hartwig 
hartwig.diego@gmail.com

Instruções:

- Instalação do banco de dados:

	docker pull mcr.microsoft.com/mssql/server

	docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=[MinhaSenhaDoBancodeDados]' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-CU8-ubuntu

- Para rodar as migrations:

	Update-Database
	

- Para rodar o projeto:

	docker-compose up --build

