INSERT INTO [dbo].[MANOBRISTA_MNB]
           ([MNB_NOME]
           ,[MNB_CPF]
           ,[MNB_NASCIMENTO]
           ,[MNB_ATIVO])
     VALUES
           (@Nome
           ,@Cpf
           ,@Nasc
           ,1)