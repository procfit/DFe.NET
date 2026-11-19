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
    ///     Grupo de informações da Tributação Monofásica Ad Rem da CBS (PL_010h)
    ///     <para>Mutuamente exclusivo com gCBSMonoAdValorem.</para>
    /// </summary>
    public class gCBSMonoAdRem
    {
        /// <summary>
        ///     Grupo de informações da Tributação Monofásica Padrão
        /// </summary>
        public gMonoPadraoCBSAdRem gMonoPadrao { get; set; }

        /// <summary>
        ///     Grupo de informações da Tributação Monofásica Sujeita à Retenção
        /// </summary>
        public gMonoRetenCBSAdRem gMonoReten { get; set; }

        /// <summary>
        ///     Grupo de informações da Tributação Monofásica Retida Anteriormente
        /// </summary>
        public gMonoRetCBS gMonoRet { get; set; }

        /// <summary>
        ///     Grupo de informações sobre mistura de EAC com gasolina A em percentual inferior ou superior ao obrigatório
        /// </summary>
        public gpBioDiferencaCBS gpBioDiferenca { get; set; }
    }

    /// <summary>
    ///     gMonoPadrao da CBS na modalidade ad rem (PL_010h)
    /// </summary>
    public class gMonoPadraoCBSAdRem
    {
        private decimal _qBCMono;
        private decimal _adRemCBS;
        private decimal _vCBSMono;

        /// <summary>
        ///     Quantidade tributada na monofasia
        /// </summary>
        public decimal qBCMono
        {
            get => _qBCMono.Arredondar(4);
            set => _qBCMono = value.Arredondar(4);
        }

        /// <summary>
        ///     Alíquota ad rem da CBS
        /// </summary>
        public decimal adRemCBS
        {
            get => _adRemCBS.Arredondar(4);
            set => _adRemCBS = value.Arredondar(4);
        }

        /// <summary>
        ///     Valor da CBS monofásica
        /// </summary>
        public decimal vCBSMono
        {
            get => _vCBSMono.Arredondar(2);
            set => _vCBSMono = value.Arredondar(2);
        }
    }

    /// <summary>
    ///     gMonoReten da CBS na modalidade ad rem (PL_010h)
    /// </summary>
    public class gMonoRetenCBSAdRem
    {
        private decimal _qBCMonoReten;
        private decimal _adRemCBSReten;
        private decimal _vCBSMonoReten;

        /// <summary>
        ///     Quantidade tributada sujeita à retenção na monofasia
        /// </summary>
        public decimal qBCMonoReten
        {
            get => _qBCMonoReten.Arredondar(4);
            set => _qBCMonoReten = value.Arredondar(4);
        }

        /// <summary>
        ///     Alíquota ad rem da CBS sujeita à retenção
        /// </summary>
        public decimal adRemCBSReten
        {
            get => _adRemCBSReten.Arredondar(4);
            set => _adRemCBSReten = value.Arredondar(4);
        }

        /// <summary>
        ///     Valor da CBS monofásica sujeita à retenção
        /// </summary>
        public decimal vCBSMonoReten
        {
            get => _vCBSMonoReten.Arredondar(2);
            set => _vCBSMonoReten = value.Arredondar(2);
        }
    }
}
