using Benchmark._Context;
using BenchmarkDotNet.Attributes;

namespace Benchmark.Benchmarks.CreateEntity;

[ArtifactsPath(".benchmark_results/" + nameof(CreateEntityWith2Components<T>))]
[BenchmarkCategory(Categories.PerInvocationSetup)]
[MemoryDiagnoser]
#if CHECK_CACHE_MISSES
[HardwareCounters(BenchmarkDotNet.Diagnosers.HardwareCounter.CacheMisses)]
#endif
public class CreateEntityWith2Components<T> : BenchmarkBase<T> where T : BenchmarkContextBase, new()
{
    private object _entitySet;

    protected override void OnSetup()
    {
        base.OnSetup();
        _entitySet = Context.PrepareSet(EntityCount);
        Context.Warmup<Component1, Component2>(0);
    }

    [Benchmark]
    public void UseCache()
    {
        Context.Lock();
        Context.CreateEntities<Component1, Component2>(_entitySet, 0);
        Context.Commit();
    }

    [Benchmark]
    public void NoCache()
    {
        Context.Lock();
        Context.CreateEntities<Component1, Component2>(_entitySet);
        Context.Commit();
    }
}