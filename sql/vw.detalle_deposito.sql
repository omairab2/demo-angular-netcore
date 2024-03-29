USE [concentracion]
GO
/****** Object:  View [dbo].[vw_detalle_deposito]    Script Date: 24/05/2021 17:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  VIEW [dbo].[vw_detalle_deposito] AS
	SELECT pf.ProductoFinancieroID, pf.Nombre, pf.Descripcion, pf.PorcentajeTea, pf.PlazoMinimoDia, 
pf.PlazoMaximoDia, pf.observacion, dpf.MontoMinimoDeposito, dpf.MontoMaximoDeposito,
dpf.MontoMinimoPrestamo, dpf.TipoMonedaId, p.Valor2 as moneda,  ef.NombreComercial AS Producto
FROM ProductoFinanciero pf 
JOIN DetalleProductoFinanciero dpf ON dpf.ProductoFinancieroID = pf.ProductoFinancieroID
JOIN Parametro p ON dpf.TipoMonedaId = p.ParametroID
 JOIN EntidadFinanciera ef ON ef.EntidadFinancieraID = pf.EntidadFinancieraID
GO
