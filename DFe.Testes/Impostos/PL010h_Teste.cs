using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using DFe.Classes.Entidades;
using DFe.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Compartilhado;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Compartilhado.InformacoesIbsCbs;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Compartilhado.InformacoesIbsCbs.InformacoesCbs;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Compartilhado.InformacoesIbsCbs.InformacoesIbs;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Compartilhado.InformacoesIbsCbs.Monofasia;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Compartilhado.InformacoesIbsCbs.SimplesNacional;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Compartilhado.Tipos;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Identificacao;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Classes.Informacoes.PagamentoVinculado;
using NFe.Classes.Informacoes.Total;
using NFe.Classes.Servicos.Evento;
using NFe.Classes.Servicos.Tipos;

namespace DFe.Testes.Impostos
{
    /// <summary>
    ///     Testes das alterações do pacote de schemas PL_010h_v1.03 (NF-e/NFC-e - Reforma Tributária).
    /// </summary>
    [TestClass]
    public class PL010h_Teste
    {
        private const string NamespaceNFe = "http://www.portalfiscal.inf.br/nfe";

        #region Identificação / emitente / produto

        [TestMethod]
        public void DadoGCompraGovComNovosValoresQuandoSerializarEntaoDeveGerarCodigosERefDFeAnt()
        {
            /** 1) Preparação **/
            var gCompraGov = new gCompraGov
            {
                tpEnteGov = TpEnteGov.ComiteGestorDoIbs,
                pRedutor = 10m,
                tpOperGov = TpOperGov.FornecimentoComPagamentoJaRealizado,
                refDFeAnt = new List<string> { "35260111222333000181550010000000011000000010" }
            };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(gCompraGov);

            /** 3) Verificação **/
            StringAssert.Contains(xml, "<tpEnteGov>6</tpEnteGov>");
            StringAssert.Contains(xml, "<tpOperGov>3</tpOperGov>");
            StringAssert.Contains(xml, "<refDFeAnt>35260111222333000181550010000000011000000010</refDFeAnt>");
            Assert.IsTrue(xml.IndexOf("<tpOperGov>", StringComparison.Ordinal) < xml.IndexOf("<refDFeAnt>", StringComparison.Ordinal));
        }

        [TestMethod]
        public void DadoGCompraGovSemRefDFeAntQuandoSerializarEntaoNaoDeveGerarRefDFeAnt()
        {
            /** 1) Preparação **/
            var gCompraGov = new gCompraGov { tpEnteGov = TpEnteGov.Uniao, pRedutor = 1m, tpOperGov = TpOperGov.Fornecimento, refDFeAnt = new List<string>() };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(gCompraGov);

            /** 3) Verificação **/
            Assert.IsFalse(xml.Contains("refDFeAnt"));
        }

        [TestMethod]
        public void DadoXmlComTpEnteGov5ETpOperGov4QuandoDesserializarEntaoDeveReconhecerOsNovosValores()
        {
            /** 1) Preparação **/
            const string xml = "<gCompraGov><tpEnteGov>5</tpEnteGov><pRedutor>1.0000</pRedutor><tpOperGov>4</tpOperGov></gCompraGov>";

            /** 2) Execução **/
            var gCompraGov = FuncoesXml.XmlStringParaClasse<gCompraGov>(xml);

            /** 3) Verificação **/
            Assert.AreEqual(TpEnteGov.ConsorcioPublico, gCompraGov.tpEnteGov);
            Assert.AreEqual(TpOperGov.RecebimentoPagamentoComFornecimentoPosterior, gCompraGov.tpOperGov);
        }

        [TestMethod]
        public void DadoEmitenteComTpRegimeIBSCBSQuandoSerializarEntaoDeveGerarDepoisDoCrtEAntesDoISUFEmit()
        {
            /** 1) Preparação **/
            var emitente = new emit
            {
                CNPJ = "11222333000181",
                xNome = "Emitente",
                CRT = CRT.RegimeNormal,
                tpRegimeIBSCBS = TipoRegimeIBSCBS.RegimeNormalOpcaoPendenteSimplesNacional,
                ISUFEmit = "123456789"
            };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(emitente);

            /** 3) Verificação **/
            var posCrt = xml.IndexOf("<CRT>3</CRT>", StringComparison.Ordinal);
            var posRegime = xml.IndexOf("<tpRegimeIBSCBS>2</tpRegimeIBSCBS>", StringComparison.Ordinal);
            var posSuframa = xml.IndexOf("<ISUFEmit>", StringComparison.Ordinal);
            Assert.IsTrue(posCrt >= 0 && posRegime > posCrt && posSuframa > posRegime);
        }

