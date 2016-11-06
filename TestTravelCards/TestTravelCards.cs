using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelCards;

namespace TestTravelCards
{
    [TestClass]
    public class TestTravelCards
    {
        [TestMethod]
        public void TestInvalidArgs()
        {
            TravelCard card1;
            card1.CityFrom = "Мельбурн";
            card1.CityTo = "Кельн";
            TravelCard card2;
            card2.CityFrom = "Москва";
            card2.CityTo = "Париж";
            TravelCard card3;
            card3.CityFrom = "Кельн";
            card3.CityTo = "Москва";
            TravelCard card4;
            card4.CityFrom = "Рига";
            card4.CityTo = "Москва";
            TravelCard[] cards = { card1, card2, card3, card4 };
            TravelHelper.Sort(cards);
        }

        [TestMethod]
        public void TestSampleArgs()
        {
            TravelCard card1;
            card1.CityFrom = "Мельбурн";
            card1.CityTo = "Кельн";
            TravelCard card2;
            card2.CityFrom = "Москва";
            card2.CityTo = "Париж";
            TravelCard card3;
            card3.CityFrom = "Кельн";
            card3.CityTo = "Москва";
            TravelCard[] cards = { card1, card2, card3 };
            TravelHelper.Sort(cards);
        }
    }
}
