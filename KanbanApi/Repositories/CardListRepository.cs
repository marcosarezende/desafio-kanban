using KanbanApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KanbanApi.Repositories
{
    public class CardListRepository : ICardRepository
    {
        private static List<Card> Cards;

        public CardListRepository()
        {
            if(Cards == null)
                Cards = new List<Card>();
        }

        public List<Card> GetCards()
        {
            return Cards;
        }

        public Card GetCard(Guid id)
        {
            return Cards.FirstOrDefault(c => c.Id == id);
        }

        public Card AddCard(Card card)
        {
            if(card.Id.Equals(Guid.Empty))
                card.generateId();
            Cards.Add(card);
            return card;
        }

        public Card UpdateCard(Guid id, Card card)
        {
            int cardIndex = Cards.FindIndex(c => c.Id.Equals(id));
            if (cardIndex == -1)
                throw new KeyNotFoundException("O cartão informado não foi encontrado") ;
            
            Cards[cardIndex]= card;

            return Cards[cardIndex];
        }

        public List<Card> DeleteCard(Guid id)
        {
            int cardIndex = Cards.FindIndex(c => c.Id == id);
            if (cardIndex == -1)
                throw new KeyNotFoundException("O cartão informado não foi encontrado");
            
            Cards.RemoveAt(cardIndex);
            return Cards;
        }

        private static void PopulateRepository()
        {
            for (int i=0; i < 4; i++)
            {
                var card = new Card("Card " +i, "Cartão gerado automaticamente na inicialização do sistema ", "ToDo");
                card.generateId();
                Cards.Add(card);
            }
        }
    }
}
