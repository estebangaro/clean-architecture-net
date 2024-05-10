namespace SOLID.ValueObject
{
    //Estructura encargada de mantener el estado de la información de LOG.
    public struct Activity
    {
        public string Message { get; set; }
        public string Method { get; set; }
        public string ActivityName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}