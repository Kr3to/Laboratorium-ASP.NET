namespace Laboratorium_3_4.Models
{
    public class MemoryContactService : IContactService
    {
        private readonly IDateTimeProvider _timeProvider;

        public MemoryContactService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        private readonly Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>() {
            { 1, new Contact() { Id = 1, Name="Mateusz", Email="mateusz@onet.pl", Phone="623782383"} },
            { 2, new Contact() { Id = 2, Name = "Kret", Email = "kret@onet.pl", Phone = "564645365"} },

        };
        private int _id = 3;
        public void Add(Contact contact)
        {
            contact.Id = _id++;
            contact.Created = _timeProvider.GetDateTime();
            Console.WriteLine($"Contact created at: {contact.Created}");

            _contacts[contact.Id] = contact;
        }

        public void DeleteById(int id)
        {
            _contacts.Remove(id);
        }

        public List<Contact>? FindAll()
        {
            return _contacts.Values.ToList();
        }

        public Contact? FindById(int id)
        {
            return _contacts[id];
        }

        public void Update(Contact contact)
        {
            _contacts[contact.Id] = contact;
        }
    }
}