        [TestMethod]
        public void DadoEmitenteSemTpRegimeIBSCBSQuandoSerializarEntaoNaoDeveGerarOElemento()
        {
            /** 1) Preparação **/
            var emitente = new emit { CNPJ = "11222333000181", xNome = "Emitente", CRT = CRT.SimplesNacional };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(emitente);

            /** 3) Verificação **/
            Assert.IsFalse(xml.Contains("tpRegimeIBSCBS"));
        }

        [TestMethod]
        public void DadoProdutoComValoresLiquidosECAtivSNQuandoSerializarEntaoDeveGerarNaPosicaoDoLeiaute()
        {
            /** 1) Preparação **/
            var produto = new prod
            {
                cProd = "1", xProd = "Produto", NCM = "00000000", CFOP = 5102, uCom = "UN", qCom = 1, vUnCom = 10m, vProd = 10m,
                vUnComLiq = 8.1234567891m, vProdLiq = 8.12m,
                uTrib = "UN", qTrib = 1, vUnTrib = 10m, indTot = IndicadorTotal.ValorDoItemCompoeTotalNF,
                cAtivSN = CodigoAtividadeSN.OperacoesNaoTributaveis
            };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(produto);

            /** 3) Verificação **/
            var posVProd = xml.IndexOf("<vProd>", StringComparison.Ordinal);
            var posVUnComLiq = xml.IndexOf("<vUnComLiq>8.1234567891</vUnComLiq>", StringComparison.Ordinal);
            var posVProdLiq = xml.IndexOf("<vProdLiq>8.12</vProdLiq>", StringComparison.Ordinal);
            var posCEanTrib = xml.IndexOf("<cEANTrib", StringComparison.Ordinal);
            var posIndTot = xml.IndexOf("<indTot>", StringComparison.Ordinal);
            var posCAtivSN = xml.IndexOf("<cAtivSN>90</cAtivSN>", StringComparison.Ordinal);
            Assert.IsTrue(posVProd >= 0 && posVUnComLiq > posVProd && posVProdLiq > posVUnComLiq && posCEanTrib > posVProdLiq);
            Assert.IsTrue(posCAtivSN > posIndTot);
        }

        [TestMethod]
        public void DadoProdutoSemCamposDoPL010hQuandoSerializarEntaoNaoDeveGerarOsElementos()
        {
            /** 1) Preparação **/
            var produto = new prod { cProd = "1", xProd = "Produto", vProd = 10m };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(produto);

            /** 3) Verificação **/
            Assert.IsFalse(xml.Contains("vUnComLiq"));
            Assert.IsFalse(xml.Contains("vProdLiq"));
            Assert.IsFalse(xml.Contains("cAtivSN"));
        }

        #endregion

        #region ICMS / IBS / CBS

        [TestMethod]
        public void DadoICMSPrevistoPagtoAntecipQuandoSerializarEntaoDeveGerarOGrupoNoICMS()
        {
            /** 1) Preparação **/
            var icms = new ICMS { TipoICMS = new ICMSPrevistoPagtoAntecip { vICMSPrevisto = 12.3449m } };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(icms);
            var lido = FuncoesXml.XmlStringParaClasse<ICMS>(xml);

            /** 3) Verificação **/
            StringAssert.Contains(xml, "<ICMSPrevistoPagtoAntecip><vICMSPrevisto>12.34</vICMSPrevisto></ICMSPrevistoPagtoAntecip>");
            Assert.IsInstanceOfType(lido.TipoICMS, typeof(ICMSPrevistoPagtoAntecip));
        }

        [TestMethod]
        public void DadoGDevTribComPercentualQuandoSerializarEntaoPDevTribDeveVirAntesDeVDevTrib()
        {
            /** 1) Preparação **/
            var gDevTrib = new gDevTrib { pDevTrib = 20m, vDevTrib = 1.5m };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(gDevTrib);

            /** 3) Verificação **/
            StringAssert.Contains(xml, "<pDevTrib>20.0000</pDevTrib><vDevTrib>1.50</vDevTrib>");
        }

        [TestMethod]
        public void DadoGDevTribSemPercentualQuandoSerializarEntaoNaoDeveGerarPDevTrib()
        {
            /** 1) Preparação **/
            var gDevTrib = new gDevTrib { vDevTrib = 1.5m };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(gDevTrib);

            /** 3) Verificação **/
            Assert.IsFalse(xml.Contains("pDevTrib"));
        }

