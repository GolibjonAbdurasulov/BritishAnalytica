using System;
using System.Text.Json;

namespace Entity.Models.Common
{
    public class MultiLanguageField
    {
        protected bool Equals(MultiLanguageField other)
        {
            return uz == other.uz && ru == other.ru && en == other.en;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MultiLanguageField)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(uz, ru, en);
        }

        /// <summary>
        /// O`zbek (Lotin) tilida
        /// </summary>
        public string uz { get; set; }

        /// <summary>
        /// Rus tilida
        /// </summary>
        public string ru { get; set; }

        /// <summary>
        /// Inglis tilida
        /// </summary>
        public string en { get; set; }

        public static implicit operator MultiLanguageField(string data) => new MultiLanguageField()
        {
            ru = data,
            uz = data,
            en = data
        };

        public static bool operator ==(MultiLanguageField a, string b)
        {
            return a.ru == b || a.en == b || a.uz == b;
        }

        public static bool operator !=(MultiLanguageField a, string b)
        {
            return a.ru != b && a.en != b && a.uz != b;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}