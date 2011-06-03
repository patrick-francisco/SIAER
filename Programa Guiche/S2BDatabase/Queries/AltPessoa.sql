IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Stored_Procedure_AltPessoa')
	BEGIN
		DROP  Procedure  Stored_Procedure_AltPessoa
	END

GO

CREATE Procedure Stored_Procedure_AltPessoa
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
