/********************************************************************************/
/* Projeto: Biblioteca ZeusNFe                                                  */
/* Biblioteca C# para emissão de Nota Fiscal Eletrônica - NFe e Nota Fiscal de  */
/* Consumidor Eletrônica - NFC-e (http://www.nfe.fazenda.gov.br)                */
/*                                                                              */
/* Direitos Autorais Reservados (c) 2014 Adenilton Batista da Silva             */
/*                                       Zeusdev Tecnologia LTDA ME             */
/*                                                                              */
/*  Você pode obter a última versão desse arquivo no GitHub                     */
/* localizado em https://github.com/adeniltonbs/Zeus.Net.NFe.NFCe               */
/*                                                                              */
/*                                                                              */
/*  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la */
/* sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  */
/* Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) */
/* qualquer versão posterior.                                                   */
/*                                                                              */
/*  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   */
/* NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      */
/* ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor*/
/* do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              */
/*                                                                              */
/*  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto*/
/* com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  */
/* no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          */
/* Você também pode obter uma copia da licença em:                              */
/* http://www.opensource.org/licenses/lgpl-license.php                          */
/*                                                                              */
/* Zeusdev Tecnologia LTDA ME - adenilton@zeusautomacao.com.br                  */
/* http://www.zeusautomacao.com.br/                                             */
/* Rua Comendador Francisco josé da Cunha, 111 - Itabaiana - SE - 49500-000     */
/********************************************************************************/

using System.Xml.Serialization;

namespace NFe.Classes.Servicos.Evento.Informacoes.TributacaoSimplesNacional
{
    /// <summary>
    ///     Detalhamento dos tributos do Simples Nacional por item (Evento 412140 - Tributação do Simples Nacional, autor Fisco)
    /// </summary>
    public class gTribItemSN
    {
        private decimal _vRBSNitem;
        private decimal? _pIBSSN;
        private decimal? _vIBSSN;
        private decimal? _pCBSSN;
        private decimal? _vCBSSN;
        private decimal? _vIBSPendSusp;
        private decimal? _vCBSPendSusp;

        /// <summary>
        ///     Número do item (1 a 990)
        /// </summary>
        [XmlAttribute]
        public int nItem { get; set; }

        /// <summary>
        ///     Valor da receita bruta do Simples Nacional atribuída ao item
        /// </summary>
        public decimal vRBSNitem
        {
            get => _vRBSNitem.Arredondar(2);
            set => _vRBSNitem = value.Arredondar(2);
        }

        /// <summary>
        ///     Tipo de Receita Bruta do Simples Nacional referente ao cClassTrib do item ("0" a "5" ou "9").
        ///     <para>
        ///         Mantido como string: o XSD (PL_010h_v1.03) documenta apenas "9 - Fornecimento incompatível com SN".
        ///         Consultar a Nota Técnica vigente para os demais códigos.
        ///     </para>
        /// </summary>
        public string tpRBSN { get; set; }

        /// <summary>
        ///     Alíquota aplicável de cálculo do IBS referente ao item
        /// </summary>
        public decimal? pIBSSN
        {
            get => _pIBSSN.Arredondar(4);
            set => _pIBSSN = value.Arredondar(4);
        }

        /// <summary>
        ///     Valor do IBS devido pelo Simples Nacional
        /// </summary>
        public decimal? vIBSSN
        {
            get => _vIBSSN.Arredondar(2);
            set => _vIBSSN = value.Arredondar(2);
        }

        /// <summary>
        ///     Alíquota aplicável de cálculo da CBS referente ao item
        /// </summary>
        public decimal? pCBSSN
        {
            get => _pCBSSN.Arredondar(4);
            set => _pCBSSN = value.Arredondar(4);
        }

        /// <summary>
        ///     Valor da CBS devido pelo Simples Nacional
        /// </summary>
        public decimal? vCBSSN
        {
            get => _vCBSSN.Arredondar(2);
            set => _vCBSSN = value.Arredondar(2);
        }

        /// <summary>
        ///     Valor do IBS pendente ou suspenso referente ao item
        /// </summary>
        public decimal? vIBSPendSusp
        {
            get => _vIBSPendSusp.Arredondar(2);
            set => _vIBSPendSusp = value.Arredondar(2);
        }

        /// <summary>
        ///     Valor da CBS pendente ou suspenso referente ao item
        /// </summary>
        public decimal? vCBSPendSusp
        {
            get => _vCBSPendSusp.Arredondar(2);
            set => _vCBSPendSusp = value.Arredondar(2);
        }

        public bool ShouldSerializepIBSSN() => pIBSSN.HasValue;
        public bool ShouldSerializevIBSSN() => vIBSSN.HasValue;
        public bool ShouldSerializepCBSSN() => pCBSSN.HasValue;
        public bool ShouldSerializevCBSSN() => vCBSSN.HasValue;
        public bool ShouldSerializevIBSPendSusp() => vIBSPendSusp.HasValue;
        public bool ShouldSerializevCBSPendSusp() => vCBSPendSusp.HasValue;
    }
}
