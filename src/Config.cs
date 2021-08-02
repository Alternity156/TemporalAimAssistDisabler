using MelonLoader;
using System.Reflection;

namespace AudicaModding
{
    public static class Config
    {
        public const string Category = "TemporalAimAssistDisabler";

        public static bool Enabled;

        public static void RegisterConfig()
        {
            MelonPrefs.RegisterBool(Category, nameof(Enabled), false, "Enables the mod.");
            OnModSettingsApplied();
        }

        public static void OnModSettingsApplied()
        {
            foreach (var fieldInfo in typeof(Config).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (fieldInfo.FieldType == typeof(bool))
                    fieldInfo.SetValue(null, MelonPrefs.GetBool(Category, fieldInfo.Name));
            }
        }
    }
}