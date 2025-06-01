using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Fait apparaître les entités dans la carte au bon moment,
/// et selon l'état du jeu.
/// </summary>
public class ControleurApparitionEntites : MonoBehaviour
{

    /// <summary>
    /// Délais avant que le jeu regarde les entités à faire apparaître.
    /// </summary>
    private const float TempsAttenteUsine = 1.0f;

    /// <summary>
    /// La map où les entités vont apparaître.
    /// </summary>
    public Tilemap map;

    private CreateurEntites usineEntites;
    private MapVirtuelle mapVirtuelle;

    private EntitesPoolGroupe collectiblesPool;

    private StructureGroupeEntites groupeCollectible;

    private PrefabsBD prefabsBD;

    /// <summary>
    /// Initialise les composants pour repérer la map.
    /// </summary>
    private void Start()
    {

        mapVirtuelle = new(map, 3.0f);
        usineEntites = new(mapVirtuelle);

        prefabsBD = Resources.Load<PrefabsBD>(nameof(PrefabsBD));

        collectiblesPool = new(200);
        collectiblesPool.InstancierTypeEntites(3, "piece", prefabsBD.collectiblePiece);
        collectiblesPool.InstancierTypeEntites(5, "triple_piece", prefabsBD.collectibleTriplePiece);

        groupeCollectible = new();
        groupeCollectible.AjouterEntite("piece", .7f);
        groupeCollectible.AjouterEntite("triple_piece", .3f);

        // On crée le joueur
        usineEntites.CreerEntite(prefabsBD.joueur, mapVirtuelle.GetCentreMap());
        IterationTournageUsine();
    }

    /// <summary>
    /// Nouveau cycle afin de vérifier les entités à créer.
    /// </summary>
    private void IterationTournageUsine()
    {
        Invoke(nameof(SousIterationCollectibles), Aleatoire.ChoisirNombreParmisPlage(5f, 25f, 1.1f));
    }

    private void SousIterationCollectibles()
    {

        GameObject collectible = collectiblesPool.GetInstanceTypeEntiteNonActif(groupeCollectible.ChoisirEntiteAleatoirement());
        if (collectible != null)
        {
            collectible.transform.position = Aleatoire.ChoisirPointParmisDeuxAxes(mapVirtuelle.GetCoordonneesIntervallesX(), mapVirtuelle.GetCoordonneesIntervallesY());
            collectible.SetActive(true);
        }

        Invoke(nameof(SousIterationCollectibles), Aleatoire.ChoisirNombreParmisPlage(5f, 10f));
    }
}
