UPDATE [dbo].[MANOBRISTA_MNB]
SET [MNB_NOME] = @Nome
   ,[MNB_CPF] = @Cpf
   ,[MNB_NASCIMENTO] = @Nasc
   WHERE [MNB_ID] = @Id