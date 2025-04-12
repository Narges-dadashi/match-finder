namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult<LoggedInDto>> Create(AppUser userInput, CancellationToken cancellationToken)
        {
            if (userInput.Password != userInput.ConfirmPassword)
                return BadRequest("Your passwords do not match!");

            LoggedInDto? loggedInDto = await userRepository.CreateAsync(userInput, cancellationToken);

            if (loggedInDto is null)
                return BadRequest("This email is already taken.");

            return Ok(loggedInDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoggedInDto>> Login(LoginDto userInput, CancellationToken cancellationToken)
        {
            LoggedInDto? loggedInDto = await userRepository.LoginAsync(userInput, cancellationToken);

            if (loggedInDto is null)
                return BadRequest("Email or Password is wrong");

            return loggedInDto;
        }

        [HttpGet]
        public async Task<ActionResult<List<MemberDto>>> GetAll(CancellationToken cancellationToken)
        {
            List<AppUser>? appUsers = await userRepository.GetAllAsync(cancellationToken);

            if (appUsers is null)
                return NoContent();

            List<MemberDto> memberDtos = [];

            foreach (AppUser user in appUsers)
            {
                MemberDto memberDto = new(
                    Email: user.Email,
                    UserName: user.UserName,
                    Age: user.Age,
                    City: user.City,
                    Country: user.Country
                );

                memberDtos.Add(memberDto);
            }

            return memberDtos;
        }

        [HttpPut("update/{userId}")]
        public async Task<ActionResult<UpdateDto>> UpdateById(string userId, AppUser userInput, CancellationToken cancellationToken)
        {
            UpdateDto? updateDto = await userRepository.UpdateByIdAsync(userId, userInput, cancellationToken);

            if (updateDto is null)
                return BadRequest("Operation failed.");

            return updateDto;
        }

        [HttpDelete("delete/{userId}")]
        public async Task<ActionResult<DeleteResult>> DeleteById(string userId, CancellationToken cancellationToken)
        {
            DeleteResult? deleteResult = await userRepository.DeleteByIdAsync(userId, cancellationToken);

            if (deleteResult is null)
                return BadRequest("Operation failed");

            return deleteResult;
        }
    }
}








//         [HttpPost("create")]
//         public ActionResult<AppUser> CreateUser(AppUser userInput)
//         {
//             AppUser user = _collection.Find<AppUser>(doc =>
//                 doc.Email == userInput.Email.Trim().ToLower()).FirstOrDefault();

//             if (user is null)
//             {
//                 _collection.InsertOne(userInput);

//                 return userInput;
//             }

//             return BadRequest("Email already exists!");
//         }

//         [HttpGet]
//         public ActionResult<List<AppUser>> GetAll()
//         {
//             List<AppUser> appUsers = _collection.Find<AppUser>(new BsonDocument()).ToList();

//             if (appUsers.Count == 0)
//             {
//                 return NoContent();
//             }

//             return appUsers;
//         }

//         [HttpGet("get-by-username/{usernameInput}")]
//         public ActionResult<AppUser> GetByUserName(string usernameInput)
//         {
//             AppUser user = _collection.Find<AppUser>(doc => doc.UserName == usernameInput.Trim().ToLower()).FirstOrDefault();

//             if (user is null)
//             {
//                 return NotFound("No user found with this username!");
//             }

//             return user;
//         }

//         [HttpPut("update/{userId}")]
//         public ActionResult<AppUser> UpdateById(string userId, AppUser userInput)
//         {
//             UpdateDefinition<AppUser> updateDef = Builders<AppUser>.Update
//             .Set(user => user.UserName, userInput.UserName.Trim().ToLower())
//             .Set(user => user.Age, userInput.Age);

//             _collection.UpdateOne(user => user.Id == userId, updateDef);

//             AppUser appUser = _collection.Find(User => User.Id == userId).FirstOrDefault();

//             return appUser;
//         }

//         [HttpDelete("delete/{userId}")]
//         public ActionResult<DeleteResult> DeleteById(string userId)
//         {
//             AppUser appUser = _collection.Find<AppUser>(doc => doc.Id == userId).FirstOrDefault();

//             if (appUser is null)
//             {
//                 return BadRequest("User not found!");
//             }

