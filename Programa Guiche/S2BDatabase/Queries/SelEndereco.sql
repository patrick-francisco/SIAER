IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'SelEndereco')
	BEGIN
		DROP  Procedure  SelEndereco
	END

GO

CREATE PROCEDURE dbo.SelEndereco
	(
	@id int = null,
	@rua varchar(50) = null,
	@cep char(8) = null
	)
AS
	DECLARE @sql varchar(3000);
	SET @sql = 'SELECT * FROM endereco WHERE 1 = 1 '
	
	IF(@id IS NOT NULL)
		SET @sql = @sql + ' AND id = ''' + CONVERT(varchar, @id) + ''''
	IF(@rua IS NOT NULL)
		SET @sql = @sql + ' AND rua = ''' + CONVERT(varchar, @rua) + ''''
	IF(@cep IS NOT NULL)
		SET @sql = @sql + ' AND cep = ''' + CONVERT(varchar, @cep) + ''''
	
	
	EXECUTE(@sql)
	PRINT(@sql)

GO



