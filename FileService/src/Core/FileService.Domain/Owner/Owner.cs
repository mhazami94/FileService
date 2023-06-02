using FileService.Domain.Owner.Events;
using FileService.Domain.SeekWork;

namespace FileService.Domain.Owner
{
    public class Owner : AggregateRoot<OwnerId>
    {

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime RegistredAt { get; private set; } = DateTime.Now;


        public static async Task<Owner> CreateNew(string name, string email, string password, IOwnerUniquenessChacker ownerUniquenessChacker)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            if (!await ownerUniquenessChacker.IsOwnerUnique(email))
                throw new Exception("This e-mail is already in use.");

            var id = new OwnerId(Guid.NewGuid());
            return new Owner(id, name, email, password);
        }
        public void SetName(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            Name = value;
            AddDomainEvent(new OwnerUpdateEvent(Id, Name));
        }
        public Owner(OwnerId id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            RegistredAt = DateTime.Now;
        }
    }
}