//             return _collection.DeleteOne<AppUser>(doc => doc.Id == userId);
//         }
//     }
// }
// [HttpPost("create")]
// public AppUser Create(AppUser userInput)
// {
//     AppUser user = new AppUser(
//         Id: null,
//         Email: userInput.Email.ToLower().Trim(),
//         Name: userInput.Name.ToLower().Trim(),
//         // Age: userInput.Age,
//         Password: userInput.Password,
//         ConfirmPassword: userInput.ConfirmPassword
//     // Address: new Address(
//     //     Street: userInput.Address.Street,
//     //     City: userInput.Address.City,
//     //     ZipCode: userInput.Address.ZipCode
//     // )
//     );

//     _collection.InsertOne(user);

//     return user;
// }

//     [HttpPost("register")]
//     public ActionResult<AppUser> Register(AppUser userInput)
//     {
//         if (userInput.Password != userInput.ConfirmPassword)
//         {
//             return BadRequest("Passwords do not match!");
//         }

//         AppUser user = _collection.Find<AppUser>(doc =>
//                 doc.Email == userInput.Email).FirstOrDefault();

//         if (user is null)
//         {
//             _collection.InsertOne(userInput);

//             return userInput;
//         }

//         return BadRequest("This email already exists!");
//     }

//     [HttpGet]
//     public ActionResult<List<AppUser>> GetAll()
//     {
//         List<AppUser> appUsers = _collection.Find<AppUser>(new BsonDocument()).ToList();

//         if (appUsers.Count == 0)
//         {
//             return NoContent();
//         }

//         return appUsers;
//     }

//     [HttpGet("get-by-username/{usernameInput}")]
//     public ActionResult<AppUser> GetByUserName(string usernameInput)
//     {
//         AppUser user = _collection.Find<AppUser>(doc => doc.Name == usernameInput).FirstOrDefault();

//         if (user is null)
//         {
//             return NotFound("No user found with this username!");
//         }

//         return user;
//     }

//     [HttpPut("update/{userId}")]
//     public ActionResult<AppUser> UpdateById(string userId, AppUser userInput)
//     {
//         UpdateDefinition<AppUser> updateDef = Builders<AppUser>.Update
//         .Set(user => user.Email, userInput.Email.Trim().ToLower())
//         .Set(user => user.Age, userInput.Age);

//         _collection.UpdateOne(user => user.Id == userId, updateDef);

//         AppUser appUser = _collection.Find(user => user.Id == userId).FirstOrDefault();

//         return appUser;
//     }

//     [HttpDelete("delete/{userId}")]
//     public ActionResult<DeleteResult> DeleteById(string userId)
//     {
//         AppUser appUser = _collection.Find<AppUser>(doc => doc.Id == userId).FirstOrDefault();

//         if (appUser is null)
//         {
//             return BadRequest("user not Found!");
//         }

//         return _collection.DeleteOne<AppUser>(doc => doc.Id == userId);
//     }
// }

// [HttpPut("update/{userId}")]
// public ActionResult<UpdateResult> UpdateUserById(string userId, AppUser userIn)
// {
//     UpdateDefinition<AppUser> updateUser = Builders<AppUser>.Update
//     .Set(appUser => appUser.Email, userIn.Email.ToLower().Trim());

//     return _collection.UpdateOne(appUser => appUser.Id == userId, updateUser);
// }

// [HttpPut("update-one/{userId}")]
// public ActionResult<UpdateResult> UpdateWithId(string userId, AppUser userInput)
// {
//     UpdateDefinition<AppUser> updateUser = Builders<AppUser>.Update
//     .Set(user => user.Email, userInput.Email.Trim().ToLower())
//     .Set(user => user.Name, userInput.Name.Trim().ToLower());

//     return _collection.UpdateOne(user => user.Id == userId, updateUser);
// }

//     [HttpDelete("delete/{userId}")]
//     public ActionResult<DeleteResult> DeleteById(string userId)
//     {
//         AppUser user = _collection.Find(user => user.Id == userId).FirstOrDefault();

//         if (user is null)
//         {
//             return NotFound("user not found");
//         }

//         return _collection.DeleteOne(user => user.Id == userId);
//     }