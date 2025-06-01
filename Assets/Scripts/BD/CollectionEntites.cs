using UnityEngine;

/// <summary>
/// Rassemble une collection d'entit�s avec leurs propri�t�s.
/// </summary>
[CreateAssetMenu(fileName = "CollectionEntites", menuName = "Scriptable Objects/CollectionEntites")]
public class CollectionEntites : ScriptableObject
{

    /// <summary>
    /// Repr�sente les propri�t�s d'une entit�.
    /// </summary>
    public struct Entite
    {
        public GameObject entite;
        public string nom;
        public float frequenceApparition;
    }

    // ======= D�finition des GameObject =======

    // /!\ � d�finir /!\

    // Joueur
    public GameObject _joueur;

    // Collectibles
    public GameObject _collectiblePiece;
    public GameObject _collectibleTriplePiece;

    // Projectiles
    public GameObject _projectilePicPropulsion;

    // ======= D�finition des propri�t�s =======

    public Entite joueur;

    public Entite collectiblePiece;
    public Entite collectibleTriplePiece;

    public Entite projectilePicPropulsion;

    public EntitesGroupeStructure collectibles;
    public EntitesGroupeStructure projectiles;

    /// <summary>
    /// Initialise les �l�ments r�f�renc�es manuellement.
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

        // Cr�ation des groupes ici

        collectibles = new();
        projectiles = new();

        collectibles.AjouterEntite(collectiblePiece.nom, collectiblePiece.frequenceApparition);
        collectibles.AjouterEntite(collectibleTriplePiece.nom, collectibleTriplePiece.frequenceApparition);

        projectiles.AjouterEntite(projectilePicPropulsion.nom, projectilePicPropulsion.frequenceApparition);
    }
}
