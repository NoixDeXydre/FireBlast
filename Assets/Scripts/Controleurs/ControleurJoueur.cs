using UnityEngine;

/// <summary>
/// 
/// Contr�le les mouvements du personnage
/// command�s par le joueur.
/// 
/// Trois commandes :
/// - Clic enfonc� sans glisser : le joueur freine;
/// - Clic simple : le joueur effectue une parade;
/// - Glisser souris en enfon�ant : le joueur se propulse.
/// 
/// </summary>
public class ControleurJoueur : MonoBehaviour
{

    /// <summary>
    /// Pilote permettant de capturer les clics de la souris.
    /// </summary>
    public ControleurSouris scriptPiloteSouris;

    /// <summary>
    /// Logique pour mouvoir le joueur.
    /// </summary>
    private PhysiqueJoueur physiqueJoueur;

    /// <summary>
    /// Assignement de la logique m�tier et des �v�nements.
    /// </summary>
    private void Start()
    {

        physiqueJoueur = GestionJeuUtils.GetScriptGestionJeu().physiqueJoueur;

        // Ev�nements d�clench�s par le pilote.
        scriptPiloteSouris.SourisClicEnfonce += OnSourisClicEnfonce;
        scriptPiloteSouris.SourisClicRelache += OnSourisClicRelache;
    }

    private void OnSourisClicEnfonce(bool estEnEnfoncementSansGlissement)
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

    private void OnSourisClicRelache(Vector2 directionGlissement)
    {
        physiqueJoueur.Propulser(directionGlissement);
    }
}
