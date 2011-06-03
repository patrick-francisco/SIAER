IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsEndereco')
	BEGIN
		DROP  Procedure  InsEndereco
	END

GO

CREATE PROCEDURE dbo.InsEndereco
	(
	@id int OUTPUT,
	@rua varchar(50),
	@cep char(8)
	)
AS
	INSERT INTO endereco
	(rua, cep)
	VALUES
	(@rua, @cep)

SET @id = @@IDENTITY

GO



