using System.Collections.Generic;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;

namespace language_ext.benchmark.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository userRepository;

        public UsersController(UserRepository userRepository) => this.userRepository = userRepository;

        [HttpGet("/linq")]
        public IEnumerable<User> GetWithLinq() => userRepository.FindWithLinq();
            

        [HttpGet("/ext")]
        public Seq<User> GetWithLanguageExt() => userRepository.FindWithLangExt();
    }
}