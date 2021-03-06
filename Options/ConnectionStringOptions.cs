namespace Darwin.Options;

public class ConnectionStringOptions
{
    public const string SectionName = "ConnectionStrings";

    public string PostgresLocal { get; set; } = null!;

    public string PostgresProd { get; set; } = null!;
}