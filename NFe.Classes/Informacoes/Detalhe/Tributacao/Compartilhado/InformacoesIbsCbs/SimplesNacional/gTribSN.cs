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

namespace NFe.Classes.Informacoes.Detalhe.Tributacao.Compartilhado.InformacoesIbsCbs.SimplesNacional
{
    /// <summary>
    ///     Grupo de informações da composição do valor do IBS e da CBS para o Simples Nacional (PL_010h)
    /// </summary>
    public class gTribSN
    {
        /// <summary>
        ///     Grupo de informações da composição do valor do IBS para o Simples Nacional (opcional)
        /// </summary>
        [XmlElement(Order = 1)]
        public gIBSSN gIBSSN { get; set; }

        /// <summary>
        ///     Grupo de informações da composição do valor da CBS para o Simples Nacional
        /// </summary>
        [XmlElement(Order = 2)]
        public gCBSSN gCBSSN { get; set; }
    }

    /// <summary>
    ///     Grupo de informações da composição do valor do IBS para o Simples Nacional (PL_010h)
    /// </summary>
    public class gIBSSN
    {
        private decimal _pIBSSN;
        private decimal _vIBSSN;

        /// <summary>
        ///     Alíquota efetiva do IBS para os optantes do Simples Nacional
        /// </summary>
        [XmlElement(Order = 1)]
        public decimal pIBSSN
        {
            get => _pIBSSN.Arredondar(4);
            set => _pIBSSN = value.Arredondar(4);
        }

        /// <summary>
        ///     Valor do IBS para os optantes do Simples Nacional
        /// </summary>
        [XmlElement(Order = 2)]
        public decimal vIBSSN
        {
            get => _vIBSSN.Arredondar(2);
            set => _vIBSSN = value.Arredondar(2);
        }
    }

    /// <summary>
    ///     Grupo de informações da composição do valor da CBS para o Simples Nacional (PL_010h)
    /// </summary>
    public class gCBSSN
    {
        private decimal _pCBSSN;
        private decimal _vCBSSN;

        /// <summary>
        ///     Alíquota efetiva da CBS para os optantes do Simples Nacional
        /// </summary>
        [XmlElement(Order = 1)]
        public decimal pCBSSN
        {
            get => _pCBSSN.Arredondar(4);
            set => _pCBSSN = value.Arredondar(4);
        }

        /// <summary>
        ///     Valor da CBS para os optantes do Simples Nacional
        /// </summary>
        [XmlElement(Order = 2)]
        public decimal vCBSSN
        {
            get => _vCBSSN.Arredondar(2);
            set => _vCBSSN = value.Arredondar(2);
        }
    }
}
