namespace EdiRequests
{
    public class CreateEdiTransaction : MediatR.IRequest<int>
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}