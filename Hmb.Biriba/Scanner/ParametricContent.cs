namespace Hmb.Biriba.Scanner
{
    public class ParametricContent : IParameterProvider<ParametricContent.Parameter>
    {
        public class Parameter
        {
            //public virvoid SetValue<T>(T value);
        }
        public string? MediaType { get; init; }

        public string? Content { get; init; }

        public IDictionary<string, string>? Headers { get; init; }

        public virtual IEnumerable<Parameter> GetParameters()
            => [];

    }

    public interface IParameterProvider<out TParameter> where TParameter : ParametricContent.Parameter
    {
        IEnumerable<TParameter> GetParameters();
    }
}
