﻿using System;
using System.Collections;
using System.Collections.Generic;
namespace Common.Core
{
    public class Deque<T> : IEnumerable<T>
    {
        public T this[int i]
        {
            get => Buffer[(FirstIndex + i) % Capacity];
            set
            {
                if (i < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                Buffer[(FirstIndex + i) % Capacity] = value;
            }
        }
        private T[] Buffer;
        private int Capacity;
        private int FirstIndex;
        private int LastIndex => (FirstIndex + Length) % Capacity;
        public int Length;
        public Deque(int capacity = 16)
        {
            Capacity = capacity;
            Buffer = new T[Capacity];
            FirstIndex = 0;
        }
        public void PushBack(T data)
        {
            if (Length == Capacity)
            {
                Resize();
            }

            Buffer[LastIndex] = data;
            Length++;
        }
        public void PushFront(T data)
        {
            if (Length == Capacity)
            {
                Resize();
            }

            int index = FirstIndex - 1;
            if (index < 0)
            {
                index = Capacity - 1;
            }

            Buffer[index] = data;
            Length++;
            FirstIndex = index;
        }
        public T PopBack()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("データが空です。");
            }

            T data = this[Length - 1];
            Length--;
            return data;
        }
        public T PopFront()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("データが空です。");
            }

            T data = this[0];
            FirstIndex++;
            FirstIndex %= Capacity;
            Length--;
            return data;
        }
        private void Resize()
        {
            T[] newArray = new T[Capacity * 2];
            for (int i = 0; i < Length; i++)
            {
                newArray[i] = this[i];
            }
            FirstIndex = 0;
            Capacity *= 2;
            Buffer = newArray;
        }
        public int Count => Length;
        public bool TryPop(out T result)
        {
            if (Count == 0)
            {
                result = default;
                return false;
            }
            else
            {
                result = PopBack();
                return true;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return this[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return this[i];
            }
        }
    }
}
