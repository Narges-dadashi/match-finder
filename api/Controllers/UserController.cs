namespace api.Controllers;

[Authorize]
public class UserController(IUserRepository userRepository) : BaseApiController
{
    [HttpPut("update")]
    public async Task<ActionResult<MemberDto>> UpdateById(AppUser userInput, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();

        if (userId is null)
            return Unauthorized("You are not logged, Please log in again.");

        MemberDto? memberDto = await userRepository.UpdateByIdAsync(userId, userInput, cancellationToken);

        if (memberDto is null)
            return BadRequest("Operation failed.");

        return memberDto;
    }

    [HttpPut("add-photo")]
    public async Task<ActionResult<Photo>> AddPhoto(
        [AllowedFileExtensions, FileSize(250_000, 4_000_000)]
        IFormFile file, CancellationToken cancellationToken
    )
    {
        if (file is null) return BadRequest("No file selected with this request");

        string? userId = User.GetUserId();

        Console.WriteLine(userId);

        if (userId is null)
        {
            return Unauthorized("You are not logged in. please login again");
        }

        Photo? photo = await userRepository.UploadPhotoAsync(file, userId, cancellationToken);

        return photo is null ? BadRequest("Add photo failed. See logger") : photo;
    }

    [HttpPut("set-main-photo")]
    public async Task<ActionResult> SetMainPhoto(string photoUrlIn, CancellationToken cancellationToken)
    {
        string? userId = User.GetUserId();

        if (userId is null)
        {
            return Unauthorized("You are not logged in. please login again");
        }

        UpdateResult? updateResult = await userRepository.SetMainPhotoAsync(userId, photoUrlIn, cancellationToken);

        return updateResult is null || !updateResult.IsModifiedCountAvailable
            ? BadRequest("Set as main photo failed. Try again in a few moments. If the issue persists contact the admin.")
            : Ok("Set this photo as main succeeded.");
    }

    [HttpPut("delete-photo")]
    public async Task<ActionResult> DeletePhoto(string photoUrlIn, CancellationToken cancellationToken)
    {
        string? userId = User.GetUserId();

        if (string.IsNullOrEmpty(userId))
            return Unauthorized("The user is not logged in");

        UpdateResult? updateResult = await userRepository.DeletePhotoAsync(userId, photoUrlIn, cancellationToken);

        return updateResult is null || !updateResult.IsModifiedCountAvailable
            ? BadRequest("Photo deletion failed. Try again in a few moments. If the issue persists contact the admin.")
            : Ok("Photo deleted successfully.");
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