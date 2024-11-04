using Domain.ValueObjects;

namespace Domain.Entities
{
    /// <summary>
    /// Аптека
    /// </summary>
    public class DrugStore : BaseEntity
    {
        public DrugStore(string drugNetwork, int number, Address address)
        {
            DrugNetwork = drugNetwork;
            Number = number;
            Address = address;
        }

        /// <summary>
        /// Сеть аптек, к которой принадлежит аптека.
        /// </summary>
        public string DrugNetwork { get; private set; }
        
        /// <summary>
        /// Номер аптеки в сети.
        /// </summary>
        public int Number { get; private set; }
        
        /// <summary>
        /// Адрес аптеки.
        /// </summary>
        public Address Address { get; private set; }
        
        // Навигационное свойство для связи с DrugItem
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
    }
}