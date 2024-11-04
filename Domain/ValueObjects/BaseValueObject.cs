using System.Reflection;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Базовый класс для всех объектов значений, обеспечивающий сравнение и вычисление хеш-кода на основе всех полей и свойств.
    /// </summary>
    public abstract class BaseValueObject : IEquatable<BaseValueObject>
    {
        /// <summary>
        /// Определяет, равен ли текущий объект значению другого объекта.
        /// </summary>
        /// <param name="other">Другой объект для сравнения.</param>
        /// <returns>True, если объекты равны; иначе False.</returns>
        public bool Equals(BaseValueObject? other)
        {
            if (other == null || other.GetType() != GetType())
                return false;

            // Сравниваем все свойства
            foreach (var property in GetProperties())
            {
                var value1 = property.GetValue(this);
                var value2 = property.GetValue(other);
                if (!Equals(value1, value2))
                    return false;
            }

            // Сравниваем все поля
            foreach (var field in GetFields())
            {
                var value1 = field.GetValue(this);
                var value2 = field.GetValue(other);
                if (!Equals(value1, value2))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Переопределение метода Equals для сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если объекты равны; иначе False.</returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as BaseValueObject);
        }

        /// <summary>
        /// Переопределение метода GetHashCode для вычисления хеш-кода на основе всех полей и свойств.
        /// </summary>
        /// <returns>Хеш-код объекта.</returns>
        public override int GetHashCode()
        {
            int hash = 17;

            foreach (var property in GetProperties())
            {
                var value = property.GetValue(this);
                hash = hash * 31 + (value?.GetHashCode() ?? 0);
            }

            foreach (var field in GetFields())
            {
                var value = field.GetValue(this);
                hash = hash * 31 + (value?.GetHashCode() ?? 0);
            }

            return hash;
        }

        /// <summary>
        /// Получает список всех доступных свойств объекта для сравнения.
        /// </summary>
        /// <returns>Коллекция свойств объекта.</returns>
        private IEnumerable<PropertyInfo> GetProperties()
        {
            return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => !p.GetGetMethod()!.IsVirtual);
        }

        /// <summary>
        /// Получает список всех доступных полей объекта для сравнения.
        /// </summary>
        /// <returns>Коллекция полей объекта.</returns>
        private IEnumerable<FieldInfo> GetFields()
        {
            return GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
        }

        /// <summary>
        /// Оператор сравнения на равенство для объектов значений.
        /// </summary>
        /// <param name="left">Левый объект для сравнения.</param>
        /// <param name="right">Правый объект для сравнения.</param>
        /// <returns>True, если объекты равны; иначе False.</returns>
        public static bool operator ==(BaseValueObject? left, BaseValueObject? right)
        {
            return left?.Equals(right) ?? ReferenceEquals(right, null);
        }

        /// <summary>
        /// Оператор сравнения на неравенство для объектов значений.
        /// </summary>
        /// <param name="left">Левый объект для сравнения.</param>
        /// <param name="right">Правый объект для сравнения.</param>
        /// <returns>True, если объекты не равны; иначе False.</returns>
        public static bool operator !=(BaseValueObject? left, BaseValueObject? right)
        {
            return !(left == right);
        }
    }
}
