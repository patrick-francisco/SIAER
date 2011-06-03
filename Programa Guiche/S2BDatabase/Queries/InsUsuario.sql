IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsUsuario')
	BEGIN
		DROP  Procedure  InsUsuario
	END

GO

CREATE PROCEDURE dbo.InsUsuario
	(
	@id int OUTPUT,
	@nome varchar(50),
	@sobrenome varchar(50),
	@login varchar(10),
	@senha varchar(10),
	@endereco int,
	@sexo char(1),
	@ativo bit
	)
AS
	INSERT INTO usuario
	(nome, sobrenome, login, senha, endereco, sexo, ativo)
	VALUES
	(@nome, @sobrenome, @login, @senha, @endereco, @sexo, @ativo)

SET @id = @@IDENTITY

GO



