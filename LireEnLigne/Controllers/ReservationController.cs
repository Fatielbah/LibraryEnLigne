using LireEnLigne.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LireEnLigne.Controllers
{
    public class ReservationController : Controller
    {
        private readonly LibraryContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMailService _mailService;

        public ReservationController(LibraryContext context, IHttpContextAccessor httpContextAccessor, IMailService mailService)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mailService = mailService;
        }
        public IActionResult ConfirmMessage() { 
            return View();
        }
        public IActionResult ReservationIndex(int ExemplaireID)
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Redirection vers la page de connexion
                return RedirectToAction("Login", "User");
            }
            else
            {
                // Utilisez Entity Framework pour obtenir les détails de l'exemplaire et son livre associé
                var exemplaireDetails = _context.Exemplaires
                    .Include(e => e.Livre) // Charger les détails du livre associé
                    .FirstOrDefault(e => e.ExemplaireID == ExemplaireID);

                // Vérifiez si l'exemplaire a été trouvé
                if (exemplaireDetails == null)
                {
                    // Exemplaire non trouvé, peut-être redirigez vers une page d'erreur
                    return RedirectToAction("Erreur");
                }

                // Affichez les détails de l'exemplaire et son livre associé dans la vue
                return View(exemplaireDetails);
            }
        }


        //get current logged in user

        /* public User GetCurrentUser()
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

        //demander une reservation
        //la réservation se fait pour un exemplaire d'un livre et non pas du livre lui meme
        [HttpPost]
        public async Task<IActionResult> DemanderReservation(int exemplaireId, DateTime dateDemande,DateTime DateAnnulation)
        {
          //  return View();
            //récupérer l'utilisateur qui est actuellement connecté

            

            //tester si l'utilisateur n'est pas connecté
            if (!(User.Identity.IsAuthenticated))
            {
                //redirection vers la page de connection

                return RedirectToAction("Login", "User");
            }

            // var currentUser = HttpContext.User;
            var currentUser = GetCurrentUser();

            //On doit trouver l'exemplaire qu'on veut réserver

            var exemplaire = await _context.Exemplaires.Include(e => e.Reservations)
                                           .FirstOrDefaultAsync(e => e.ExemplaireID == exemplaireId);

            //vérifier l'exemplaire
            if(exemplaire == null)
            {
                //Le cas où l'exemplaire n'est pas trouvé 
                return NotFound("Exemplaire non trouvé");
            }

            //Vérifier si l'exemplaire est disponible pour une réservation
            if (exemplaire.Status != Status.DISPONIBLE || exemplaire.Reservations?.Count != 0) {
                return BadRequest("L'exemplaire que vous voulez réserver n'est pas disponble pour réservation");
            }

            //On doit vérifier que la date de réservation est valide
            //n'est pas entre la date d'emprunt et date de retour prévue

            var dateDebut = exemplaire.Emprunts?.Select(e => e.DateEmprunt).FirstOrDefault();
            var dateRetourPrevue = exemplaire.Emprunts?.Select(e => e.DateRetourPrevue).FirstOrDefault();

            if(dateDebut !=null && dateRetourPrevue != null)
            {
                if(dateDemande >= dateDebut && dateDemande <= dateRetourPrevue)
                {
                    return BadRequest("L'exemplaire est déjà emprunté pour cette date. Veuillez choisir une autre");
                }
            }
                //Dans ce créer une nouvelle réservation de cette exemplaire pour l'utilisateur
                var newReservation = new Reservation
                {
                    DateDemande = dateDemande,
                    DateReservation = DateTime.Now,
                    ExemplaireID = exemplaire.ExemplaireID,
                    UserID = currentUser.Id,
                    DateAnnulation= DateAnnulation


                };

            //ajouter la réservation ) l'exemplaire
            exemplaire.Reservations ??= new List<Reservation>();
            exemplaire.Reservations.Add(newReservation);
           
                //Enregistrer la réservation 
                _context.Reservations.Add(newReservation);
                await _context.SaveChangesAsync();
                //modifier le status de l'exemplaire pour dire qu'il est déjà réservé
                exemplaire.Status = Status.RESERVE;
            try
            {
                await _context.SaveChangesAsync(); //pour enregistrer la modification
                //On doit envoyer un email avec redirection vers la page d'acceuil
                var mailData = new MailData();
                mailData.EmailToId = currentUser.Email;
                mailData.EmailToName = currentUser.Nom;
                mailData.EmailSubject = "Demande de réservation";
                mailData.EmailBody = "Votre réservation est effectuée avec succès";
                _mailService.SendMail(mailData);
                Ok("Demande de réservation effectuée avec succès");
                

                return RedirectToAction("ConfirmMessage", "Reservation");

            }
            catch(DbUpdateException)
            {
                return StatusCode(500, "Erreur lors de sauvegarde des données");
            }
               
            }
           
            

        }


    }

