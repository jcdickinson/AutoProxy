using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoProxy
{
    public class Pointer<T> : IPointer
    {
        public T Value
        {
            get;
            set;
        }

        public Pointer()
        {

        }

        public Pointer(T value)
        {
            Value = value;
        }

        public static implicit operator T(Pointer<T> val)
        {
            if (val == null) return default(T);
            return val.Value;
        }

        public static implicit operator Pointer<T>(T val)
        {
            return new Pointer<T>(val);
        }

        object IPointer.Value
        {
            get { return Value; }
        }

        public override string ToString()
        {
            if (object.ReferenceEquals(Value, null))
                return null;
            else
                return Value.ToString();
        }
    }
}
