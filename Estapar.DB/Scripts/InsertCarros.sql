INSERT INTO [dbo].[CARRO_CRR]
           ([CRR_MARCA]
           ,[CRR_MODELO]
           ,[CRR_PLACA]
           ,[CRR_ATIVO])
     VALUES
           (@Marca
           ,@Modelo
           ,@Placa
           ,1)

INSERT INTO [dbo].[MOVIMENTACAO_MVM]
           ([CRR_ID])
     VALUES
           (@@IDENTITY)


