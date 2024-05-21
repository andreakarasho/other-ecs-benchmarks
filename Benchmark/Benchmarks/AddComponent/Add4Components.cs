using Benchmark._Context;
using BenchmarkDotNet.Attributes;

namespace Benchmark.Benchmarks.AddComponent;

[BenchmarkCategory(Categories.PerInvocationSetup)]
[ArtifactsPath(".benchmark_results/" + nameof(Add4Components<T>))]
[MemoryDiagnoser]
#if CHECK_CACHE_MISSES
[HardwareCounters(BenchmarkDotNet.Diagnosers.HardwareCounter.CacheMisses)]
#endif
public class Add4Components<T> : AddComponentBase<T> where T : BenchmarkContextBase, new()
{
    protected override void OnSetup()
    {
        base.OnSetup();
        Context.Warmup<Component1, Component2, Component3, Component4>(0);
    }

    protected override void OnCleanup()
    {
        base.OnCleanup();
        Context.RemoveComponent<Component1, Component2, Component3, Component4>(EntitySet, 0);
    }

    [Benchmark]
    public void UseCache()
    {
        Context.Lock();
        Context.AddComponent<Component1, Component2, Component3, Component4>(EntitySet, 0);
        Context.Commit();
    }

    [Benchmark]
    public void NoCache()
    {
        Context.Lock();
        Context.AddComponent<Component1, Component2, Component3, Component4>(EntitySet);
        Context.Commit();
    }
}