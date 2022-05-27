CREATE OR ALTER FUNCTION [funcGetNivel] (@Quantidade INT)
    RETURNS NVARCHAR(22)   
AS
BEGIN
    DECLARE @Nivel NVARCHAR(22)
    IF @Quantidade >=0 AND @Quantidade <=10 
    BEGIN
        SELECT @Nivel =  'Nivel 1' 
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
    RETURN @Nivel;
END
