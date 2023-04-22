namespace Application.Exceptions
{
    public abstract class PipelineApplicationException : Exception
    {
        protected PipelineApplicationException(string title, string message)
            : base(message) =>
            Title = title;

        public string Title { get; }
    }
}
