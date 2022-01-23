using Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace desafioApCoders.Models
{
    public class DespesasPorUnidadeViewModel
    {
        public SelectList Unidades { get; set; }
        public int UnidadeId { get; set; }
        public IEnumerable<Despesa> Despesas { get; set; } = Enumerable.Empty<Despesa>();
    }
}
