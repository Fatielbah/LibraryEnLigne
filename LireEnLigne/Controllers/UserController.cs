using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LireEnLigne.Data;
using LireEnLigne.Views.User;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace LireEnLigne.Controllers
{
	public class UserController : Controller
	{
		private readonly LibraryContext _context;
		public UserController(LibraryContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Login(LoginModel model)
		{

			if (ModelState.IsValid)
			{
				//retrieve user from database based on the entered username
				var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
				if (user != null && user.Password == model.Password)
				{
					//authentification avec succès
					//redirection vers la page d'acceuil
					//create a new authentication ticket
					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, user.Email),
						new Claim(ClaimTypes.Role, "Adherant")
					};
					var userIdentity = new ClaimsIdentity(claims, "login");
					var userPrincipal = new ClaimsPrincipal(userIdentity);
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);
					//redirect to the home page
					return RedirectToAction("Index", "Home");
				}
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Invalid username or password");


			}
			return View(model);


		}


		[HttpPost]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				/*  string Nom = model.Nom;
				  string Prenom = model.Prenom;
				  string Email = model.Email;
				  string Phone = model.NumeroTelephone;*/

				/* _context.Users.Add(new User { Nom = model.Nom, Prenom = model.Prenom, Email = model.Email, Adresse = model.Adresse, Password = model.Password, NumeroTelephone = model.NumeroTelephone});
				 _context.SaveChanges();

				 //redirect to the login page
				 return RedirectToAction("Index", "Login");*/

				//check if the user with the same email already exists
				var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
				if (existingUser != null)
				{
					return BadRequest("User with the same provided email already exists.");
				}

				//else

				//Hashing the password before storing it
				// Generate a 128-bit salt using a sequence of
				// cryptographically strong random bytes.
				byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
				Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

				// derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
				string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: model.Password!,
					salt: salt,
					prf: KeyDerivationPrf.HMACSHA256,
					iterationCount: 100000,
					numBytesRequested: 256 / 8));

				Console.WriteLine($"Hashed: {hashedPassword}");
				
				
				//add User to the database
				_context.Users.Add(new User { Nom = model.Nom, Prenom = model.Prenom, Email = model.Email, Adresse = model.Adresse, Password = hashedPassword, NumeroTelephone = model.NumeroTelephone , Role = Role.ADHERANT });
				await _context.SaveChangesAsync();

				//redirect to the login page
				return RedirectToAction("Login", "User");
			}
			//   return View(model)
			return Ok("Utilisateur enregistré");
			

		}
	



	} }

