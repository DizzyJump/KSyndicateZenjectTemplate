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
    public class Observable<T> : IEquatable<Observable<T>>
    {
        private T value;
 
        public Observable()
        {
        }
 
        public Observable(T value)
        {
            this.value = value;
        }
 
        public Action<Observable<T>, T, T> OnChanged;
 
        public T Value
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
 
        public static implicit operator Observable<T>(T observable)
        {
            return new Observable<T>(observable);
        }
 
        public static explicit operator T(Observable<T> observable)
        {
            return observable.value;
        }
 
        public override string ToString()
        {
            return value.ToString();
        }
 
        public bool Equals(Observable<T> other)
        {
            return other.value.Equals(value);
        }
 
        public override bool Equals(object other)
        {
            return other != null
                   && other is Observable<T>
                   && ((Observable<T>)other).value.Equals(value);
        }
 
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}