IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Stored_Procedure_Name')
	BEGIN
		DROP  Procedure  Stored_Procedure_Name
	END

GO

CREATE PROCEDURE dbo.SelUsuario
	(
	@id int = null,
	@nome varchar(50) = null,
	@sobrenome varchar(50) = null,
	@login varchar(10) = null,
	@senha varchar(10) = null,
	@endereco int = null,
	@sexo char(1) = null,
	@ativo bit = null
	)
AS
	DECLARE @sql varchar(3000);
	SET @sql = 'SELECT * FROM usuario WHERE 1 = 1 '
	
	IF(@id IS NOT NULL)
		SET @sql = @sql + ' AND id = ''' + CONVERT(varchar, @id) + ''''
	IF(@nome IS NOT NULL)
		SET @sql = @sql + ' AND nome = ''' + CONVERT(varchar, @nome) + ''''
	IF(@sobrenome IS NOT NULL)
		SET @sql = @sql + ' AND sobrenome = ''' + CONVERT(varchar, @sobrenome) + ''''
	IF(@login IS NOT NULL)
		SET @sql = @sql + ' AND login = ''' + CONVERT(varchar, @login) + ''''
	IF(@senha IS NOT NULL)
		SET @sql = @sql + ' AND senha = ''' + CONVERT(varchar, @senha) + ''''
	IF(@endereco IS NOT NULL)
		SET @sql = @sql + ' AND endereco = ''' + CONVERT(varchar, @endereco) + ''''
	IF(@sexo IS NOT NULL)
		SET @sql = @sql + ' AND sexo = ''' + CONVERT(varchar, @sexo) + ''''
	IF(@ativo IS NOT NULL)
		SET @sql = @sql + ' AND ativo = ''' + CONVERT(varchar, @ativo) + ''''
	
	EXECUTE(@sql)
	PRINT(@sql)


GO


