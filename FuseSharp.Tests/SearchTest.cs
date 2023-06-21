namespace FuseSharp.Tests;

[TestClass]
public class SearchTest
{
    private readonly Fuse _fuse = new(threshold: 1.0, tokenize: false);

    private readonly IReadOnlyList<FuseableObject> _objects = new List<FuseableObject>
    {
        new("Foo", "What not to Foo"),
        new("Bar", "The Texas Bar Exam"),
        new("foobar2000", "a freeware audio player"),
    };

    [TestMethod]
    public void FlatSearch()
    {
        const string query = "fo";

        var results = _fuse
            .Search(query, _objects.Select(o => o.ToString()))
            .ToList();

        Assert.AreEqual(2, results.Count);
        Assert.AreEqual(0, results[0].Index);
        Assert.AreEqual(2, results[1].Index);
    }

    [TestMethod]
    public void FuseableSearch()
    {
        const string query = "fo";

        var results = _fuse
            .Search(query, _objects)
            .ToList();

        Assert.AreEqual(2, results.Count);
        Assert.AreEqual(0, results[0].Index);
        Assert.AreEqual(2, results[1].Index);
    }
}