        [TestMethod]
        public void DadoGCBSComGALCZFMCBSQuandoSerializarEntaoOGrupoDeveVirAntesDeVCBS()
        {
            /** 1) Preparação **/
            var gCbs = new gCBS
            {
                pCBS = 0m,
                gALCZFMCBS = new gALCZFMCBS { tpALCZFMCBS = "1", nProcSuframa = "12345678", pAliqEfetRegCBS = 0.9m, vTribRegCBS = 9m },
                vCBS = 0m
            };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(gCbs);

            /** 3) Verificação **/
            StringAssert.Contains(xml, "<gALCZFMCBS><tpALCZFMCBS>1</tpALCZFMCBS><nProcSuframa>12345678</nProcSuframa><pAliqEfetRegCBS>0.9000</pAliqEfetRegCBS><vTribRegCBS>9.00</vTribRegCBS></gALCZFMCBS><vCBS>");
        }

        [TestMethod]
        public void DadoIBSCBSComGTribSNGEstornoCredEGCredPresIBSZFMQuandoSerializarEntaoDeveSeguirAOrdemDoLeiaute()
        {
            /** 1) Preparação **/
            var ibscbs = new IBSCBS
            {
                CST = CST.Cst000,
                cClassTrib = "000001",
                gTribSN = new gTribSN { gIBSSN = new gIBSSN { pIBSSN = 0.1m, vIBSSN = 0.01m }, gCBSSN = new gCBSSN { pCBSSN = 0.9m, vCBSSN = 0.09m } },
                gEstornoCred = new gEstornoCred { vIBSEstCred = 1m, vCBSEstCred = 1m },
                gCredPresIBSZFM = new gCredPresIBSZFM()
            };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(ibscbs);

            /** 3) Verificação **/
            var posTribSN = xml.IndexOf("<gTribSN>", StringComparison.Ordinal);
            var posEstorno = xml.IndexOf("<gEstornoCred>", StringComparison.Ordinal);
            var posZfm = xml.IndexOf("<gCredPresIBSZFM", StringComparison.Ordinal);
            Assert.IsTrue(posTribSN >= 0 && posEstorno > posTribSN && posZfm > posEstorno);
            StringAssert.Contains(xml, "<gTribSN><gIBSSN><pIBSSN>0.1000</pIBSSN><vIBSSN>0.01</vIBSSN></gIBSSN><gCBSSN><pCBSSN>0.9000</pCBSSN><vCBSSN>0.09</vCBSSN></gCBSSN></gTribSN>");
        }

        [TestMethod]
        public void DadoMonofasiaNoLeiautePL010hQuandoSerializarEntaoDeveGerarGruposSeparadosDeIBSECBS()
        {
            /** 1) Preparação **/
            var mono = new gIBSCBSMono
            {
                gIBSMonoAdValorem = new gIBSMonoAdValorem
                {
                    gMonoPadrao = new gMonoPadraoIBSAdValorem { vBCMono = 100m, pAliqMonoUF = 0.1m, vIBSMonoUF = 0.1m, pAliqMonoMun = 0m, vIBSMonoMun = 0m, vIBSMono = 0.1m }
                },
                gCBSMonoAdRem = new gCBSMonoAdRem
                {
                    gMonoPadrao = new gMonoPadraoCBSAdRem { qBCMono = 10m, adRemCBS = 0.5m, vCBSMono = 5m },
                    gpBioDiferenca = new gpBioDiferencaCBS { qBCBioComb = 1m, vCBSDiferenca = 0.5m }
                },
                vTotIBSMonoItem = 0.1m,
                vTotCBSMonoItem = 5m
            };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(mono);

            /** 3) Verificação **/
            StringAssert.Contains(xml, "<gIBSMonoAdValorem><gMonoPadrao><vBCMono>100.00</vBCMono><pAliqMonoUF>0.1000</pAliqMonoUF><vIBSMonoUF>0.10</vIBSMonoUF><pAliqMonoMun>0.0000</pAliqMonoMun><vIBSMonoMun>0.00</vIBSMonoMun><vIBSMono>0.10</vIBSMono></gMonoPadrao></gIBSMonoAdValorem>");
            StringAssert.Contains(xml, "<gCBSMonoAdRem><gMonoPadrao><qBCMono>10.0000</qBCMono><adRemCBS>0.5000</adRemCBS><vCBSMono>5.00</vCBSMono></gMonoPadrao><gpBioDiferenca><qBCBioComb>1.0000</qBCBioComb><vCBSDiferenca>0.50</vCBSDiferenca></gpBioDiferenca></gCBSMonoAdRem>");
            Assert.IsTrue(xml.IndexOf("</gCBSMonoAdRem>", StringComparison.Ordinal) < xml.IndexOf("<vTotIBSMonoItem>", StringComparison.Ordinal));
        }

