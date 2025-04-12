// namespace api.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class AccountController : ControllerBase
//     {
//         #region Db and Token Settings
//         private readonly IMongoCollection<AppUser> _collection;

//         // constructor - dependency injections
//         public AccountController(IMongoClient client, IMongoDbSettings dbSettings)
//         {
//             var dbName = client.GetDatabase(dbSettings.DatabaseName);
//             _collection = dbName.GetCollection<AppUser>("users");
//         }
//         #endregion

//         // [HttpPost("createUser")]
//         // public AppUser Create()
//         // {
//         //     AppUser appUser = new AppUser(
//         //         Id: null,
//         //         Email: "Narges@gmail.com",
//         //         Name: "Narges",
//         //         // Age: 18,
//         //         Password: "123456",
//         //         ConfirmPassword: "123456"
//         //     );

//         //     _collection.InsertOne(appUser);

//         //     return appUser;
//         // }

//         // [HttpPost("registerUser")]
//         // public AppUser Register(string email, string name, string password, string ConfirmPassword)
//         // {
//         //     AppUser appUser = new AppUser(
//         //         Id: null,
//         //         Email: email,
//         //         Name: name,
//         //         // Age: age,
//         //         Password: password,
//         //         ConfirmPassword: ConfirmPassword
//         //     );

//         //     _collection.InsertOne(appUser);

//         //     return appUser;
//         // }

//         // [HttpPost("loginUser")]
//         // public AppUser Login(AppUser userInput)
//         // {
//         //     AppUser user = new AppUser(
//         //         Id: null,
//         //         Email: userInput.Email,
//         //         Name: userInput.Name,
//         //         // Age: userInput.Age,
//         //         Password: userInput.Password,
//         //         ConfirmPassword: userInput.ConfirmPassword
//         //     );

//         //     _collection.InsertOne(user);

//         //     return user;
//         // }

//         [HttpPost("register")]
//         public ActionResult<AppUser> CreateUser(AppUser userInput)
//         {
//             AppUser appUser = _collection.Find<AppUser>(doc => doc.Email == userInput.Email.Trim()).FirstOrDefault();

//             if (appUser is null)
//             {
//                 // AppUser user = new AppUser(
//                 // Id: null,
//                 // Email: userInput.Email,
//                 // Name: userInput.Name,
//                 // Age: userInput.Age,
//                 // Password: userInput.Password,
//                 // ConfirmPassword: userInput.ConfirmPassword
//                 // );

//                 // _collection.InsertOne(user);

//                 // return user;
//             }

//             return BadRequest("This email already exists.");
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
//     }
// }