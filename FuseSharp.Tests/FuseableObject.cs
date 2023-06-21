namespace FuseSharp.Tests;

internal class FuseableObject : IFuseable
{
    public FuseableObject(string title, string description)
    {
        Title = title;
        Subheader = description;
    }

    public string Title { get; }

    public string Subheader { get; }

    public IEnumerable<FuseProperty> Properties
    {
        get
        {
            yield return new(Title, 0.67);
            yield return new(Subheader, 0.33);
        }
    }

    public override string ToString() => Title + (Subheader != null ? " - " + Subheader : string.Empty);
}
