IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AltEndereco')
	BEGIN
		DROP  Procedure  AltEndereco
	END

GO

CREATE PROCEDURE dbo.AltEndereco
	(
	@id int,
	@rua varchar(50),
	@cep char(8)
	)
AS
	UPDATE endereco SET
		rua = @rua,
		cep = @cep
	WHERE id = @id


GO