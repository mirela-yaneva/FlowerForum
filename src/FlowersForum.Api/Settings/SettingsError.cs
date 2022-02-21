namespace FlowersForum.Api.Settings
{
    public class SettingsError
    {
        public SettingsError(string fieldName, string cause)
        {
            FieldName = fieldName;
            Cause = cause;
        }

        public string FieldName { get; }
        public string Cause { get; }
    }
}
