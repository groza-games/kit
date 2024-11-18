using System;

namespace GrozaGames.Kit
{
    [Serializable]
    public class Reactive<T>
    {
        [NonSerialized] protected T _value;
        [NonSerialized] protected T _prevValue;

        public event OnValueChangedDelegate OnValueChanged;
        public event OnValueChangedExtendedDelegate OnValueChangedExtended;

        public T Value => _value;
        public T PrevValue => _prevValue;

        public Reactive()
        {
            _value = default;
        }

        public Reactive(T value)
        {
            _value = value;
        }

        public void SetValue(T newValue)
        {
            if (Equals(_value, newValue))
                return;

            _prevValue = _value;
            _value = newValue;
            OnValueChanged?.Invoke(_value);
            OnValueChangedExtended?.Invoke(_value, _prevValue);
        }

        public void SetValueWithoutNotify(T newValue)
        {
            _prevValue = _value;
            _value = newValue;
        }
        
        public static implicit operator T(Reactive<T> field) => field._value;
        
        public delegate void OnValueChangedDelegate(T value);
        public delegate void OnValueChangedExtendedDelegate(T newValue, T oldValue);
    }

    public static class ReactiveEx
    {
        public static bool IsDown(this Reactive<bool> reactive)
        {
            return reactive.Value && !reactive.PrevValue;
        }
        
        public static bool IsUp(this Reactive<bool> reactive)
        {
            return !reactive.Value && reactive.PrevValue;
        }

        public static bool IsChanged(this Reactive<bool> reactive)
        {
            return reactive.Value != reactive.PrevValue;
        }
    }
}