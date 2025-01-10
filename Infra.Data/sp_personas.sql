CREATE PROCEDURE ObtenerPersonas
AS
BEGIN
    SELECT P.Id, CONCAT(P.Nombres, ' ', P.Apellidos), U.[User], U.FechaCreacion FROM Personas P INNER JOIN Usuarios U ON U.IdPersona = P.Id;
END;