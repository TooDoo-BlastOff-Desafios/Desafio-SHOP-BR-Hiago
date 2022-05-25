CREATE OR ALTER PROCEDURE [spGetNivel]
    @Quantidade INT
AS
    IF @Quantidade >=0 AND @Quantidade <=10
    BEGIN
        SELECT 'Nivel 1' AS retorno
    END
    ELSE  IF  @Quantidade <=20
    BEGIN
        SELECT 'Nivel 2' AS retorno
    END
    ELSE  IF @Quantidade >20
    BEGIN
        SELECT 'Nivel 3' AS retorno
    END
    ELSE
        SELECT 'Nivel inválido' AS retorno