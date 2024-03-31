using System;

class OneDimetionalArray<T>
    where T : IComparable<T>
{
    private T[] _myArr;
    private int _capacity;
    private int _index = 0;
    private T _emptyValue = default(T);
    private T[] _emptyArray = new T[0];

    public OneDimetionalArray(int capacity = 7)
    {
        _myArr = new T[capacity];
        _capacity = capacity;
    }

    public void Print()
    {
        Console.WriteLine("Your array: ");
        for (var i = 0; i < _index; i++)
        {
            Console.Write(_myArr[i] + " ");
        }
        Console.WriteLine();
    }

    public void Add(T value)
    {
        if (_index >= _myArr.Length)
        {
            ReSize();
        }
        _myArr[_index] = value;
        _index++;
    }

    public int Count()
    {
        return _index;
    }

    public int CountWithCondition(Func<T, bool> condition)
    {
        int cnt = 0;
        for (int i = 0; i < _index; i++)
        {
            if (condition(_myArr[i]))
            {
                cnt++;
            }
        }
        return cnt;
    }

    public bool ConditionPassedForOne(Func<T, bool> condition)
    {
        for (int i = 0; i < _index; i++)
        {
            if (condition(_myArr[i]))
            {
                return true;
            }
        }
        return false;
    }

    public bool ConditionPassedForEach(Func<T, bool> condition)
    {
        for (int i = 0; i < _index; i++)
        {
            if (!condition(_myArr[i]))
            {
                return false;
            }
        }
        return true;
    }

    public T[] GetReversed()
    {
        T[] reversedArr = new T[_index];
        for (int i = 0; i < _index; i++)
        {
            reversedArr[i] = _myArr[_index - 1 - i];
        }
        return reversedArr;
    }

    public void Reverse()
    {
        T[] reversedArr = GetReversed();
        ReFill(reversedArr);
    }

    public T[] GetAmountFromIndex(int amount, int index)
    {
        if (index + amount - 1 >= _index)
        {
            Console.WriteLine("(AmountFromIndex) Too big amount or index; Empty array was returned");
            return _emptyArray;
        }
        T[] toRet = new T[amount];
        for (int i = 0; i < amount; i++)
        {
            toRet[i] = _myArr[index + i];
        }
        return toRet;
    }

    public T GetFirstByCondition(Func<T, bool> condition)
    {
        for (int i = 0; i < _index; i++)
        {
            if (condition(_myArr[i]))
            {
                return _myArr[i];
            }
        }
        Console.WriteLine("(GetFirstByCondition) No elements found; Default value was returned");
        return _emptyValue;
    }

    public T[] GetEveryByCondition(Func<T, bool> condition)
    {
        int amount = CountWithCondition(condition);
        if (amount == 0)
        {
            Console.WriteLine("(GetEveryByCondition) No elements found; Empty array was returned");
            return _emptyArray;
        }
        T[] toRet = new T[amount];
        int j = 0;
        for (int i = 0; i < _index; i++)
        {
            if (condition(_myArr[i]))
            {
                toRet[j++] = _myArr[i];
            }
        }
        return toRet;
    }

    public bool Contains(T value)
    {
        for (int i = 0; i < _index; i++)
        {
            if (_myArr[i].CompareTo(value) == 0)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveByIndex(int index)
    {
        if (index >= 0 || index < _index)
        {
            _myArr[index] = _emptyValue;
            for (int i = index; i < _index - 1; i++)
            {
                (_myArr[i], _myArr[i + 1]) = (_myArr[i + 1], _myArr[i]);
            }
            _index--;
        }
    }

    public (T, T) GetMinAndMax()
    {
        T min = _myArr[0], max = _myArr[0];
        for (int i = 1 ; i < _index; i++)
        {
            if (_myArr[i].CompareTo(min) < 0)
            {
                min = _myArr[i];
            }
            if (_myArr[i].CompareTo(max) > 0)
            {
                max = _myArr[i];
            }
        }
        return (min, max);
    }

    public T[] Sorted()
    {
        T[] toSort = GetAmountFromIndex(_index, 0);
        Array.Sort(toSort);
        return toSort;
    }

    public void Sort()
    {
        T[] sortedArr = Sorted();
        ReFill(sortedArr);
    }

    public void ApplyToEveryValue(Action<T> action)
    {
        for (int i = 0; i < _index; i++)
        {
            action(_myArr[i]);
        }
    }

    public void ApplyToEveryValue(Func<T,T> action)
    {
        T[] appliedArr = GetAppliedToEveryValue(action);
        ReFill(appliedArr);
    }

    public T[] GetAppliedToEveryValue(Func<T, T> action)
    {
        T[] toRet = new T[_index];
        for (int i = 0; i < _index; i++)
        {
            toRet[i] = _myArr[i];
            toRet[i] = action(toRet[i]);
        }
        return toRet;
    }

    private void ReSize()
    {
        T[] newArr = new T[_capacity * 2 + 1];
        for (int i = 0; i < _capacity; i++)
        {
            newArr[i] = _myArr[i];
        }
        _myArr = newArr;
        _capacity = _capacity * 2 + 1;
    }

    private void ReFill(T[] newArr)
    {
        _myArr = new T[_capacity];
        for (int i = 0; i < newArr.Length; i++)
        {
            _myArr[i] = newArr[i];
        }
    }
}
