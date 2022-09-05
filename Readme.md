## API VENDAS E OPORTUNIDADES / COM MONGODB

Este projeto � uma API de vendas de acorodo com as regras estabelecidas no [DESAFIO](). Dessa forma a API gerencia oportunidades de vendas e seus vendedores.
Neste projeto tamb�m est� habilitado o **SWAGGER** documentando o funcionamento da API, al�m de ser desenvolvido no [Microsoft Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/).

Configura��es:

```bash
	
	dotnet => 6.0,
	swagger = 6.4.0,
	mondodb.Driver = 2.17,
	newtonsoft.Json = 6.3,

```

A vers�o para produ��o ainda n�o est� diponivel, mas para executar o projeto basta executar:

```bash
	dotnet run watch

```

Nessa API � poss�vel obter dados de um vendedor e uma oportunidade, al�m de realizar o cadastro de ambos. Todos os dados s�o salvos 
s�o salvos no MONGODB. Al� disso, � possivel obter os dados do CNPJ atrav�s de uma API de terceiros [aqui](https://publica.cnpj.ws) usando o httClient conforme a [Documenta��o da Microsoft](https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0).
A imagem a seguir apresenta o projeto em execu��o no Microsoft Visual Studio.

![Screenshot](/Image/Print.png)












