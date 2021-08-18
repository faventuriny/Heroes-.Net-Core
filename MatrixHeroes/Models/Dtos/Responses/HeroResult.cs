namespace MatrixHeroes.Models.Dtos.Responses
{
    public class HeroResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Payload { get; set; }
    }
}
