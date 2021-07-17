namespace LineChatBot_DotNetCore.Models.Interface
{
    public interface ILinePushResponse
    {
        object[] Messages { get; set; }
    }
}