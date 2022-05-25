USE master

CREATE DATABASE  [SHOPBR]

USE [SHOPBR]
CREATE TABLE [Produto]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    [Marca] NVARCHAR(50) NOT null,
    [Tipo] NVARCHAR(50) NOT null,
    [Preco] DECIMAL NOT NULL,
    [Quantidade] INT NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY([Id])
)
GO

CREATE TABLE [Loja]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    [Endereco] NVARCHAR(120) NOT NULL,
    [Telefone] NVARCHAR(13) NOT NULL,
    [Email] NVARCHAR(120)
    CONSTRAINT [Pk_Loja] PRIMARY KEY([Id])

)
GO 

CREATE TABLE [ProdutoEmLoja]
(
    [LojaId] UNIQUEIDENTIFIER NOT NULL,
    [ProdutoId] UNIQUEIDENTIFIER NOT NULL,
    [Quantidade] INT NOT NULL

    CONSTRAINT [PK_ProdutoEmLoja] PRIMARY KEY ([LojaId], [ProdutoId]),
    CONSTRAINT [FK_Produto] FOREIGN KEY ([ProdutoId]) REFERENCES Produto ([Id]),
    CONSTRAINT [FK_Loja] FOREIGN key ([LojaId]) REFERENCES Loja ([Id])

)
GO 


CREATE TABLE [Cliente]
(
    [CPF] NVARCHAR(14)  NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,   
    [Endereco] NVARCHAR(120) NOT NULL,
    [Telefone] NVARCHAR(13) ,
    [CEP] NVARCHAR(9) NOT NULL,
    [Email] NVARCHAR(120) NOT NULL ,
    [Senha] NVARCHAR(24) NOT NULL,
    [Nivel] TINYINT NOT NULL CHECK([Nivel] IN(1,2,3))

    CONSTRAINT [PK_CLiente] PRIMARY KEY ([Cpf]),

)
GO


CREATE TABLE [Correio]
(
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() ,
    [Prazo] TINYINT NOT NULL,
    [CustoFrete] FLOAT NOT NULL,

    CONSTRAINT [PK_Correio] PRIMARY KEY ([Id])


)
GO

CREATE TABLE [Compra]
(
    [ProdutoId] UNIQUEIDENTIFIER NOT NULL,
    [ClienteId] NVARCHAR(14) NOT NULL,
    [CorreioId] UNIQUEIDENTIFIER not NULL,
    [Valor] FLOAT NOT NULL,
    [Quantidade] INT NOT NULL,
    [TipoPagamento] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Compras] PRIMARY KEY ([ProdutoId],[ClienteId]),
    CONSTRAINT [FK_ProdutoC] FOREIGN KEY ([ProdutoId]) REFERENCES Produto ([Id]),
    CONSTRAINT [FK_Cliente] FOREIGN KEY ([ClienteId]) REFERENCES Cliente ([CPF]),
    CONSTRAINT [FK_Correio] FOREIGN KEY ([CorreioId]) REFERENCES Correio ([Id])


)
GO


CREATE  TABLE [Avaliacao]
(
    [ClienteId] NVARCHAR(14)  NOT NULL,
    [ProdutoID] UNIQUEIDENTIFIER NOT NULL,
    [Avaliacao] TINYINT NOT NULL CHECK([Avaliacao] IN(1,2,3, 4, 5)),
    [Comentario] NVARCHAR(320),

    CONSTRAINT [PK_Avaliacao] PRIMARY KEY ([ClienteId], [ProdutoID]),
    CONSTRAINT [FK_Produtos] FOREIGN KEY ([ProdutoId]) REFERENCES Produto ([Id]),
    CONSTRAINT [FK_Clientes] FOREIGN KEY ([ClienteId]) REFERENCES Cliente ([CPF]),


)
GO
