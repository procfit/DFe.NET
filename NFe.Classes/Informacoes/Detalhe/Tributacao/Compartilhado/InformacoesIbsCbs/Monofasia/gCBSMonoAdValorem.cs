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
    ///     Grupo de informações da Tributação Monofásica Ad Valorem da CBS (PL_010h)
    ///     <para>Mutuamente exclusivo com gCBSMonoAdRem.</para>
    /// </summary>
    public class gCBSMonoAdValorem
    {
        /// <summary>
        ///     Grupo de informações da Tributação Monofásica Padrão
        /// </summary>
        public gMonoPadraoCBSAdValorem gMonoPadrao { get; set; }

        /// <summary>
        ///     Grupo de informações da Tributação Monofásica Sujeita à Retenção
        /// </summary>
        public gMonoRetenCBSAdValorem gMonoReten { get; set; }

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
    ///     gMonoPadrao da CBS na modalidade ad valorem (PL_010h)
    /// </summary>
    public class gMonoPadraoCBSAdValorem
    {
        private decimal _vBCMono;
        private decimal _pAliqMonoCBS;
        private decimal _vCBSMono;

        /// <summary>
        ///     Valor tributado na monofasia
        /// </summary>
        public decimal vBCMono
        {
            get => _vBCMono.Arredondar(2);
            set => _vBCMono = value.Arredondar(2);
        }

        /// <summary>
        ///     Alíquota ad valorem da CBS
        /// </summary>
        public decimal pAliqMonoCBS
        {
            get => _pAliqMonoCBS.Arredondar(4);
            set => _pAliqMonoCBS = value.Arredondar(4);
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
    ///     gMonoReten da CBS na modalidade ad valorem (PL_010h)
    /// </summary>
    public class gMonoRetenCBSAdValorem
    {
        private decimal _vBCMonoReten;
        private decimal _pAliqMonoReten;
        private decimal _vCBSMonoReten;

        /// <summary>
        ///     Valor tributado sujeito à retenção na monofasia
        /// </summary>
        public decimal vBCMonoReten
        {
            get => _vBCMonoReten.Arredondar(2);
            set => _vBCMonoReten = value.Arredondar(2);
        }

        /// <summary>
        ///     Alíquota ad valorem da CBS sujeita à retenção
        /// </summary>
        public decimal pAliqMonoReten
        {
            get => _pAliqMonoReten.Arredondar(4);
            set => _pAliqMonoReten = value.Arredondar(4);
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
