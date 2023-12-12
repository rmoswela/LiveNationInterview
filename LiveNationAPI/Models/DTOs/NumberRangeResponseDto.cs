namespace LiveNationAPI;

/// <summary>
/// Model that represent a response to a range of numbers query.
/// </summary>
public class NumberRangeResponseDto
{
    /// <summary>
    /// Summary of all the results joined together.
    /// </summary>
    public string Result { get; set; }

    /// <summary>
    /// Summary of all the results catergorized by the rules.
    /// </summary>
    public Summary Summary { get; set; }
}


public class Summary
{
    public string Live { get; set; }
    public string Nation { get; set; }
    public string LiveNation { get; set; }
    public string Integer { get; set; }
}
