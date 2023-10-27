using System.Text.RegularExpressions;

public static class RoutesManager
{
    public const string BASE = "/api";

    //! Controllers
    public const string ACCES = "Acces";
    public const string ALBUM = "Album";
    public const string ARTIST = "Artist";
    public const string COMPANY = "Company";
    public const string COMPANYTYPE = "CompanyType";
    public const string CONCERT = "Concert";
    public const string FESTIVALARTISTASOC = "FestivalArtistAsoc";
    public const string FESTIVAL = "Festival";
    public const string SOCIALNETWORK = "SocialNetwork";
    public const string SONG = "Song";
    public const string USER = "User";
    public const string USERROLE = "UserRole";
    public const string YOUTUBEVIDEO = "YoutubeVideo";

    //! Metodos

    public const string CREATEREGISTER = "create-register";
    public const string KEYS = "keys";
    public const string FILTER = "filter";
    public const string FESTIVALUSERID = "festival-user-id";
    public const string CONCERTUSERID = "concert-user-id";



    //! ADMIN
    public static List<string> OnlyAdminGetRoutes = new List<string>()
    {
        $"^{BASE}/{ALBUM}$",
        $"^{BASE}/{ARTIST}$",
        $"^{BASE}/{COMPANY}$",
        $"^{BASE}/{CONCERT}$",
        $"^{BASE}/{FESTIVAL}$",
        $"^{BASE}/{SONG}$",
        $"^{BASE}/{USER}$",

        $"^{BASE}/{ARTIST}/{KEYS}$",
        $"^{BASE}/{USERROLE}/{KEYS}$",
        $"^{BASE}/{COMPANYTYPE}/{KEYS}$",
    };
    public static List<string> OnlyAdminPostRoutes = new List<string>()
    {
        $"^{BASE}/{ALBUM}$",
        $"^{BASE}/{ARTIST}/{CREATEREGISTER}$",
        $"^{BASE}/{USER}/{CREATEREGISTER}$",
        $"^{BASE}/{COMPANY}$",
        $"^{BASE}/{CONCERT}$",
        $"^{BASE}/{FESTIVAL}$",
        $"^{BASE}/{SOCIALNETWORK}$",
        $"^{BASE}/{SONG}$",
        $"^{BASE}/{USER}$",

        $"^{BASE}/{ALBUM}/{FILTER}$",
        $"^{BASE}/{ARTIST}/{FILTER}$",
        $"^{BASE}/{COMPANY}/{FILTER}$",
        $"^{BASE}/{CONCERT}/{FILTER}$",
        $"^{BASE}/{FESTIVAL}/{FILTER}$",
        $"^{BASE}/{SOCIALNETWORK}/{FILTER}$",
        $"^{BASE}/{SONG}/{FILTER}$",
        $"^{BASE}/{USER}/{FILTER}$",
    };
    public static List<string> OnlyAdminPutRoutes = new List<string>()
    {
        $"^{BASE}/{ACCES}/\\d$",
        $"^{BASE}/{ALBUM}/\\d$",
        $"^{BASE}/{ARTIST}/\\d$",
        $"^{BASE}/{COMPANY}/\\d$",
        $"^{BASE}/{CONCERT}/\\d$",
        $"^{BASE}/{FESTIVAL}/\\d$",
        $"^{BASE}/{FESTIVALARTISTASOC}/\\d$",
        $"^{BASE}/{SOCIALNETWORK}/\\d$",
        $"^{BASE}/{SONG}/\\d$",
        $"^{BASE}/{USER}/\\d$",
    };
    public static List<string> OnlyAdminDeleteRoutes = new List<string>()
    {
        $"^{BASE}/{ALBUM}/\\d$",
        $"^{BASE}/{ARTIST}/\\d$",
        $"^{BASE}/{COMPANY}/\\d$",
        $"^{BASE}/{CONCERT}/\\d$",
        $"^{BASE}/{FESTIVAL}/\\d$",
        $"^{BASE}/{SONG}/\\d$",
        $"^{BASE}/{USER}/\\d$",
    };

    public static bool IsAdminRoute(string route, string method)
    {
        switch (method)
        {
            case "GET":
                return OnlyAdminGetRoutes.Any(r => Regex.IsMatch(route.ToLower(), r.ToLower()));
            case "POST":
                return OnlyAdminPostRoutes.Any(r => Regex.IsMatch(route.ToLower(), r.ToLower()));
            case "PUT":
                return OnlyAdminPutRoutes.Any(r => Regex.IsMatch(route.ToLower(), r.ToLower()));
            case "DELETE":
                return OnlyAdminDeleteRoutes.Any(r => Regex.IsMatch(route.ToLower(), r.ToLower()));
            default:
                return false;
        }
    }


    //! VISUAL
    public static List<string> OnlyVisualGetRoutes = new List<string>()
    {
        $"^{BASE}/{YOUTUBEVIDEO}$",
    };
    public static List<string> OnlyVisualPostRoutes = new List<string>()
    {
        $"^{BASE}/{YOUTUBEVIDEO}$",
    };
    public static List<string> OnlyVisualPutRoutes = new List<string>()
    {
        $"^{BASE}/{YOUTUBEVIDEO}/\\d$",
    };
    public static List<string> OnlyVisualDeleteRoutes = new List<string>()
    {
        $"^{BASE}/{YOUTUBEVIDEO}/\\d$",
    };

    public static bool IsVisualRoute(string route, string method)
    {
        switch (method)
        {
            case "GET":
                return OnlyVisualGetRoutes.Any(r => Regex.IsMatch(route.ToLower(), r.ToLower()));
            case "POST":
                return OnlyVisualPostRoutes.Any(r => Regex.IsMatch(route.ToLower(), r.ToLower()));
            case "PUT":
                return OnlyVisualPutRoutes.Any(r => Regex.IsMatch(route.ToLower(), r.ToLower()));
            case "DELETE":
                return OnlyVisualDeleteRoutes.Any(r => Regex.IsMatch(route.ToLower(), r.ToLower()));
            default:
                return false;
        }
    }


    //! CREW
    public static List<string> OnlyCrewGetRoutes = new List<string>()
    {
        $"^{BASE}/{CONCERT}/{CONCERTUSERID}/\\d$",
        $"^{BASE}/{FESTIVALARTISTASOC}/{FESTIVALUSERID}/\\d$",
    };

    public static bool IsCrewRoute(string route, string method)
    {
        switch (method)
        {
            case "GET":
                return OnlyCrewGetRoutes.Any(r => Regex.IsMatch(route.ToLower(), r.ToLower()));
            default:
                return false;
        }
    }
}