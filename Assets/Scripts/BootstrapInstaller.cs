using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public Vector3 startPos;
    public GameObject spherePrefab;
    public Transform parentSpheres;
    public GameController gameController;

   public override void InstallBindings()
    {
        InstantiateSphere();
    }
    

    private void InstantiateSphere()
    {
        SphereBehaviour sphereBehaviour = Container.InstantiatePrefabForComponent<SphereBehaviour>(spherePrefab, startPos, Quaternion.identity, parentSpheres);
        Container.Bind<SphereBehaviour>().FromInstance(sphereBehaviour).AsSingle();
    }
}