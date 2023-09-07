using System;

namespace CodeBase.Infrastructure.Observables
{
    /// <summary>
    /// Wraps a value in order to allow observing its value change
    /// </summary>
    /// <example>>
    ///   var obs = new Observable<int>(123);
    ///   obs.OnChanged += (o, oldVal, newVal) => Log("changed from " + oldVal + " to " + newVal);
    ///   obs.Value = 456; // dispatches OnChanged
    /// </example>
    /// <author>Jackson Dunstan, http://JacksonDunstan.com/articles/3547</author>
    /// <license>MIT</license>
    [Serializable]
    public class Observable<TValue> : IEquatable<Observable<TValue>>
    {
        private TValue value;
 
        public Observable()
        {
        }
 
        public Observable(TValue value)
        {
            this.value = value;
        }
 
        public Action<Observable<TValue>, TValue, TValue> OnChanged;
 
        public TValue Value
        {
            get { return value; }
            set
            {
                var oldValue = this.value;
                this.value = value;
                if (OnChanged != null)
                {
                    OnChanged(this, oldValue, value);
                }
            }
        }
 
        public static implicit operator Observable<TValue>(TValue observable)
        {
            return new Observable<TValue>(observable);
        }
 
        public static explicit operator TValue(Observable<TValue> observable)
        {
            return observable.value;
        }
 
        public override string ToString()
        {
            return value.ToString();
        }
 
        public bool Equals(Observable<TValue> other)
        {
            return other.value.Equals(value);
        }
 
        public override bool Equals(object other)
        {
            return other != null
                   && other is Observable<TValue>
                   && ((Observable<TValue>)other).value.Equals(value);
        }
 
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}