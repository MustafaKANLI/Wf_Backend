namespace Common.Wrappers;

public class ListedResponse<T> : Response<T>
{

    public int DataCount { get; set; }

    public ListedResponse(T data, int dataCount)
    {
        this.Data = data;
        this.Message = null;
        this.Succeeded = true;
        this.Errors = null;
        this.DataCount = dataCount;
    }
}
