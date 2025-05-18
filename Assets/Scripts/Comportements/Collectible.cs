using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

/// <summary>
/// Comportement d'un collectible
/// </summary>
public class Collectible : MonoBehaviour
{

    /// <summary>
    /// Marge sur laquelle le collectible 
    /// est presque en train de dispara�tre.
    /// </summary>
    private const float TempsSurLePointDeDisparaitre = 5.0f;

    /// <summary>
    /// Dur�e du collectible avant de dispara�tre.
    /// </summary>
    public float dureeApparition;

    /// <summary>
    /// Nombre de points gagn�s lors de la collection de l'objet.
    /// </summary>
    public long nombrePointsCollection;

    /// <summary>
    /// S'active si le collectible est sur le point de dispara�tre.
    /// </summary>
    private bool estEnDisparition;

    /// <summary>
    /// Permet de manipuler le score.
    /// </summary>
    private ControleurScore controleurScore;

    /// <summary>
    /// Contr�le la disparition de l'objet.
    /// </summary>
    private DisparitionEntite controleurDisparitionEntite;

    /// <summary>
    /// Sprite du collectible.
    /// </summary>
    private SpriteRenderer spriteCollectible;

    /// <summary>
    /// Animation (� assigner) lors de la disparition du collectible.
    /// </summary>
    private Tween animationDisparition;

    /// <summary>
    /// R�cup�re le gestionnaire du score.
    /// </summary>
    private void Start()
    {

        estEnDisparition = false;

        controleurScore = GestionJeuUtils.GetScriptGestionJeu().controleurScore;
        controleurDisparitionEntite = new DisparitionEntite(gameObject, dureeApparition);

        spriteCollectible = GetComponent<SpriteRenderer>();

        animationDisparition = spriteCollectible.DOFade(0f, 0.2f)
        .SetLoops(DoTweenUtils.CalculerCyclesLoopYoyo(TempsSurLePointDeDisparaitre, 0.2f), LoopType.Yoyo).Pause();
    }

    /// <summary>
    /// Se d�clenche lorsque le joueur r�cup�re le collectible.
    /// </summary>
    /// <param name="collision">L'objet en collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag.Equals(TagLayers.TagJoueur)) 
        {
            controleurScore.Ajouter(nombrePointsCollection);
            animationDisparition.Kill(); // On annule la possible animation avant de d�truire l'objet.
            Object.Destroy(gameObject);
        }
    }

    /// <summary>
    /// Met � jour le timer pour la disparition de l'entit�.
    /// </summary>
    private void FixedUpdate()
    {

        controleurDisparitionEntite.Update();
        if (!estEnDisparition && controleurDisparitionEntite.GetPeriodeVie() 
            < TempsSurLePointDeDisparaitre)
        {
            estEnDisparition = true;
            animationDisparition.Play();
        }
    }
}
