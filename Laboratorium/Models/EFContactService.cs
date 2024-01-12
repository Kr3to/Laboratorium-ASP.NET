using Data.Entities;
using Data;
using Laboratorium_3_4.Mappers;

namespace Laboratorium_3_4.Models
{
    public class EFContactService : IContactService
    {
        private readonly AppDbContext _context;
        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Contact contact)
        {
            _context.Contacts.Add(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = _context.Contacts.Find(id);
            if (entity != null)
            {
                _context.Contacts.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<Contact>? FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList();
        }

        public Contact? FindById(int id)
        {
            var entity = _context.Contacts.Find(id);
            if (entity != null)
            {
                return ContactMapper.FromEntity(entity);
            }
            else { return null; }

        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }
    }
}
