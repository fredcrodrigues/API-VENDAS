## API VENDAS E OPORTUNIDADES / COM MONGODB - WEB API

Este projeto é uma API de vendas de acorodo com as regras estabelecidas no [DESAFIO](/Desafio.txt). Dessa forma a API gerencia oportunidades de vendas e seus vendedores.
Neste projeto também está habilitado o **SWAGGER** documentando o funcionamento da API, além de ser desenvolvido no [Microsoft Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/).

Configurações:

```bash
	
	dotnet = 6.0,
	swagger = 6.4.0,
	mondodb.Driver = 2.17,
	newtonsoft.Json = 6.3

```

A versão para produção ainda não está disponível, mas para executar o projeto localmente basta executar:

```bash
	dotnet run watch

```

Nessa API é possível obter dados de um vendedor e uma oportunidade, além de realizar o cadastro de ambos. Todos os dados são salvos 
são salvos no *MONGODB*. Alé disso, é possível obter os dados do CNPJ através de uma API de terceiros [aqui](https://www.cnpj.ws/) usando o httClient conforme a [Documentação da Microsoft](https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0).
A imagem a seguir apresenta o projeto em execução no Microsoft Visual Studio.

![Screenshot](/Image/)














