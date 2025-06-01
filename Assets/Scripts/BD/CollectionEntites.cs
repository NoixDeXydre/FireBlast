using UnityEngine;

/// <summary>
/// Rassemble une collection d'entités avec leurs propriétés.
/// </summary>
[CreateAssetMenu(fileName = "CollectionEntites", menuName = "Scriptable Objects/CollectionEntites")]
public class CollectionEntites : ScriptableObject
{

    /// <summary>
    /// Représente les propriétés d'une entité.
    /// </summary>
    public struct Entite
    {
        public GameObject entite;
        public string nom;
        public float frequenceApparition;
    }

    // ======= Définition des GameObject =======

    // /!\ À définir /!\

    // Joueur
    public GameObject _joueur;

    // Collectibles
    public GameObject _collectiblePiece;
    public GameObject _collectibleTriplePiece;

    // Projectiles
    public GameObject _projectilePicPropulsion;

    // ======= Définition des propriétés =======

    public Entite joueur;

    public Entite collectiblePiece;
    public Entite collectibleTriplePiece;

    public Entite projectilePicPropulsion;

    public EntitesGroupeStructure collectibles;
    public EntitesGroupeStructure projectiles;

    /// <summary>
    /// Initialise les éléments référencées manuellement.
    /// </summary>
    private void OnEnable()
    {

        // Joueur

        joueur = new()
        {
            entite = _joueur
        };

        // Collectibles

        collectiblePiece = new()
        {
            entite = _collectiblePiece,
            nom = "piece",
            frequenceApparition = .7f
        };

        collectibleTriplePiece = new()
        {
            entite = _collectibleTriplePiece,
            nom = "triple_piece",
            frequenceApparition = .3f
        };

        // Projectiles

        projectilePicPropulsion = new()
        {
            entite = _projectilePicPropulsion,
            nom = "pic"
        };

        // Création des groupes ici

        collectibles = new();
        projectiles = new();

        collectibles.AjouterEntite(collectiblePiece.nom, collectiblePiece.frequenceApparition);
        collectibles.AjouterEntite(collectibleTriplePiece.nom, collectibleTriplePiece.frequenceApparition);

        projectiles.AjouterEntite(projectilePicPropulsion.nom, projectilePicPropulsion.frequenceApparition);
    }
}
