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

namespace NFe.Classes.Informacoes.Detalhe.Tributacao.Compartilhado.InformacoesIbsCbs.InformacoesCbs
{
    /// <summary>
    ///     Grupo de informações da CBS em operações em áreas incentivadas (ALC/ZFM) com alíquota zero (PL_010h)
    /// </summary>
    public class gALCZFMCBS
    {
        private decimal _pAliqEfetRegCBS;
        private decimal _vTribRegCBS;

        /// <summary>
        ///     Tipo de aplicação da alíquota zero da CBS ("1" ou "2").
        ///     <para>
        ///         Mantido como string: o XSD (PL_010h_v1.03) não documenta o significado de cada código.
        ///         Consultar a Nota Técnica vigente.
        ///     </para>
        /// </summary>
        [XmlElement(Order = 1)]
        public string tpALCZFMCBS { get; set; }

        /// <summary>
        ///     Número do processo na Suframa para o item comercializado (8 a 12 caracteres)
        /// </summary>
        [XmlElement(Order = 2)]
        public string nProcSuframa { get; set; }

        /// <summary>
        ///     Alíquota efetiva de referência da CBS aplicável à operação fora de áreas ou regimes incentivados
        /// </summary>
        [XmlElement(Order = 3)]
        public decimal pAliqEfetRegCBS
        {
            get => _pAliqEfetRegCBS.Arredondar(4);
            set => _pAliqEfetRegCBS = value.Arredondar(4);
        }

        /// <summary>
        ///     Valor da CBS calculado para a operação fora de áreas ou regimes incentivados
        /// </summary>
        [XmlElement(Order = 4)]
        public decimal vTribRegCBS
        {
            get => _vTribRegCBS.Arredondar(2);
            set => _vTribRegCBS = value.Arredondar(2);
        }

        public bool ShouldSerializenProcSuframa() => !string.IsNullOrWhiteSpace(nProcSuframa);
    }
}
