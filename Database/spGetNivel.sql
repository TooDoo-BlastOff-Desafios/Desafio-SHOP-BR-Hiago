CREATE OR ALTER PROCEDURE [spGetNivel]
    @Quantidade INT,
    @Nivel NVARCHAR(22) OUTPUT
AS
    IF @Quantidade >=0 AND @Quantidade <=10 
    BEGIN
        SELECT @Nivel = 'Nivel 1' 
    END
    ELSE  IF @Quantidade >10 AND @Quantidade <=20
    BEGIN
        SELECT @Nivel = 'Nivel 2' 
    END
    ELSE  IF @Quantidade >20
    BEGIN
        SELECT @Nivel = 'Nivel 3' 
    END
    ELSE
        SELECT @Nivel = 'Nivel invalido'
    
    RETURN 


