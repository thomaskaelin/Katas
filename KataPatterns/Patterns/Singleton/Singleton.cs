﻿namespace Patterns.Singleton
{
    public class Singleton
    {
        public static Singleton Instance => _instance ?? (_instance = new Singleton());

        private static Singleton _instance;

        private Singleton()
        {
        }

        public void DoSomething()
        {
        }
    }
}