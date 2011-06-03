IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DelEndereco')
	BEGIN
		DROP  Procedure  DelEndereco
	END

GO

CREATE PROCEDURE dbo.DelEndereco
	(
	@id int
	)
AS

DELETE FROM endereco
WHERE id = @id



GO


