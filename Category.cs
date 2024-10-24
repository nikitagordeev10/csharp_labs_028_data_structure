using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inheritance.DataStructure {
    public class Category : IComparable<Category>, IComparable { // класс, реализует интерфейсы IComparable<Category> и IComparable
        public string Product { get; set; }
        public MessageType Type { get; set; }
        public MessageTopic Topic { get; set; }

        public Category(string product, MessageType type, MessageTopic topic) { // конструктор класса, инициализирует свойства экземпляра
            Product = product;
            Type = type;
            Topic = topic;
        }

        public override bool Equals(object obj) { // переопределение метода Equals для проверки равенства двух объектов
            if (!(obj is Category)) return false; // переданный объект не является Category, вернуть false
            Category other = (Category)obj;
            return (Product == other.Product) && (Type == other.Type) && (Topic == other.Topic); // сравнить свойства объектов
        }

        public override int GetHashCode() { // переопределение метода GetHashCode для нахождения хэш-кода объекта
            return (Product.GetHashCode() * 397) ^ (Type.GetHashCode() * 37) ^ Topic.GetHashCode(); // вычисление хэш-кода
        }

        public static bool operator ==(Category x, Category y) { // переопределение == для проверки равенства двух объектов
            if (object.ReferenceEquals(x, y)) return true; // объекты ссылаются на один и тот же экземпляр, вернуть true
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false; // хотя бы один из объектов null, вернуть false
            return x.Equals(y); // иначе использовать метод Equals для сравнения объектов
        }

        public static bool operator !=(Category x, Category y) { // переопределение != для проверки неравенства двух объектов
            return !(x == y); // инвертировать ==
        }

        public static bool operator <=(Category x, Category y) {
            if (object.ReferenceEquals(x, y)) return true; // если объекты равны, то true
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false; // если один из объектов равен null, то false
            return x.CompareTo(y) <= 0; // Вызываем метод CompareTo для сравнения объектов
        }

        public static bool operator >=(Category x, Category y) {
            if (object.ReferenceEquals(x, y)) return true; // если объекты равны, то true
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false; // если один из объектов равен null, то false
            return x.CompareTo(y) >= 0; // Вызываем метод CompareTo для сравнения объектов
        }

        public static bool operator <(Category x, Category y) {
            if (object.ReferenceEquals(x, y)) return false; // если объекты равны, то false
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false; // если один из объектов равен null, то false
            return x.CompareTo(y) < 0; // Вызываем метод CompareTo для сравнения объектов
        }

        public static bool operator >(Category x, Category y) {
            if (object.ReferenceEquals(x, y)) return false; // если объекты равны, то false
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false; // если один из объектов равен null, то false
            return x.CompareTo(y) > 0; // Вызываем метод CompareTo для сравнения объектов
        }

        public int CompareTo(Category other) { // реализация метода CompareTo интерфейса IComparable<Category>
            if (other == null) { // если объект для сравнения равен null, то текущий объект больше
                return (this == null) ? 0 : 1;
            }

            int productComparison = string.Compare(Product, other.Product, StringComparison.Ordinal); // сравнение свойства Product
            if (productComparison != 0) return productComparison; // свойство Product не 0, вернуть результат сравнения

            int typeComparison = Type.CompareTo(other.Type); // сравнение свойства Type
            if (typeComparison != 0) return typeComparison; // свойство Type не 0, вернуть результат сравнения

            return Topic.CompareTo(other.Topic); // сравнение свойства Topic
        }

        public int CompareTo(object obj) { // реализация метода CompareTo интерфейса IComparable
            if (!(obj is Category)) throw new ArgumentException(); // переданный объект не является Category, исключение
            return CompareTo((Category)obj); // иначе использовать метод CompareTo интерфейса IComparable<Category> для сравнения объектов
        }

        public override string ToString() { // переопределение метода ToString для получения строкового представления объекта
            return $"{Product}.{Type}.{Topic}";
        }
    }
}
