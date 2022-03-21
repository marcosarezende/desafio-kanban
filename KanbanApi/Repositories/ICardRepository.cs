using System;
using System.Collections.Generic;

namespace KanbanApi.Repositories
{
    public interface ICardRepository
    {
        public List<Card> GetCards();

        public Card GetCard(Guid id);

        public Card AddCard(Card card);

        public Card UpdateCard(Guid id, Card card);

        public List<Card> DeleteCard(Guid id);
    }
}
