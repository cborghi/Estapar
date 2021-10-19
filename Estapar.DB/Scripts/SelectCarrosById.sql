SELECT [CRR_ID]
      ,[CRR_MARCA]
      ,[CRR_MODELO]
      ,[CRR_PLACA]
      ,[CRR_ATIVO]
  FROM [dbo].[CARRO_CRR]
WHERE [CRR_ATIVO] = 1
AND [CRR_ID] = @Id

