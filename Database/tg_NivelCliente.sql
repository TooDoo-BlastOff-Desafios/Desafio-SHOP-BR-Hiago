
CREATE TRIGGER [tg_ClientNivel] 
ON [Compra]
FOR INSERT
AS
BEGIN
    DECLARE @NumeroCompras INT,
             @CPF NVARCHAR(14),
             @NivelCliente NVARCHAR(22)
    
    SELECT @CPF = [ClienteId] FROM INSERTED

    SELECT @NumeroCompras = COUNT(ClienteId)
    FROM 
    [Compra]
    WHERE
    [ClienteId] = @CPF

    UPDATE 
        [CLiente]
    SET
        [Nivel] = dbo.funcGetNivel(@NumeroCompras)
    WHERE 
        [CPF] = @CPF
    
    

END