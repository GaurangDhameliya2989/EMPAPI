namespace APRMAL
{
    public class SMS
    {
        public int balance { get; set; }
        public long batch_id { get; set; }
        public int cost { get; set; }
        public int num_messages { get; set; }
        public Message1 message { get; set; }
        public string receipt_url { get; set; }
        public string custom { get; set; }
        public List<Message2> messages { get; set; }
        public string status { get; set; }
    }

    public class Message1
    {
        public int num_parts { get; set; }
        public string sender { get; set; }
        public string content { get; set; }
    }

    public class Message2
    {
        public string id { get; set; }
        public long recipient { get; set; }
    }
}
