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

    EXECUTE [spGetNivel] @NumeroCompras, @Nivel =  @NivelCliente OUTPUT;
    UPDATE 
        [CLiente]
    SET
        [Nivel] = @NivelCLiente
    WHERE 
        [CPF] = @CPF
    
    

END