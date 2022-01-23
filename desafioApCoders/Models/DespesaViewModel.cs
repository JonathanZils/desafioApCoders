using Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace desafioApCoders.Models
{
    public class DespesaViewModel
    {
        public SelectList Unidades { get; set; }
        public AdicionarDespesa AdicionarDespesa { get; set; } = new AdicionarDespesa();
    }
}
