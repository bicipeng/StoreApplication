using System.Collections.Generic;

namespace SotreApplicationBusinessLayer
{
    public interface IRpository<T> where T :class
    {
        List<T> Load();
        bool Update();
        bool Delete(int Id);
        bool Insert(T entry);
    }
}
