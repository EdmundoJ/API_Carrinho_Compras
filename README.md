# 🛒 EdCommerce API

[![.NET](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/)
[![Docker](https://img.shields.io/badge/Docker-✓-blue)](https://www.docker.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red)](https://www.microsoft.com/sql-server)
[![Redis](https://img.shields.io/badge/Redis-✓-red)](https://redis.io/)

Um Microsserviço baseado em um carrinho de loja virtual, feito com .NET 8, SQL Server, Redis, and Docker.


## 🚀 Tecnologias

- **Backend**: .NET 8 Web API
- **Database**: SQL Server 2019
- **Cache**: Redis
- **Containerization**: Docker
- **ORM**: Dapper

## ⚙️ Pré-requisitos

- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)

## 🐳 início

```bash
git clone https://github.com/EdmundoJ/API_Carrinho_Compras.git
execute no no ms sql server o script init.sql que se encontra na pasta "API_Carrinho_Compras\sqlserver", para ter o banco criado com seus respectivos campos.
Pelo visual studio, dentro da aplicação, mude a string de conexão no AppSettings.json. 
Em seguida rode a aplicação

## 🐳 Início rápido (Em Desenvolvimento)
```bash
git clone https://github.com/EdmundoJ/API_Carrinho_Compras.git
cd shopping-api
docker-compose up -d
```
- Services will be available at:
    . API: http://localhost:8080
    . SQL Server: localhost:1433
    . Redis: localhost:6379

## 🏗️ Project Structure

```
Shopping.API/
  Application/
    Controllers/          (API endpoints)
    Services/            (Implementações de lógica de negócios)
    Services/Interfaces/ (Service contracts)
  
  Domain/
    Models/              (Entidades de domínio principais)
    Models/Request/      (Input DTOs)
    Models/Response/     (Output DTOs)
  
  Infrastructure/
    Data/                (Contexto e configurações de dados)
    Repositories/        (Acesso aos dados de implementação)
    Repositories/Interfaces/ (Contratos de Repositório)
  
  Root files:
    Program.cs           (Main application configuration)
    Dockerfile           (Docker container configurações)
    docker-compose.yml   (Service orchestration)
```

## 📊 Database Schema

Carrinho Tabela
Column	            | Type	        | Description
--------------------|---------------|----------------
IdCarrinho                | INT	          | Primary Key
SubTotal 		  | VARCHAR(20)	  |  Valor
DataCriacao 		  | DATETIME	  | Creation date
CPF | NVARCHAR(11)	  | CPF/CNPJ

Produto Tabela
Column	            | Type	        | Description
--------------------|---------------|----------------
idProd 			|	INT	| Primary Key
Nome 			| VARCHAR(100)	| Nome Produto
Preco 			| DECIMAL(10,2)	| Valor unitário

Desconto Tabela
Column	            | Type	        | Description
--------------------|---------------|---------------
Id	            INT	          | Primary Key
IdCarrinho 	            | INT	          | Foreign Key
SubTotal 		    | DECIMAL (17,2)	  | Valor a pagar após desconto
DataCriacao 		    | DATETIME	    | Data do registro

ItensCarrinhoTabela
Column	            | Type	        | Description
--------------------|---------------|----------------
IdItem 			| INT	    | Primary Key
IdCarrinho 		| INT	    | Carrinho Id
IdProd 			| INT	    | Produto Id 
QuantidadeProd          | INT       | Quantidade produto

## 🌐 API Endpoints

### 🛒 Carrinho Endpoints

criados

-**POST**`/carrinhos` - Cria um carrinho


-**GET** `/carrinhos/{idCarrinho}` - Trás todos os itens dentro de um carrinho OBS:(Falta calcular o valor total).


-**DELETE** `/api/Carrinho/carrinhos/{idCarrinho}/itens{produtoId}`

Pendentes/ Em desenvolvimento

-**POST** '/carrinhos/{carrinhoId}/itens: Adiciona um item ao carrinho.'

-**POST** '/carrinhos/{carrinhoId}/desconto: Aplica um desconto ao'
carrinho.


## ⚠️ Error Handling

Standardized error responses:

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "Not Found",
  "status": 404,
  "detail": "Cart not found"
}
```

