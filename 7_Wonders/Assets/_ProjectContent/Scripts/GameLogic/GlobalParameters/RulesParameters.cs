﻿using System.Collections.Generic;
using MyBox;
using UnityEngine;

namespace WhiteTeam.GameLogic.GlobalParameters
{
    public class RulesParameters : Singleton<RulesParameters>
    {
        public PlayerDirection FirstSwipeDirection = PlayerDirection.LEFT;
        [PositiveValueOnly] public int CardExchangeAmount = 3;
        [PositiveValueOnly] public int ResourceDefaultBuyCost = 2;

        [Header("Score")] public int MoneyToVictoryPoint = 3;
        public int DifferentScienceGroupModifier = 7;
    }
}