using System;
using System.Collections.Generic;

namespace ProjektZaliczeniowy.Models.Movies;

public partial class Country
{
    public int CountryId { get; set; }

    public string? CountryIsoCode { get; set; }

    public string? CountryName { get; set; }
}
