using UnityEngine;

/// <summary>
/// 
/// Contrôle les mouvements du personnage
/// commandés par le joueur.
/// 
/// Trois commandes :
/// - Clic enfoncé sans glisser : le joueur freine;
/// - Clic simple : le joueur effectue une parade;
/// - Glisser souris en enfonçant : le joueur se propulse.
/// 
/// </summary>
public class ControlesJoueur : MonoBehaviour
{

    /// <summary>
    /// Logique pour mouvoir le joueur.
    /// </summary>
    public PhysiqueJoueur physiqueJoueur;

    private EtatsJeu etatsJeu;
    private Evenements evenements;

    /// <summary>
    /// Initialise des composants nécessaires dans d'autres scripts.
    /// </summary>
    private void Awake()
    {
        physiqueJoueur = new(GetComponent<Rigidbody2D>());
    }

    /// <summary>
    /// Assignement de la logique métier et des évènements.
    /// </summary>
    private void Start()
    {

        etatsJeu = EtatsJeu.GetInstanceEtatsJeu();
        evenements = Evenements.GetInstanceEvenements();

        // Evènements déclenchés par le pilote.
        evenements.OnSourisClicEnfonce += OnSourisClicEnfonce;
        evenements.OnSourisClicRelache += OnSourisClicRelache;
    }

    private void OnSourisClicEnfonce(bool estEnEnfoncementSansGlissement)
    {

        if (!etatsJeu.SontMouvementsBloquees)
        {

            if (estEnEnfoncementSansGlissement)
            {
                physiqueJoueur.Freiner();
            }
            else
            {
                physiqueJoueur.AnnulerFreinage();
            }
        }
    }

    private void OnSourisClicRelache(Vector2 directionGlissement)
    {

        if (!etatsJeu.SontMouvementsBloquees)
        {
            physiqueJoueur.Propulser(directionGlissement);
        }
    }
}
