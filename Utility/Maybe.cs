using System;
using System.Collections;
using System.Collections.Generic;

namespace KingdomEngine
{
    public class Maybe<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> values;

        public Maybe()
        {
            values = new T[0];
        }

        public Maybe(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            values = new[] { value };
        }

        public IEnumerator<T> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
