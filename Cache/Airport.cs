namespace Cache;

public class Airport
{
    public string Code { get; set; }
    public string Name { get; set; }

    public Airport(string code, string name)
    {
        Code = code;
        Name = name;
    }
}