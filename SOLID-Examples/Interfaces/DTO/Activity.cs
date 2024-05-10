namespace Interfaces.DTO
{
    public struct Activity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Creación: {CreationDate.ToString("dd-MM-yyyy HH:mm")}, Message: {Message}.";
        }
    }
}