using DG.Tweening;
using UnityEngine;

/// <summary>
/// Comportement d'un collectible
/// </summary>
public class Collectible : MonoBehaviour
{

    /// <summary>
    /// Marge sur laquelle le collectible 
    /// est presque en train de disparaître.
    /// </summary>
    private const float TempsSurLePointDeDisparaitre = 5.0f;

    /// <summary>
    /// Durée du collectible avant de disparaître.
    /// </summary>
    public float dureeApparition;

    /// <summary>
    /// Nombre de points gagnés lors de la collection de l'objet.
    /// </summary>
    public long nombrePointsCollection;

    /// <summary>
    /// S'active si le collectible est sur le point de disparaître.
    /// </summary>
    private bool estEnDisparition;

    /// <summary>
    /// Permet de manipuler le score.
    /// </summary>
    private ControleurScore controleurScore;

    /// <summary>
    /// Contrôle la disparition de l'objet.
    /// </summary>
    private DisparitionEntite controleurDisparitionEntite;

    /// <summary>
    /// Sprite du collectible.
    /// </summary>
    private SpriteRenderer spriteCollectible;

    /// <summary>
    /// Récupère le gestionnaire du score.
    /// </summary>
    private void Start()
    {

        estEnDisparition = false;

        controleurScore = GestionJeuUtils.GetScriptGestionJeu().controleurScore;
        controleurDisparitionEntite = new DisparitionEntite(gameObject, dureeApparition);

        spriteCollectible = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Se déclenche lorsque le joueur récupère le collectible.
    /// </summary>
    /// <param name="collision">L'objet en collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag.Equals(TagLayers.TagJoueur)) 
        {
            controleurScore.Ajouter(nombrePointsCollection);
            Object.Destroy(gameObject);
        }
    }

    /// <summary>
    /// Met à jour le timer pour la disparition de l'entité.
    /// </summary>
    private void Update()
    {

        controleurDisparitionEntite.Update();
        if (!estEnDisparition && controleurDisparitionEntite.GetPeriodeVie() 
            < TempsSurLePointDeDisparaitre)
        {
            estEnDisparition = true;
            spriteCollectible.DOFade(0f, .2f)
                .SetLoops(DoTweenUtils.CalculerCyclesLoopYoyo(TempsSurLePointDeDisparaitre, .2f), LoopType.Yoyo);
        }
    }
}
