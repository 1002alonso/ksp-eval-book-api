namespace KspEvalBook.Api.Models
{
    public class MMessage
    {
        public string title { get; set; }
        public string mesage { get; set; }
        public string? timestap { get; set; }

        public MMessage()
        {
            timestap = DateTime.UtcNow.ToString();
        }
    }
}
