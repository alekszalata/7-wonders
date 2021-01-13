﻿using UnityEngine;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.GameLogic.Resources;

public class CardsCreationTest : MonoBehaviour
{
    private void Start()
    {
        CreateCommonCard();
        //CreateWonderCard();
    }

    private void CreateCommonCard()
    {
        // Data from server
        var cardData = new ScientificCard(
            "23",
            "Science",
            CommonCardData.CardType.COMMERCIAL_TRADE,
            1,
            new[]
            {
                new Resource.CurrencyItem {Currency = Resource.CurrencyProducts.ORE, Amount = 1}
            },
            "",
            new ScienceEffect(new Resource.ScienceItem {Currency = Resource.Science.RUNE_2, Amount = 1}));

        //logic card creation
        var card = CardCreator.Create(cardData);

        // card visualisation
        CardVisualizationController.Instance.Visualize(card);


        // var img = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Effects/Number six");
        // Debug.Log(img);
    }

    private void CreateWonderCard()
    {
        // Data from server
        var wonderCardData = WonderCardsBuilder.CreateColloss("1234");
        //logic card creation
        var wonderCard = CardCreator.Create(wonderCardData);

        // card visualisation
        CardVisualizationController.Instance.Visualize(wonderCard);


        // var img = UnityEngine.Resources.Load<Sprite> ("Assets/_ProjectContent/UI/Resources/Effects/Number six");
        // Debug.Log(img);
    }
}