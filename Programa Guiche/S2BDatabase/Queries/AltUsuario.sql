IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AltUsuario')
	BEGIN
		DROP  Procedure  AltUsuario
	END

GO

CREATE PROCEDURE dbo.AltUsuario
	(
	@id int,
	@nome varchar(50),
	@sobrenome varchar(50),
	@login varchar(10),
	@senha varchar(10),
	@endereco int,
	@sexo char(1),
	@ativo bit
	)
AS
	UPDATE usuario SET
		nome = @nome,
		sobrenome = @sobrenome,
		login = @login,
		senha = @senha,
		endereco = @endereco, 
		sexo = @sexo, 
		ativo = @ativo
	WHERE id = @id



GO
