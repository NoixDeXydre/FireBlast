using UnityEngine;

[CreateAssetMenu(fileName = "PrefabsBD", menuName = "Scriptable Objects/PrefabsBD")]
public class PrefabsBD : ScriptableObject
{

    // Joueur
    public GameObject joueur;

    // Collectibles
    public GameObject collectiblePiece;
    public GameObject collectibleTriplePiece;

    // Projectiles
    public GameObject projectilePicPropulsion;
}
