namespace FileService.Infrastructure.DTO
{
    public record class FilesDTO
    {
        public Guid Id { get; set; }
        public string FileName { get; init; }
        public string ContentType { get; init; }
        public byte[] Content { get; init; }
        public float Size { get; private set; }
        public string Extension { get; private set; }
        public DateTime CreatAt { get; private set; } = DateTime.Now;
        public DateTime? LastUpdate { get; private set; }
    }
}
