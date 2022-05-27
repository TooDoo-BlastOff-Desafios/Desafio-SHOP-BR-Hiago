CREATE OR ALTER PROCEDURE [spAddCompra]
 @CPF NVARCHAR(14),
 @ProdutoId UNIQUEIDENTIFIER,
 @Quantidade INT,
 @Valor DECIMAL,
 @TipoPagamento NVARCHAR(80),
 @CodigoCorreio UNIQUEIDENTIFIER
 AS
    DECLARE @ExisteCorreio UNIQUEIDENTIFIER
    DECLARE @ExistePessoa NVARCHAR(14)
    DECLARE @ExisteProduto UNIQUEIDENTIFIER
    DECLARE @JaComprado INT
    DECLARE @ValidaQuantidade UNIQUEIDENTIFIER
    SELECT @ExisteCorreio = Id FROM Correio WHERE Id = @CodigoCorreio

    IF @ExisteCorreio = NULL
        BEGIN
            SELECT 'Compra não realizada, Frete não disponível' AS retorno
        END
    ELSE
    BEGIN
        SELECT @ExistePessoa = [Cliente].[CPF] 
        FROM 
            [Cliente]
        WHERE [Cliente].[CPF] = @CPF 


        SELECT  @ExisteProduto = [Produto].Id
        FROM 
            [Produto]
        WHERE Produto.Id = @ProdutoId

        IF @ExistePessoa = NULL OR @ExisteProduto = NULL
            BEGIN 
                SELECT 'Compra não realizada, CPF ou Produto inválido' AS retorno
            END
        ELSE
        BEGIN    
            SELECT @ValidaQuantidade = [Produto].[Id] From [Produto] WHERE [Produto].[Quantidade] >= @Quantidade 
            IF @ValidaQuantidade != NULL
            BEGIN
                SELECT 'Compra não realizada, quantidade insuficiente' AS retorno
            END
            ELSE
            BEGIN
                SELECT @JaComprado = COUNT(Compra.ProdutoId) FROM Compra WHERE Compra.ClienteId = @CPF AND Compra.ProdutoId = @ProdutoId
                IF  @JaComprado = 0
                BEGIN
                    UPDATE
                        [Produto]
                    SET
                        [Quantidade] = [Quantidade] - @Quantidade
                    WHERE
                        [Produto].Id = @ProdutoId
                    INSERT INTO
                        [Compra]
                        (ProdutoId, ClienteId, CorreioId, Valor,Quantidade, TipoPagamento) 
                        VALUES
                        (@ProdutoId, @CPF, @CodigoCorreio, @Valor, @Quantidade, @TipoPagamento)                
                    SELECT 'Compra realizada com sucesso' AS retorno
                END
                ELSE IF @JaComprado =1
                BEGIN
                    UPDATE
                        [Produto]
                    SET
                        [Quantidade] = [Quantidade] - @Quantidade
                    WHERE
                        [Produto].Id = @ProdutoId

                    UPDATE
                        [Compra]
                    SET
                        [Quantidade] = [Quantidade] + @Quantidade
                    WHERE
                        [Compra].ProdutoId = @ProdutoId AND [Compra].ClienteId = @CPF
                    SELECT 'Compra realizada com sucessoo' AS retorno
                END
            END   
        END
    END            
