namespace EvolentContact.Common
{
    /// <summary>
    /// Base Response Model
    /// </summary>
    public class BaseResponse
    {
        public bool Success { get; set; }
        public List<string>? Errors { get; set; }
        public object? Result { get; set; }
    }
}