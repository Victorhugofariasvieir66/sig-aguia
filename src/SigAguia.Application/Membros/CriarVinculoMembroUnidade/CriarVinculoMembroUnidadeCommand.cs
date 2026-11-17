namespace SigAguia.Application.Membros.CriarVinculoMembroUnidade
{
    public class CriarVinculoMembroUnidadeCommand
    {
        public Guid UnidadeId { get; set; }

        public string TipoVinculo { get; set; } = "Principal";

        public DateOnly DataInicio { get; set; }
    }
}