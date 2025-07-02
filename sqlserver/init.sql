CREATE DATABASE EdCommerce;
GO

USE EdCommerce
GO

CREATE TABLE Carrinho( IdCarrinho INT PRIMARY KEY IDENTITY(1,1) NOT NULL,       
	   SubTotal decimal (17,2) NOT NULL DEFAULT 0.00,
	   DataCriacao DATETIME NOT NULL
	   );
	   GO 

	   CREATE TABLE Desconto( Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	   IdCarrinho int, 
	   SubTotal decimal (17,2) NOT NULL DEFAULT 0.00,
	   DataCriacao DATETIME NOT NULL
	   );
	   GO


	   

	    CREATE TABLE Produto( idProd INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	   Nome NVARCHAR(25), 
	   Preco decimal,
	   quantidadeProd int
	   );
	   GO

	   CREATE TABLE ItensCarrinho( IdItem INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	   IdCarrinho int, 
	   IdProd int,
	   quantidadeProd int
	     FOREIGN KEY (IdCarrinho) REFERENCES Carrinho (IdCarrinho) ON DELETE CASCADE,
		 FOREIGN KEY (IdProd) REFERENCES Produto (IdProd) ON DELETE CASCADE
	   );
	   
