CREATE DATABASE EdCommerce;
GO

USE EdCommerce
GO

CREATE TABLE Carrinho( IdCarrinho INT PRIMARY KEY IDENTITY(1,1) NOT NULL,       
	   SubTotal decimal (17,2) NOT NULL DEFAULT 0.00,
	   DataCriacao DATETIME NOT NULL,
	   CPF NVARCHAR(11) NOT NULL
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
	   Preco decimal (10,2) NOT NULL DEFAULT 0.00,
	   --Qtdstoque
	   );
	   GO

CREATE TABLE ItensCarrinho( IdItem INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	   IdCarrinho int, 
	   IdProd int,
	   QuantidadeProd int
	     FOREIGN KEY (IdCarrinho) REFERENCES Carrinho (IdCarrinho) ON DELETE CASCADE,
		 FOREIGN KEY (IdProd) REFERENCES Produto (IdProd) ON DELETE CASCADE
	   );
	   GO

INSERT INTO Produto
           (Nome
           ,Preco)
       VALUES
           ('Tênis' , 
		   202
		   )
      GO

INSERT INTO Produto
           (Nome
           ,Preco)
     VALUES
           ('Mochila Adidas' , 
		   150.99
		   )
GO

INSERT INTO Produto
           (Nome
           ,Preco)
     VALUES
           ('10 Pratos' , 
		   50.99
		   )
GO

INSERT INTO Produto
           (Nome,
		   Preco)
     VALUES
           ('Kit Garfos' , 
		   40
		   )
GO


INSERT INTO Carrinho
           ( 
			 DataCriacao,
			 CPF
			)
     VALUES
           ( 
		    GETDATE(),
			'29493448878'
		   )
GO


INSERT INTO ItensCarrinho
           (IdCarrinho,
            IdProd,
			QuantidadeProd)
     VALUES
           (1 , 
		    1,
			1
		   )
GO


INSERT INTO ItensCarrinho
           (IdCarrinho,
            IdProd,
			QuantidadeProd)
     VALUES
           (1 , 
		    2,
			1
		   )
GO

INSERT INTO ItensCarrinho
           (IdCarrinho,
            IdProd,
			QuantidadeProd)
     VALUES
           (1 , 
		    3,
			1
		   )
GO

INSERT INTO ItensCarrinho
           (IdCarrinho,
            IdProd,
			QuantidadeProd)
     VALUES
           (1 , 
		    4,
			1
		   )
GO