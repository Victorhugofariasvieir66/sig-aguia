using System;
using System.Collections.Generic;
using System.Text;

namespace SigAguia.Domain.Pessoas
{
    public class Pessoa
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string NomeCompleto { get; set; } = string.Empty;

        public DateOnly? DataNascimento { get; set; }

        public string? Telefone { get; set; }

        public string? Email { get; set; }

        public string? EstadoCivil { get; set; }

        public Guid? FotoArquivoId { get; set; }

        public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
    }
}
