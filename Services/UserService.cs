using GorevYoneticisi.Interfaces;
using GorevYoneticisi.Model;

namespace GorevYoneticisi.Services
{
    public class UserService : IUserService
    {
        public IRepository<Users> _userRepo;

        public IRepository<TokenInfo> _tokenRepo;
        public UserService(IRepository<Users> userRepo, IRepository<TokenInfo> tokenRepo)
        {
            _userRepo = userRepo;
            _tokenRepo = tokenRepo;
        }

        public Task<string> createUser(string username, string password, string passwordAgain)
        {
            if(username == null || password == null || passwordAgain == null) throw new ArgumentNullException("Eksik veri girildi.");

            if(!password.Equals(passwordAgain)) throw new Exception("Şifreler uyuşmuyor.");

            Users newUser = new Users
            {
                UserName = username,
                Password = password,
            };

            _userRepo.Ekle(newUser);

            Users user = _userRepo.Get(user => user.UserName == username && user.Password == password);

            TokenInfo token = new TokenInfo
            {
                userid = user.Id, 
                Token = null,
                ExpiryTime = DateTime.Now
            };

            _tokenRepo.Ekle(token);

            return Task.FromResult("Kullanıcı başarıyla eklendi.");
        }

        public Task<TokenInfo> login(string username, string password)
        {
            if (username == null || password == null) throw new ArgumentNullException("Eksik veri girildi.");

            Users? user = _userRepo.Get(user => user.UserName == username && user.Password == password );

            if (user == null) throw new Exception("Böyle bir kullanıcı bulunmamaktadır.");

            TokenInfo tokenInfo = _tokenRepo.Get(token => token.userid == user.Id);

            return Task.FromResult(tokenInfo);
        }
    }
}
