using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Compartilhado.InformacoesIbsCbs.InformacoesIbs;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Compartilhado.Tipos;

namespace NFe.Classes.Testes;

[TestClass]
public class GCredPresIBSZFMTesteUnitario
{
    [TestMethod(displayName: "Dado gCredPresIBSZFM com competApur, quando serializar e desserializar, então competApur deve sair como AAAA-MM antes de tpCredPresIBSZFM e ser preservado.")]
    public void DadoGCredPresIBSZFMComCompetApurQuandoSerializarEDesserializarEntaoDeveSerPreservadoNaOrdemDoXsd()
    {
        var serializer = new XmlSerializer(typeof(gCredPresIBSZFM));
        var origem = new gCredPresIBSZFM
        {
            competApur = new DateTime(2026, 11, 1),
            tpCredPresIBSZFM = ClassificacaoCreditoPresumidoIbsZfmTipos.tpCredPresIbsZfm1,
            vCredPresIBSZFM = 12.34m,
        };

        string xml;
        using (var writer = new StringWriter())
        {
            serializer.Serialize(writer, origem);
            xml = writer.ToString();
        }

        StringAssert.Contains(xml, "<competApur>2026-11</competApur>");
        Assert.IsTrue(xml.IndexOf("<competApur>", StringComparison.Ordinal) < xml.IndexOf("<tpCredPresIBSZFM>", StringComparison.Ordinal),
            "TCredPresIBSZFM exige competApur antes de tpCredPresIBSZFM");

        using var reader = new StringReader(xml);
        var lido = (gCredPresIBSZFM)serializer.Deserialize(reader)!;
        Assert.AreEqual(new DateTime(2026, 11, 1), lido.competApur);
        Assert.AreEqual(12.34m, lido.vCredPresIBSZFM);
    }
}
