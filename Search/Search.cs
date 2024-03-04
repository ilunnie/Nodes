using System.Collections.Generic;

namespace ilunnie.Search;

public static partial class Search
{
    public static int BinarySearch<T>(this List<T> collection, T value)
    {
        int begin = 0;
        int end = collection.Count;
        Comparer<T> comparer = Comparer<T>.Default;

        do 
        {
            int index = (begin + end) / 2;
            var comp = comparer.Compare(collection[index], value);
            if (comp == 0) return index;
            if (comp < 0)
                 begin = index;
            else end = index;
        } while (begin < end);
        return -1;
    }
}