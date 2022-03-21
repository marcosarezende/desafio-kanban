using KanbanApi.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApi.Repositories
{
    public class CardEntityRepository : ICardRepository
    {
        private readonly CardDbContext _cardDbContext;

        public CardEntityRepository(CardDbContext cardDbContext)
        {
            _cardDbContext = cardDbContext;
        }


        public List<Card> GetCards() => _cardDbContext.Cards.AsNoTracking().ToList();

        public Card GetCard(Guid id) => _cardDbContext.Cards.AsNoTracking().FirstOrDefault(c => c.Id == id);
        

        public Card AddCard(Card card)
        {
            _cardDbContext.Cards.Add(card);
            _cardDbContext.SaveChanges();
            return card;
        }

        public Card UpdateCard(Guid id, Card card)
        {
            var cardSaved = _cardDbContext.Cards.AsNoTracking().SingleOrDefault(c => c.Id.Equals(id));
            if (cardSaved == null)
                throw new KeyNotFoundException("O cartão informado não foi encontrado");

            _cardDbContext.Cards.Update(card);
            _cardDbContext.SaveChanges();

            return card;
        }

        public List<Card> DeleteCard(Guid id)
        {
            var card = _cardDbContext.Cards.SingleOrDefault(c => c.Id == id);
            if (card == null)
                throw new KeyNotFoundException("O cartão informado não foi encontrado");

            _cardDbContext.Cards.Remove(card);
            _cardDbContext.SaveChanges();
            return _cardDbContext.Cards.AsNoTracking().ToList();
        }

        private void PopulateRepository()
        {
            for (int i = 0; i < 4; i++)
            {
                var card = new Card("Card " + i, "Cartão gerado automaticamente na inicialização do sistema ", "ToDo");
                _cardDbContext.Cards.Add(card);
                _cardDbContext.SaveChanges();
            }
        }
    }
}