        [TestMethod]
        public void DadoXmlDeMonofasiaNoLeiauteAnteriorQuandoDesserializarEntaoDevePreencherAsPropriedadesAntigas()
        {
            /** 1) Preparação **/
            const string xml = "<gIBSCBSMono><gMonoPadrao><qBCMono>10.0000</qBCMono><adRemIBS>1.0000</adRemIBS><adRemCBS>2.0000</adRemCBS><vIBSMono>10.00</vIBSMono><vCBSMono>20.00</vCBSMono></gMonoPadrao>"
                               + "<gMonoDif><pDifIBS>1.0000</pDifIBS><vIBSMonoDif>1.00</vIBSMonoDif><pDifCBS>1.0000</pDifCBS><vCBSMonoDif>1.00</vCBSMonoDif></gMonoDif>"
                               + "<vTotIBSMonoItem>10.00</vTotIBSMonoItem><vTotCBSMonoItem>20.00</vTotCBSMonoItem></gIBSCBSMono>";

            /** 2) Execução **/
            var mono = FuncoesXml.XmlStringParaClasse<gIBSCBSMono>(xml);

            /** 3) Verificação **/
            Assert.AreEqual(20m, mono.gMonoPadrao.vCBSMono);
            Assert.IsNotNull(mono.gMonoDif);
            Assert.IsNull(mono.gIBSMonoAdRem);
            Assert.AreEqual(20m, mono.vTotCBSMonoItem);
        }

        #endregion

        #region Totais / pagamento vinculado

        [TestMethod]
        public void DadoTotalComVProdLiqTotQuandoSerializarEntaoDeveSerOPrimeiroElemento()
        {
            /** 1) Preparação **/
            var tot = new total { vProdLiqTot = 99.9m, ICMSTot = new NFe.Classes.Informacoes.Total.ICMSTot() };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(tot);

            /** 3) Verificação **/
            Assert.IsTrue(xml.IndexOf("<vProdLiqTot>99.90</vProdLiqTot>", StringComparison.Ordinal) < xml.IndexOf("<ICMSTot>", StringComparison.Ordinal));
        }

        [TestMethod]
        public void DadoGPgtoVincQuandoSerializarEntaoDeveGerarAtributosNPagEIdTransacao()
        {
            /** 1) Preparação **/
            var vinculo = new gPgtoVinc
            {
                gPgto = new List<gPgto> { new gPgto { nPag = "1", idTransacao = "TX-1", tpMeioPgto = "17", CNPJReceb = "12ABC34501DE35", CNPJBasePSP = "00000000" } }
            };

            /** 2) Execução **/
            var xml = FuncoesXml.ClasseParaXmlString(vinculo);

            /** 3) Verificação **/
            StringAssert.Contains(xml, "<gPgto nPag=\"1\" idTransacao=\"TX-1\"><tpMeioPgto>17</tpMeioPgto><CNPJReceb>12ABC34501DE35</CNPJReceb><CNPJBasePSP>00000000</CNPJBasePSP></gPgto>");
        }

        #endregion

        #region Eventos 110300 / 412140

        [TestMethod]
        public void DadoDetEventoDeVinculacaoPagamentoQuandoValidarNoXsdEntaoNaoDeveHaverErros()
        {
            /** 1) Preparação **/
            var detEvento = new detEvento
            {
                versao = "1.00",
                descEvento = NFeTipoEvento.TeNfeVinculacaoPagamento.Descricao(),
                cOrgaoAutor = Estado.SP,
                tpAutor = TipoAutor.taEmpresaEmitente,
                verAplic = "1.0",
                nProt = "135260000000001",
                gPgto = new gPgto { idTransacao = "TX-0001", tpMeioPgto = "17", CNPJReceb = "11222333000181", CNPJBasePSP = "60701190" }
            };

            /** 2) Execução **/
            var erros = ValidarNoXsd(FuncoesXml.ClasseParaXmlString(detEvento), "e110300_v1.00.xsd");

            /** 3) Verificação **/
            Assert.AreEqual(0, erros.Count, string.Join(Environment.NewLine, erros));
        }

