﻿using System;
using System.Collections.Generic;
using KataYatzy.Contracts;
using KataYatzy.Shared.Combinations;

namespace KataYatzy.Shared
{
    //toDo write unit tests
    //toDo introduce interface
    public class GameEngine
    {
        private ScoreBoard _scoreBoard;
        private TossFactory _tossFactory;

        public GameEngine()
        {
            InitializeScoreBoard();
            InitializeTossFactory();
        }

        public IScoreBoard ScoreBoard => _scoreBoard;

        public event EventHandler<NewTurnEventArgs> NewTurnStarted; 
    
        public void Start()
        {
            OnNewTurnStarted(_scoreBoard.Players[0], _tossFactory.CreateToss());
        }

        private void InitializeScoreBoard()
        {
            _scoreBoard = new ScoreBoard();

            AddPlayer("Loana");
            AddPlayer("Thomas");

            AddCombination(new OnesCombination());
            AddCombination(new ThreeOfAKindCombination());
            AddCombination(new FullHouseCombination());
            AddCombination(new SmallStraightCombination());
            AddCombination(new ChanceCombination());
        }

        private void InitializeTossFactory()
        {
            _tossFactory = new TossFactory(5, 1, 6);
        }

        private void AddPlayer(string playerName)
        {
            _scoreBoard.AddPlayer(new Player(playerName));
        }

        private void AddCombination(ICombination combination)
        {
            _scoreBoard.AddCombination(combination);
        }

        protected virtual void OnNewTurnStarted(IPlayer player, IToss toss)
        {
            var eventArgs = new NewTurnEventArgs(player, toss);
            NewTurnStarted?.Invoke(this, eventArgs);
        }
    }

    public sealed class NewTurnEventArgs : EventArgs
    {
        public NewTurnEventArgs(IPlayer player, IToss toss)
        {
            Player = player;
            Toss = toss;
        }

        public IPlayer Player { get; private set; }

        public IToss Toss { get; private set; }
    }
}