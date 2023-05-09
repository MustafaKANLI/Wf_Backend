namespace UsersService.Application.Features.SharedViewModels;

public class UserViewModel
{
  public int Id { get; set; }
  public string Email { get; set; }
  public string Password { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public int CustomerId { get; set; }
    public int ClaimId { get; set; }
    public string Phone { get; set; }
    public bool IsLocked { get; set; }
}
