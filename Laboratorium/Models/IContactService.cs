namespace Laboratorium_3_4.Models
{
    public interface IContactService
    {
        void Add(Contact contact);
        void Update(Contact contact);
        void DeleteById(int id);
        Contact? FindById(int id);
        List<Contact>? FindAll();
    }
}
