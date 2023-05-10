namespace Common.Wrappers;

public class PagedResponse<T> : Response<T>
{



    public PagedResponse(T data)
    {
        
        this.Data = data;
        this.Message = null;
        this.Succeeded = true;
        this.Errors = null;
        
    }
}
