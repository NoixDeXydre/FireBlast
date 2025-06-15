using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rassemble plusieurs menus de chargement.
/// </summary>
[CreateAssetMenu(fileName = "CollectionEcransChargement", menuName = "EcransChargement/CollectionEcransChargement")]
public class CollectionEcransChargement : ScriptableObject
{

    /// <summary>
    /// Compile les écrans de chargement.
    /// </summary>
    public List<GameObject> ecransChargement;
}