        [TestMethod]
        public void DadoXmlDoEventoTributacaoDoSimplesNacionalQuandoDesserializarEntaoDevePreencherItensETotais()
        {
            /** 1) Preparação **/
            const string xml = "<detEvento versao=\"1.00\" xmlns=\"http://www.portalfiscal.inf.br/nfe\"><descEvento>Tributação do Simples Nacional</descEvento><cOrgaoAutor>35</cOrgaoAutor><tpAutor>5</tpAutor><verAplic>SVRS-1</verAplic>"
                               + "<gTribItemSN nItem=\"1\"><vRBSNitem>100.00</vRBSNitem><tpRBSN>1</tpRBSN><pIBSSN>0.1000</pIBSSN><vIBSSN>0.10</vIBSSN><pCBSSN>0.9000</pCBSSN><vCBSSN>0.90</vCBSSN></gTribItemSN>"
                               + "<gTotalSN><vRBSNtot>100.00</vRBSNtot><vIBSSNtot>0.10</vIBSSNtot><vCBSSNtot>0.90</vCBSSNtot></gTotalSN></detEvento>";

            /** 2) Execução **/
            var detEvento = FuncoesXml.XmlStringParaClasse<detEvento>(xml);
            var erros = ValidarNoXsd(FuncoesXml.ClasseParaXmlString(detEvento), "e412140_v1.00.xsd");

            /** 3) Verificação **/
            Assert.AreEqual(1, detEvento.gTribItemSN.Count);
            Assert.AreEqual(1, detEvento.gTribItemSN[0].nItem);
            Assert.AreEqual("1", detEvento.gTribItemSN[0].tpRBSN);
            Assert.AreEqual(0.90m, detEvento.gTotalSN.vCBSSNtot);
            Assert.AreEqual(0, erros.Count, string.Join(Environment.NewLine, erros));
        }

        [TestMethod]
        public void DadoCodigosDosNovosEventosQuandoConverterParaEnumEntaoDevemSerReconhecidos()
        {
            /** 1) Preparação / 2) Execução **/
            var vinculacao = FuncoesXml.XmlStringParaClasse<EnvelopeTipoEvento>("<EnvelopeTipoEvento><tpEvento>110300</tpEvento></EnvelopeTipoEvento>");
            var tributacaoSn = FuncoesXml.XmlStringParaClasse<EnvelopeTipoEvento>("<EnvelopeTipoEvento><tpEvento>412140</tpEvento></EnvelopeTipoEvento>");

            /** 3) Verificação **/
            Assert.AreEqual(NFeTipoEvento.TeNfeVinculacaoPagamento, vinculacao.tpEvento);
            Assert.AreEqual(NFeTipoEvento.TeNfeTributacaoDoSimplesNacional, tributacaoSn.tpEvento);
        }

        public class EnvelopeTipoEvento
        {
            public NFeTipoEvento tpEvento { get; set; }
        }

        #endregion

        private static List<string> ValidarNoXsd(string xml, string arquivoXsd)
        {
            var erros = new List<string>();
            var schemas = new XmlSchemaSet { XmlResolver = new XmlUrlResolver() };
            schemas.Add(NamespaceNFe, Path.Combine(ObterDiretorioSchemas(), arquivoXsd));
            var settings = new XmlReaderSettings { ValidationType = ValidationType.Schema, Schemas = schemas };
            settings.ValidationEventHandler += (s, e) => erros.Add(e.Severity + ": " + e.Message);
            using (var reader = XmlReader.Create(new StringReader(xml), settings))
            {
                while (reader.Read()) { }
            }
            return erros;
        }

        /// <summary>
        ///     Localiza NFe.AppTeste/Schemas subindo a partir da pasta de saída dos testes.
        /// </summary>
        private static string ObterDiretorioSchemas()
        {
            var diretorio = new DirectoryInfo(AppContext.BaseDirectory);
            while (diretorio != null)
            {
                var candidato = Path.Combine(diretorio.FullName, "NFe.AppTeste", "Schemas");
                if (Directory.Exists(candidato)) return candidato;
                diretorio = diretorio.Parent;
            }
            throw new DirectoryNotFoundException("Pasta NFe.AppTeste/Schemas não encontrada a partir de " + AppContext.BaseDirectory);
        }
    }
}
