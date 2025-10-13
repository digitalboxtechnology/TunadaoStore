namespace API.Errors;

public class ApiErrorResponse
{
    public ApiErrorResponse(int StatusCode, string? Message, string? Details)
    {
        this.StatusCode = StatusCode;
        this.Message = Message;
        this.Details = Details;
    }
    
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Details { get; set; }
}