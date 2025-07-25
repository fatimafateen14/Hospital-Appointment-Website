public class AuthService
{
    private bool _isLoggedIn = false;
    private string? _userEmail;

    public bool IsLoggedIn => _isLoggedIn;
    public string? UserEmail => _userEmail;

    public void Login(string email)
    {
        _isLoggedIn = true;
        _userEmail = email;
    }

    public void Logout()
    {
        _isLoggedIn = false;
        _userEmail = null;
    }
}
