IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Stored_Procedure_Name')
	BEGIN
		DROP  Procedure  Stored_Procedure_Name
	END

GO

CREATE PROCEDURE dbo.DelUsuario
	(
	@id int
	)
AS

DELETE FROM usuario
WHERE id = @id



GO

