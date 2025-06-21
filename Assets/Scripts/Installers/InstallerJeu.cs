using UnityEngine;
using Zenject;

/// <summary>
/// D�fini les d�pendances � un injecter dans la sc�ne Jeu.
/// </summary>
public class InstallerJeu : MonoInstaller
{

    /// <summary>
    /// D�fini et injecte
    /// </summary>
    public override void InstallBindings()
    {

        // Instancie une map virtuelle afin de conna�tre les bordures.
        Container.Bind<MapVirtuelle>().FromComponentInHierarchy().AsSingle();

        Container.Bind<EntitesCreateur>().AsSingle();

        // Contr�leurs 
        Container.Bind<ControleurScore>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ControleurTemps>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ControleurVie>().FromComponentInHierarchy().AsSingle();
    }
}