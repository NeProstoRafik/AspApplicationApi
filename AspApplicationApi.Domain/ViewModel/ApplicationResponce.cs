namespace AspApplicationApi.Domain.ViewModel
{
    public class ApplicationResponce
    {
        public Guid Id { get; set; }
        public Guid Autor { get; set; }

        public Enum.Type Type { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Outline { get; set; }
    }
}
