namespace SignalRChat.Model {
    public class MessageDto {
        public string Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Group { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
    }
}