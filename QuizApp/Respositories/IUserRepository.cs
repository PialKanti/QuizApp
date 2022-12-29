using Microsoft.AspNetCore.Identity;
using QuizApp.Dtos;
using QuizApp.Entities;

namespace QuizApp.Respositories
{
    public interface IUserRepository <T>
    {
        Task<T> Get(string id);
        Task<IdentityResult> Insert(UserCreateDto dtoModel);
        Task<IEnumerable<T>> GetAll();
    }
}
