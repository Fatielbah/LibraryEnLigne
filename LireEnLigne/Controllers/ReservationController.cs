using Microsoft.AspNetCore.Mvc;

namespace LireEnLigne.Controllers
{
    public class ReservationController : Controller
    {
        private readonly LibraryContext _context;

        public ReservationController(LibraryContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        //demander une reservation
        //la réservation se fait pour un exemplaire d'un livre et non pas du livre lui meme

        public async Task<IActionResult> DemanderReservation(int exemplaireId)
        {
          //  return View();
            //récupérer l'utilisateur qui est actuellement connecté

            

            //tester si l'utilisateur n'est pas connecté
            if (!(User.Identity.IsAuthenticated))
            {
                //redirection vers la page de connection

                return RedirectToAction("Login", "User");
            }
            
            var currentUser = HttpContext.User;

            //On doit trouver l'exemplaire qu'on veut réserver

            var exemplaire = await _context.Exemplaires.Include(e => e.Reservations)
                                           .FirstOrDefaultAsync(e => e.ExemplaireID == exemplaireId);

            //vérifier l'exemplaire
            if(exemplaire == null)
            {
                //Le cas où l'exemplaire n'est pas trouvé 
                return NotFound();
            }

            //Vérifier si l'exemplaire est disponible pour une réservation
            if(exemplaire.Status == Status.DISPONIBLE && exemplaire.Reservations?.Count == 0) {

                //Dans ce créer une nouvelle réservation de cette exemplaire pour l'utilisateur
                var newReservation = new Reservation
                {
                    DateDemande = DateTime.Now,
                    DateReservation = DateTime.Now,
                    ExemplaireID = exemplaire.ExemplaireID,
                    //   UserID = currentUser.UserId;
                    //a fixer
                };
                //Enregistrer la réservation 
                _context.Reservations.Add(newReservation);
                await _context.SaveChangesAsync();
                //modifier le status de l'exemplaire pour dire qu'il est déjà réservé
                exemplaire.Status = Status.RESERVE;
                await _context.SaveChangesAsync(); //pour enregistrer la modification
                //On doit envoyer un email avec redirection vers la page d'acceuil
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Le cas où l'exemplaire n'est pas disponible 
                // developper 
               //Je dois aussi verifier les dates d'emprunt d'un livre 
                return NotFound();
            }
            

        }


    }
}
