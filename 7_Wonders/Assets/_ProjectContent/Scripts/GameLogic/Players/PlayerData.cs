﻿using System;
using System.Collections.Generic;
using UnityEngine;
using WhiteTeam.GameLogic.Cards;
using WhiteTeam.GameLogic.GlobalParameters;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic
{
    [Serializable]
    public class PlayerData : BaseUserData
    {
        [SerializeField] private Role role;
        public Role Role => role;
        public PlayerData LeftPlayerData { get; private set; }
        public PlayerData RightPlayerData { get; private set; }

        [SerializeField] private MoveStateType moveState; // TODO
        public MoveStateType MoveState => moveState;

        [SerializeField] private PlayerResources resources = new PlayerResources();

        public PlayerResources Resources => resources;

        [SerializeField] private List<Card> inHandCards = new List<Card>();
        public List<Card> InHandCards => inHandCards;

        [SerializeField] private List<Card> activeCards = new List<Card>();
        public List<Card> ActiveCards => activeCards;

        [SerializeField] private int ResourceBuyCost = RulesParameters.Instance.ResourceDefaultBuyCost;

        private PlayerData(string id, string name) : base(id, name)
        {
        }

        public PlayerData(string id, string name, Role role) : base(id, name)
        {
            this.role = role;
        }

        public static PlayerData CreateFromUser(UserData userData)
        {
            var player = new PlayerData(userData.Id, userData.Name);
            return player;
        }

        public void MakeAdmin()
        {
            role = Role.ADMIN;
        }

        public void MakeClient()
        {
            role = Role.CLIENT;
        }

        public void SeatBetween(PlayerData leftPlayerData, PlayerData rightPlayerData)
        {
            LeftPlayerData = leftPlayerData;
            RightPlayerData = rightPlayerData;
        }

        public void GiveCards(List<Card> cards)
        {
            inHandCards = cards;
        }

        public void ActivateCard(Card card)
        {
            inHandCards.Remove(card);
            activeCards.Add(card);

            // TODO -- ui event/action
        }

        public void ThrowCard(Card card)
        {
            inHandCards.Remove(card);

            // TODO -- ui event/action
        }

        public enum MoveStateType
        {
            IN_PROGRESS,
            COMPLETED
        }
    }
}