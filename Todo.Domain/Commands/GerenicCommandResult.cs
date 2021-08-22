namespace Todo.Domain.Commands.Contracts
{
    public class GerenicCommandResult : ICommandResult
    {
        public GerenicCommandResult() { }
        public GerenicCommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}