﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LireEnLigne.Data;
using LireEnLigne.Views.User;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace LireEnLigne.Controllers
{
	public class UserController : Controller
	{
		private readonly LibraryContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public UserController(LibraryContext context, IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
			_httpContextAccessor = httpContextAccessor;
		}

		public IActionResult Login()
		{

			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			return View();

		}


		public IActionResult Register()
		{

			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			return View();


		}


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {


            if (ModelState.IsValid)
            {
                //retrieve user from database based on the entered username
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);




                // Comparez enteredPasswordHash avec le hachage stocké dans la base de données
                // Si les hachages correspondent, le mot de passe est valide

                if (user != null)
                {
                    //var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    //verify the hashed password
                    // Vérification du mot de passe lors de la connexion

                    string userStoredPassword = user.Password;
                    byte[] storedSalt = user.Salt;// Récupérez le salt correspondant à l'utilisateur depuis la base de données
                                                  //byte[] saltBytes = Encoding.ASCII.GetBytes(storedSalt);
                                                  //convertir le mot de passe saisi par l'utilisateur
                                                  // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)

                    string userPasswordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: model.Password!,
                        salt: storedSalt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000, numBytesRequested: 256 / 8));


                    if (userStoredPassword == userPasswordHash)
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
                    else
                    {
                        ModelState.AddModelError(string.Empty, "password doesn't match");
                    }

                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password");


                }



            }
            return View(model);

        }



        [HttpPost]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{

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
																	   //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
																	   //	String convertedSalt = Convert.ToBase64String(salt);

				// derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
				string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: model.Password!,
					salt: salt,
					prf: KeyDerivationPrf.HMACSHA256,
					iterationCount: 100000,
					numBytesRequested: 256 / 8));

				//Console.WriteLine($"Hashed: {hashedPassword}");


				//add User to the database
				_context.Users.Add(new User { Nom = model.Nom, Prenom = model.Prenom, Email = model.Email, Adresse = model.Adresse, Password = hashedPassword, NumeroTelephone = model.NumeroTelephone, Role = Role.ADHERANT, Salt = salt });
				await _context.SaveChangesAsync();

				//redirect to the login page
				return RedirectToAction("Login", "User");
			}
			//   return View(model)
			return Ok("Utilisateur enregistré");


		}

		//déconnexion | perform log out
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}


		//get current user
		//get current logged in user

		/*  public User GetCurrentUser()
		  {
			  var claimsIdentity = (ClaimsIdentity)User.Identity;
			  var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

			  if (claim == null || !int.TryParse(claim.Value, out int userId))
			  {
				  return null;
			  }

			  var user = _context.Users.FirstOrDefault(u => u.Id == userId);

			  return user;
		  }*/

		public User GetCurrentUser()
		{
			// Get the current HttpContext
			HttpContext currentContext = _httpContextAccessor.HttpContext;

			// Check if there is an authenticated user
			if (currentContext.User.Identity?.IsAuthenticated == true)
			{
				// Get the username
				string username = currentContext.User.Identity.Name;
				//chercher l'utilisateur 

				var user = _context.Users.FirstOrDefault(u => u.Email == username);
				return user;
			}
			return null;




		}
	}
}

