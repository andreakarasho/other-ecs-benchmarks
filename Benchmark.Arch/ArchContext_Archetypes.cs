﻿using Arch.Core;
using Arch.Core.Extensions;
using Arch.Core.Utils;
using Arch.System;
using Benchmark._Context;
// ReSharper disable ForCanBeConvertedToForeach

namespace Benchmark.Arch;

public class ArchContext_Archetypes : BenchmarkContextBase
{
    private int _entityCount;
    private World? _world;
    private Dictionary<int, ComponentType[]>? _archetypes;
    private Dictionary<int, QueryDescription>? _queries;
    private List<Action<float>>? _systems; 
    
    public override int EntityCount => _world!.Size;

    public override void Setup(int entityCount)
    {
        _entityCount = entityCount;
        _world = World.Create();
        _archetypes = new Dictionary<int, ComponentType[]>();
        _queries = new Dictionary<int, QueryDescription>();
        _systems = new List<Action<float>>();
    }

    public override void Cleanup()
    {
        _world?.Clear();
        _world?.Dispose();
        _world = null;
    }

    public override void Lock()
    {
        /* no op */
    }

    public override void Commit()
    {
        /* no op */
    }

    public override void Warmup<T1>(int poolId)
    {
        _archetypes![poolId] = [typeof(T1)];
        _queries![poolId] = new QueryDescription().WithAll<T1>();
        _world!.Reserve(_archetypes[poolId], _entityCount);
    }

    public override void Warmup<T1, T2>(int poolId)
    {
        _archetypes![poolId] = [typeof(T1), typeof(T2)];
        _queries![poolId] = new QueryDescription().WithAll<T1, T2>();
        _world!.Reserve(_archetypes[poolId], _entityCount);
    }

    public override void Warmup<T1, T2, T3>(int poolId)
    {
        _archetypes![poolId] = [typeof(T1), typeof(T2), typeof(T3)];
        _queries![poolId] = new QueryDescription().WithAll<T1, T2, T3>();
        _world!.Reserve(_archetypes[poolId], _entityCount);
    }

    public override void Warmup<T1, T2, T3, T4>(int poolId)
    {
        _archetypes![poolId] = [typeof(T1), typeof(T2), typeof(T3), typeof(T4)];
        _queries![poolId] = new QueryDescription().WithAll<T1, T2, T3, T4>();
        _world!.Reserve(_archetypes[poolId], _entityCount);
    }

