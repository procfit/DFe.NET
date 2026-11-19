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

namespace NFe.Classes.Servicos.Evento.Informacoes.TributacaoSimplesNacional
{
    /// <summary>
    ///     Totais do Simples Nacional da NF-e / NFC-e (Evento 412140 - Tributação do Simples Nacional, autor Fisco)
    /// </summary>
    public class gTotalSN
    {
        private decimal _vRBSNtot;
        private decimal? _vIBSSNtot;
        private decimal? _vIBSSNtotPendSusp;
        private decimal? _vCBSSNtot;
        private decimal? _vCBSSNtotPendSusp;

        /// <summary>
        ///     Valor total da receita bruta do Simples Nacional (somatório dos valores atribuídos aos itens do DF-e)
        /// </summary>
        public decimal vRBSNtot
        {
            get => _vRBSNtot.Arredondar(2);
            set => _vRBSNtot = value.Arredondar(2);
        }

        /// <summary>
        ///     Valor total do IBS devido pelo Simples Nacional apurado no documento
        /// </summary>
        public decimal? vIBSSNtot
        {
            get => _vIBSSNtot.Arredondar(2);
            set => _vIBSSNtot = value.Arredondar(2);
        }

        /// <summary>
        ///     Valor total do IBS devido pelo Simples Nacional com apropriação pendente ou exigibilidade suspensa
        /// </summary>
        public decimal? vIBSSNtotPendSusp
        {
            get => _vIBSSNtotPendSusp.Arredondar(2);
            set => _vIBSSNtotPendSusp = value.Arredondar(2);
        }

        /// <summary>
        ///     Valor total da CBS devido pelo Simples Nacional apurado no documento
        /// </summary>
        public decimal? vCBSSNtot
        {
            get => _vCBSSNtot.Arredondar(2);
            set => _vCBSSNtot = value.Arredondar(2);
        }

        /// <summary>
        ///     Valor total da CBS devido pelo Simples Nacional com apropriação pendente ou exigibilidade suspensa
        /// </summary>
        public decimal? vCBSSNtotPendSusp
        {
            get => _vCBSSNtotPendSusp.Arredondar(2);
            set => _vCBSSNtotPendSusp = value.Arredondar(2);
        }

        public bool ShouldSerializevIBSSNtot() => vIBSSNtot.HasValue;
        public bool ShouldSerializevIBSSNtotPendSusp() => vIBSSNtotPendSusp.HasValue;
        public bool ShouldSerializevCBSSNtot() => vCBSSNtot.HasValue;
        public bool ShouldSerializevCBSSNtotPendSusp() => vCBSSNtotPendSusp.HasValue;
    }
}
