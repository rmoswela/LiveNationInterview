using System.ComponentModel.DataAnnotations;

namespace LiveNationAPI;

/// <summary>
/// Model that represents the starting and ending number of the range.
/// </summary>
public class NumberRangeRequestDto
{
    /// <summary>
    /// This is the start number of the range.
    /// </summary>
    [Required]
    public uint From { get; set; }
    /// <summary>
    /// This is the end number of the range.
    /// </summary>
    [Required]
    public uint To { get; set; }
}
