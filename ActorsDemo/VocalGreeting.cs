namespace ActorsDemo
{
    public class VocalGreeting
    {
        private readonly string _message;


        public VocalGreeting(string message)
        {
            _message = message;
        }
        public string Greeting
        {
            get { return _message; }
        }
    }
}