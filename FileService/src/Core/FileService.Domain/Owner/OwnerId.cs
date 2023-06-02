using FileService.Domain.SeekWork;

namespace FileService.Domain.Owner
{
    public class OwnerId : StronglyTypedId<OwnerId>
    {
        public OwnerId(Guid value) : base(value)
        {
        }
    }
}
