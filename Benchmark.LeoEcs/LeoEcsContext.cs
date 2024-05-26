using Benchmark._Context;
using Leopotam.Ecs;
using EcsWorld = Leopotam.Ecs.EcsWorld;

namespace Benchmark.LeoEcs;

public class LeoEcsContext : BenchmarkContextBase
{
    private EcsWorld? _world;
    private List<EcsSystems>? _systems;

    public override int EntityCount => _world!.GetStats().ActiveEntities;
    
    public override void Setup(int entityCount)
    {
        _world = new EcsWorld();
        _systems = new List<EcsSystems>();
    }

    public override void Warmup<T1>(int poolId) { }

    public override void Warmup<T1, T2>(int poolId) { }

    public override void Warmup<T1, T2, T3>(int poolId) { }

    public override void Warmup<T1, T2, T3, T4>(int poolId) { }

    public override void Cleanup()
    {
        _world!.Destroy();
        _world = null;
    }

    public override void Lock()
    {
        // no op
    }

    public override void Commit()
    {
        // no op
    }

    public override void CreateEntities(in object entitySet)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
            entities[i] = _world!.NewEntity();
    }

    public override void CreateEntities<T1>(in object entitySet, in int poolId = -1, in T1 c1 = default)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i] = _world!.NewEntity();
            entities[i].Replace(c1);
        }
    }

    public override void CreateEntities<T1, T2>(in object entitySet, in int poolId = -1, in T1 c1 = default, in T2 c2 = default)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i] = _world!.NewEntity();
            entities[i].Replace(c1);
            entities[i].Replace(c2);
        }
    }

    public override void CreateEntities<T1, T2, T3>(in object entitySet, in int poolId = -1, in T1 c1 = default, in T2 c2 = default, in T3 c3 = default)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i] = _world!.NewEntity();
            entities[i].Replace(c1);
            entities[i].Replace(c2);
            entities[i].Replace(c3);
        }
    }

    public override void CreateEntities<T1, T2, T3, T4>(in object entitySet, in int poolId = -1, in T1 c1 = default, in T2 c2 = default, in T3 c3 = default, in T4 c4 = default)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i] = _world!.NewEntity();
            entities[i].Replace(c1);
            entities[i].Replace(c2);
            entities[i].Replace(c3);
            entities[i].Replace(c4);
        }
    }

    public override void DeleteEntities(in object entitySet)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
            entities[i].Destroy();
    }

    public override void AddComponent<T1>(in object entitySet, in int poolId = -1, in T1 c1 = default)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
            entities[i].Replace(c1);
    }

    public override void AddComponent<T1, T2>(in object entitySet, in int poolId = -1, in T1 c1 = default, in T2 c2 = default)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i].Replace(c1);
            entities[i].Replace(c2);
        }
    }

    public override void AddComponent<T1, T2, T3>(in object entitySet, in int poolId = -1, in T1 c1 = default, in T2 c2 = default, in T3 c3 = default)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i].Replace(c1);
            entities[i].Replace(c2);
            entities[i].Replace(c3);
        }
    }

    public override void AddComponent<T1, T2, T3, T4>(in object entitySet, in int poolId = -1, in T1 c1 = default, in T2 c2 = default, in T3 c3 = default, in T4 c4 = default)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i].Replace(c1);
            entities[i].Replace(c2);
            entities[i].Replace(c3);
            entities[i].Replace(c4);
        }
    }

    public override void RemoveComponent<T1>(in object entitySet, in int poolId = -1)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
            entities[i].Del<T1>();
    }

    public override void RemoveComponent<T1, T2>(in object entitySet, in int poolId = -1)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i].Del<T1>();
            entities[i].Del<T2>();
        }
    }

    public override void RemoveComponent<T1, T2, T3>(in object entitySet, in int poolId = -1)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i].Del<T1>();
            entities[i].Del<T2>();
            entities[i].Del<T3>();
        }
    }

    public override void RemoveComponent<T1, T2, T3, T4>(in object entitySet, in int poolId = -1)
    {
        var entities = (EcsEntity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i].Del<T1>();
            entities[i].Del<T2>();
            entities[i].Del<T3>();
            entities[i].Del<T4>();
        }
    }

    public override int CountWith<T1>(int poolId) => _world!.GetFilter(typeof(EcsFilter<T1>)).GetEntitiesCount();

    public override int CountWith<T1, T2>(int poolId) => _world!.GetFilter(typeof(EcsFilter<T1, T2>)).GetEntitiesCount();

    public override int CountWith<T1, T2, T3>(int poolId) => _world!.GetFilter(typeof(EcsFilter<T1, T2, T3>)).GetEntitiesCount();

    public override int CountWith<T1, T2, T3, T4>(int poolId) => _world!.GetFilter(typeof(EcsFilter<T1, T2, T3, T4>)).GetEntitiesCount();
    public override void Tick(float delta)
    {
        foreach (var system in _systems!)
            system.Run();
    }
    
    public override unsafe void AddSystem<T1>(delegate*<ref T1, void> method, int poolId)
        => _systems!.Add(new EcsSystems(_world).Add(new System<T1>(method)).ProcessInjects());

    public override unsafe void AddSystem<T1, T2>(delegate*<ref T1, ref T2, void> method, int poolId)
        => _systems!.Add(new EcsSystems(_world).Add(new System<T1, T2>(method)).ProcessInjects());

    public override unsafe void AddSystem<T1, T2, T3>(delegate*<ref T1, ref T2, ref T3, void> method, int poolId)
        => _systems!.Add(new EcsSystems(_world).Add(new System<T1, T2, T3>(method)).ProcessInjects());

    public override unsafe void AddSystem<T1, T2, T3, T4>(delegate*<ref T1, ref T2, ref T3, ref T4, void> method, int poolId)
        => _systems!.Add(new EcsSystems(_world).Add(new System<T1, T2, T3, T4>(method)).ProcessInjects());

    public override object Shuffle(in object entitySet)
    {
        Random.Shared.Shuffle((EcsEntity[])entitySet);
        return entitySet;
    }

    public override object PrepareSet(in int count)
    {
        return new EcsEntity[count];
    }
}

