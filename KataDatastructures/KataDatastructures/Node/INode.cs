﻿namespace KataDatastructures.Node
{
    public interface INode<TItem> 
    {
        INode<TItem> Next { get; set; }

        INode<TItem> Previous { get; set; }

        INode<TItem> Head { get; set; }

        INode<TItem> Tail { get; set; }

        TItem Element { get; set; }

        bool HasNext();

        bool HasPrevious();

        INode<TItem> GetFirst();

        INode<TItem> GetLast();

        void AddBefore(INode<TItem> node);

        void AddAfter(INode<TItem> node);

        void Remove();

        int Size();
    }
}