    public override void CreateEntities(in object entitySet)
    {
        var entities = (Entity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
            entities[i] = _world!.Create();
    }

    public override void CreateEntities<T1>(in object entitySet, in int poolId = -1, in T1 c1 = default)
    {
        var entities = (Entity[])entitySet;
        var archetype = _archetypes![poolId];
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i] = _world!.Create(archetype);
            entities[i].Add(c1);
        }
    }

    public override void CreateEntities<T1, T2>(in object entitySet, in int poolId = -1, in T1 c1 = default, in T2 c2 = default)
    {
        var entities = (Entity[])entitySet;
        var archetype = _archetypes![poolId];
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i] = _world!.Create(archetype);
            entities[i].Add(c1, c2);
        }
    }

    public override void CreateEntities<T1, T2, T3>(in object entitySet, in int poolId = -1, in T1 c1 = default, in T2 c2 = default, in T3 c3 = default)
    {
        var entities = (Entity[])entitySet;
        var archetype = _archetypes![poolId];
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i] = _world!.Create(archetype);
            entities[i].Add(c1, c2, c3);
        }
    }

    public override void CreateEntities<T1, T2, T3, T4>(in object entitySet, in int poolId = -1, in T1 c1 = default, in T2 c2 = default, in T3 c3 = default, in T4 c4 = default)
    {
        var entities = (Entity[])entitySet;

        var archetype = _archetypes![poolId];
        for (var i = 0; i < entities.Length; i++)
        {
            entities[i] = _world!.Create(archetype);
            entities[i].Add(c1, c2, c3, c4);
        }

    }

    public override void DeleteEntities(in object entitySet)
    {
        var entities = (Entity[])entitySet;
        for (var i = 0; i < entities.Length; i++)
            _world!.Destroy(entities[i]);
    }

    public override void AddComponent<T1>(in object entitySet, in int poolId = -1, in T1 c1 = default)
    {
        var entities = (Entity[])entitySet;
        var archetype = _archetypes![poolId];

        for (var i = 0; i < entities.Length; i++)
        {
            _world!.AddRange(entities[i], archetype);
            _world!.Set(entities[i], c1);
        }

    }

    public override void AddComponent<T1, T2>(in object entitySet, in int poolId = -1, in T1 c1 = default, in T2 c2 = default)
    {
        var entities = (Entity[])entitySet;
        var archetype = _archetypes![poolId];
        for (var i = 0; i < entities.Length; i++)
        {
            _world!.AddRange(entities[i], archetype);
            _world!.Set(entities[i], c1, c2);
        }
    }

    public override void AddComponent<T1, T2, T3>(in object entitySet, in int poolId = -1, in T1 c1 = default, in T2 c2 = default, in T3 c3 = default)
    {
        var entities = (Entity[])entitySet;
        var archetype = _archetypes![poolId];
        for (var i = 0; i < entities.Length; i++)
        {
            _world!.AddRange(entities[i], archetype);
            _world!.Set(entities[i], c1, c2, c3);
        }
    }

    public override void AddComponent<T1, T2, T3, T4>(in object entitySet, in int poolId = -1, in T1 c1 = default, in T2 c2 = default, in T3 c3 = default, in T4 c4 = default)
    {
        var entities = (Entity[])entitySet;
        var archetype = _archetypes![poolId];
        for (var i = 0; i < entities.Length; i++)
        {
            _world!.AddRange(entities[i], archetype);
            _world!.Set(entities[i], c1, c2, c3, c4);
        }
    }

    public override void RemoveComponent<T1>(in object entitySet, in int poolId = -1)
    {
        var entities = (Entity[])entitySet;
        var archetype = _archetypes![poolId];
        for (var i = 0; i < entities.Length; i++)
            _world!.RemoveRange(entities[i], archetype);
    }

    public override void RemoveComponent<T1, T2>(in object entitySet, in int poolId = -1)
    {
        var entities = (Entity[])entitySet;
        var archetype = _archetypes![poolId];
        for (var i = 0; i < entities.Length; i++)
            _world!.RemoveRange(entities[i], archetype);
    }

    public override void RemoveComponent<T1, T2, T3>(in object entitySet, in int poolId = -1)
    {
        var entities = (Entity[])entitySet;
        var archetype = _archetypes![poolId];
        for (var i = 0; i < entities.Length; i++)
            _world!.RemoveRange(entities[i], archetype);
    }

    public override void RemoveComponent<T1, T2, T3, T4>(in object entitySet, in int poolId = -1)
    {
        var entities = (Entity[])entitySet;
        var archetype = _archetypes![poolId];
        for (var i = 0; i < entities.Length; i++)
            _world!.RemoveRange(entities[i], archetype);
    }

    public override int CountWith<T1>(int poolId) => _world!.CountEntities(_queries![poolId]);
    public override int CountWith<T1, T2>(int poolId) => _world!.CountEntities(_queries![poolId]);
    public override int CountWith<T1, T2, T3>(int poolId) => _world!.CountEntities(_queries![poolId]);
    public override int CountWith<T1, T2, T3, T4>(int poolId) => _world!.CountEntities(_queries![poolId]);
    
    public override void Tick(float delta)
    {
        foreach (var system in _systems!)
            system(delta);
    }

    public override unsafe void AddSystem<T1>(delegate*<ref T1, void> method, int poolId)
    {
        var system = new System<T1>(method);
        _systems!.Add(_ => system.ForEachQuery(_world!));
    }

    public override unsafe void AddSystem<T1, T2>(delegate*<ref T1, ref T2, void> method, int poolId)
    {
        var system = new System<T1, T2>(method);
        _systems!.Add(_ => system.ForEachQuery(_world!));
    }

    public override unsafe void AddSystem<T1, T2, T3>(delegate*<ref T1, ref T2, ref T3, void> method, int poolId)
    {
        var system = new System<T1, T2, T3>(method);
        _systems!.Add(_ => system.ForEachQuery(_world!));
    }

    public override unsafe void AddSystem<T1, T2, T3, T4>(delegate*<ref T1, ref T2, ref T3, ref T4, void> method, int poolId)
    {
        var system = new System<T1, T2, T3, T4>(method);
        _systems!.Add(_ => system.ForEachQuery(_world!));
    }

    public override object Shuffle(in object entitySet)
    {
        Random.Shared.Shuffle((Entity[])entitySet);
        return entitySet;
    }

    public override object PrepareSet(in int count) => new Entity[count];


}