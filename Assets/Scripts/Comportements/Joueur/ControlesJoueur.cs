using UnityEngine;
using Zenject;

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

    [Inject] private readonly EtatsJeu _etatsJeu;

    private Joueur joueur;

    private Evenements evenements;

    /// <summary>
    /// Initialise des composants nécessaires dans d'autres scripts.
    /// </summary>
    private void Awake()
    {
        joueur = GetComponent<Joueur>();
    }

    /// <summary>
    /// Assignement de la logique métier et des évènements.
    /// </summary>
    private void Start()
    {

        evenements = Evenements.GetInstanceEvenements();

        // Evènements déclenchés par le pilote.
        evenements.OnSourisClicEnfonce += OnSourisClicEnfonce;
        evenements.OnSourisClicRelache += OnSourisClicRelache;
    }

    private void OnSourisClicEnfonce(bool estEnEnfoncementSansGlissement)
    {

        if (!_etatsJeu.SontMouvementsBloquees)
        {

            if (estEnEnfoncementSansGlissement)
            {
                joueur.PhysiqueJoueur.Freiner();
            }
            else
            {
                joueur.PhysiqueJoueur.AnnulerFreinage();
            }
        }
    }

    private void OnSourisClicRelache(Vector2 directionGlissement)
    {

        if (!_etatsJeu.SontMouvementsBloquees)
        {
            joueur.PhysiqueJoueur.Propulser(directionGlissement);
        }
    }
}
