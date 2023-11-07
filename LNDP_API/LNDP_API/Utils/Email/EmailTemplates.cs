namespace LNDP_API.Utils
{
    public class EmailTemplates
    {
        private const string templatesPath = "Utils\\Email\\HTML_Templates\\";
        public const string FROMDEFAULTEMAIL = "lndlppaginaweb@gmail.com", TODEFAULTEMAIL = "info@losninosdelapromo.es";

        public static string GetNewPromoBody(string body)
        {
            string template = File.ReadAllText(templatesPath + "NewPromo.html");
            template = template.Replace("{body}", body);

            return template;
        }
    }
}