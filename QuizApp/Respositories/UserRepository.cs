using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Dtos;
using QuizApp.Entities;

namespace QuizApp.Respositories
{
    public class UserRepository : IUserRepository<ApplicationUser>
    {
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        public UserRepository(UserManager<ApplicationUser> userManager, IMapper mapper) 
        { 
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ApplicationUser> Get(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> Insert(UserCreateDto dtoModel)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(dtoModel);
            return await _userManager.CreateAsync(user, dtoModel.Password);
        }
    }
}
