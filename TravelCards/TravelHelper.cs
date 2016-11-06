using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelCards
{
    public static class TravelHelper
    {
        //сложность 3N + N^2 / 2 -> N^2 / 2
        public static TravelCard[] Sort(TravelCard[] cards)
        {
            //проверка на вилидность входных данных
            if (cards == null) return null;
            if (cards.Length == 0) return cards;

            var citiesFrom = new List<string>();
            var citiesTo = new List<string>();

            foreach (var card in cards)
            {
                //если есть повторное вхождение, значит на лицо зацикленность/разветвление, что не допускается в условии
                if (citiesFrom.Contains(card.CityFrom) || citiesTo.Contains(card.CityTo))
                    throw new Exception("Invalid input data [D32E68BC02EC]");

                citiesFrom.Add(card.CityFrom);
                citiesTo.Add(card.CityTo);
            }

            var startCities = citiesFrom.Where(x => !citiesTo.Contains(x)).ToList();
            var endCities = citiesTo.Where(x => !citiesFrom.Contains(x)).ToList();

            //если количество пунктов отправления, которые не фигурируют в качестве пунктов назначения в других картах, больше 1 или отсутствуют
            //или же количество пунктов назначения, которые не фигурируют в качестве пунктов отправления в других картах, больше 1 или отсутствуют
            if (startCities.Count != 1 || endCities.Count != 1)
                throw new Exception("Invalid input data [532FBB0A1DE2]");

            //изначальный пункт отправления и конечный пункт назначения
            var startCity = startCities[0];
            var endCity = endCities[0];

            var k = 0;

            while (startCity != endCity)
            {
                for (var i = k; i < cards.Length; i++)
                {
                    if (cards[i].CityFrom == startCity)
                    {
                        startCity = cards[i].CityTo;
                        var card = cards[i];
                        cards[i] = cards[k];
                        cards[k] = card;
                        k++;
                        break;
                    }
                }
            }

            return cards;
        }
    }

    public struct TravelCard
    {
        public string CityFrom;
        public string CityTo;
    }
}
