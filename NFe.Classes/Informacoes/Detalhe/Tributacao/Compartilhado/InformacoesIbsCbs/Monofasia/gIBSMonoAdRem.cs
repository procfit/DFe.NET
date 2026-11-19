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

namespace NFe.Classes.Informacoes.Detalhe.Tributacao.Compartilhado.InformacoesIbsCbs.Monofasia
{
    /// <summary>
    ///     Grupo de informações da Tributação Monofásica Ad Rem do IBS (PL_010h)
    ///     <para>Mutuamente exclusivo com gIBSMonoAdValorem.</para>
    /// </summary>
    public class gIBSMonoAdRem
    {
        /// <summary>
        ///     Grupo de informações da Tributação Monofásica Padrão
        /// </summary>
        public gMonoPadraoIBSAdRem gMonoPadrao { get; set; }

        /// <summary>
        ///     Grupo de informações da Tributação Monofásica Sujeita à Retenção
        /// </summary>
        public gMonoRetenIBSAdRem gMonoReten { get; set; }

        /// <summary>
        ///     Grupo de informações da Tributação Monofásica Retida Anteriormente
        /// </summary>
        public gMonoRetIBS gMonoRet { get; set; }

        /// <summary>
        ///     Grupo de informações sobre mistura de EAC com gasolina A em percentual inferior ou superior ao obrigatório
        /// </summary>
        public gpBioDiferencaIBS gpBioDiferenca { get; set; }
    }

    /// <summary>
    ///     gMonoPadrao do IBS na modalidade ad rem (PL_010h)
    /// </summary>
    public class gMonoPadraoIBSAdRem
    {
        private decimal _qBCMono;
        private decimal _adRemIBS;
        private decimal _vIBSMono;

        /// <summary>
        ///     Quantidade tributada na monofasia
        /// </summary>
        public decimal qBCMono
        {
            get => _qBCMono.Arredondar(4);
            set => _qBCMono = value.Arredondar(4);
        }

        /// <summary>
        ///     Alíquota ad rem do IBS
        /// </summary>
        public decimal adRemIBS
        {
            get => _adRemIBS.Arredondar(4);
            set => _adRemIBS = value.Arredondar(4);
        }

        /// <summary>
        ///     Valor do IBS monofásico
        /// </summary>
        public decimal vIBSMono
        {
            get => _vIBSMono.Arredondar(2);
            set => _vIBSMono = value.Arredondar(2);
        }
    }

    /// <summary>
    ///     gMonoReten do IBS na modalidade ad rem (PL_010h)
    /// </summary>
    public class gMonoRetenIBSAdRem
    {
        private decimal _qBCMonoReten;
        private decimal _adRemIBSReten;
        private decimal _vIBSMonoReten;

        /// <summary>
        ///     Quantidade tributada sujeita à retenção na monofasia
        /// </summary>
        public decimal qBCMonoReten
        {
            get => _qBCMonoReten.Arredondar(4);
            set => _qBCMonoReten = value.Arredondar(4);
        }

        /// <summary>
        ///     Alíquota ad rem do IBS sujeito à retenção
        /// </summary>
        public decimal adRemIBSReten
        {
            get => _adRemIBSReten.Arredondar(4);
            set => _adRemIBSReten = value.Arredondar(4);
        }

        /// <summary>
        ///     Valor do IBS monofásico sujeito à retenção
        /// </summary>
        public decimal vIBSMonoReten
        {
            get => _vIBSMonoReten.Arredondar(2);
            set => _vIBSMonoReten = value.Arredondar(2);
        }
    }
}
