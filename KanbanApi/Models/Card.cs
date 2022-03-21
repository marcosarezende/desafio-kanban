using System;
using System.ComponentModel.DataAnnotations;

namespace KanbanApi.Repositories
{
    public class Card
    {
        public Guid Id{ get; private set; }
        
        [Required]
        public string Titulo { get; private set; }
        [Required]
        public string Conteudo { get; private set; }
        [Required]
        public string Lista { get; private set; }


        public Card(string titulo, string conteudo, string lista, Guid id = new Guid())
        {
            Id = id;
            Lista = lista;
            Titulo = titulo;
            Conteudo = conteudo;
        }

        public void generateId()
        {
            Id = Guid.NewGuid();
        }

    }
}
