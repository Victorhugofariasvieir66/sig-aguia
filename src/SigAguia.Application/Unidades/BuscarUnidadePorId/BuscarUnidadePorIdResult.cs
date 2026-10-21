namespace SigAguia.Application.Unidades.BuscarUnidadePorId
{
    public class BuscarUnidadePorIdResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool EhMatriz { get; set; }
        public bool Ativa { get; set; }
    }
}