public class IPApiResponse
{
    public string? Ip { get; set; }
    public string? Type { get; set; }
    public string? Continent_Code { get; set; }
    public string? Continent_Name { get; set; }
    public string? Country_Code { get; set; }
    public string? Country_Name { get; set; }
    public string? Region_Code { get; set; }
    public string? Region_Name { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public Location? Location { get; set; }
    public TimeZone? TimeZone { get; set; }
    public Currency? Currency { get; set; }
    public Connection? Connection { get; set; }
}

public class Location
{
    public int Geoname_Id { get; set; }
    public string? Capital { get; set; }
    public List<Language>? Languages { get; set; }
    public string? Country_Flag { get; set; }
    public string? Country_Flag_Emoji { get; set; }
    public string? Country_Flag_Emoji_Unicode { get; set; }
    public string? Calling_Code { get; set; }
    public bool Is_Eu { get; set; }
}

public class Language
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Native { get; set; }
}

public class TimeZone
{
    public string? Id { get; set; }
    public DateTime Current_Time { get; set; }
    public int Gmt_Offset { get; set; }
    public string? Code { get; set; }
    public bool Is_Daylight_Saving { get; set; }
}

public class Currency
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Plural { get; set; }
    public string? Symbol { get; set; }
    public string? Symbol_Native { get; set; }
}

public class Connection
{
    public int Asn { get; set; }
    public string? Isp { get; set; }
}
