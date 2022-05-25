CREATE OR ALTER PROCEDURE [spGetNivel]
 @CPF NVARCHAR(14),
 @ProdutoId UNIQUEIDENTIFIER,
 @Quantidade INT,
 @Valor FLOAT,
 @TipoPagamento NVARCHAR(80),
 @CodigoCorreio UNIQUEIDENTIFIER
 AS
    DECLARE @ExisteCorreio UNIQUEIDENTIFIER
    DECLARE @ExistePessoaProduto UNIQUEIDENTIFIER
    DECLARE @ValidaQuantidade UNIQUEIDENTIFIER
    SELECT @ExisteCorreio = Id FROM Correio WHERE Id = @CodigoCorreio
    IF @ExisteCorreio = NULL
        BEGIN
            SELECT 'Compra não realizada, Frete não disponível' AS retorno
        END
        ELSE
            SELECT @ExistePessoaProduto = [Cliente].[CPF] 
            FROM 
                [Cliente]
                INNER JOIN [Produto]
                ON [Cliente].[CPF] = @CPF AND [Produto].[Id] = @ProdutoId

            IF @ExistePessoaProduto = NULL
                BEGIN 
                    SELECT 'Compra não realizada, CPF ou Produto inválido' AS retorno
                END
            ELSE    
                SELECT @ValidaQuantidade = [Produto].[Id] From [Produto] WHERE [Produto].[Quantidade] >= @Quantidade 
                IF @ValidaQuantidade != NULL
                BEGIN
                    INSERT INTO [Compra](ProdutoId, ClienteId, CorreioId, Valor,Quantidade, TipoPagamento) VALUES (@ProdutoId, @CPF, @CodigoCorreio, @Valor, @Quantidade, @TipoPagamento)
                    SELECT '“Compra realizada com sucesso' AS retorno
                END
                ELSE
                    SELECT 'Compra não realizada, quantidade insuficiente' AS retorno
