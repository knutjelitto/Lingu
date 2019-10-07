using System.Text;

namespace Lingu.Commons
{
    public static class Namer
    {
        /// <summary>
        /// Converts a name to upper camel case
        /// </summary>
        /// <param name="name">The original name</param>
        /// <returns>The corresponding snake case name</returns>
        public static string ToUpperCamelCase(string name)
        {
            if (name == null || name.Length == 0)
                return name;
            StringBuilder builder = new StringBuilder();
            bool newWord = false;
            char c = name[0];
            if (c >= 'A' && c <= 'Z')
                builder.Append(c);
            else if (c >= 'a' && c <= 'z')
                builder.Append(char.ToUpperInvariant(c));
            else if (c >= '0' && c <= '9')
            {
                builder.Append("_");
                builder.Append(c);
                newWord = true;
            }
            else
            {
                newWord = true;
            }

            for (int i = 1; i != name.Length; i++)
            {
                c = name[i];
                if (c >= 'A' && c <= 'Z')
                {
                    if (builder.Length == 0 || newWord)
                        builder.Append(c);
                    else
                    {
                        if (name[i - 1] >= 'A' && name[i - 1] <= 'Z')
                            builder.Append(char.ToLowerInvariant(c));
                        else
                            builder.Append(c);
                    }
                    newWord = false;
                }
                else if (c >= 'a' && c <= 'z')
                {
                    builder.Append(newWord ? char.ToUpperInvariant(c) : c);
                    newWord = false;
                }
                else if (c >= '0' && c <= '9')
                {
                    builder.Append(c);
                    newWord = true;
                }
                else
                {
                    newWord = true;
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// Converts a name to lower camel case
        /// </summary>
        /// <param name="name">The original name</param>
        /// <returns>The corresponding snake case name</returns>
        public static string ToLowerCamelCase(string name)
        {
            if (name == null || name.Length == 0)
                return name;
            StringBuilder builder = new StringBuilder();
            bool newWord = false;
            char c = name[0];
            if (c >= 'A' && c <= 'Z')
                builder.Append(char.ToLowerInvariant(c));
            else if (c >= 'a' && c <= 'z')
                builder.Append(c);
            else if (c >= '0' && c <= '9')
            {
                builder.Append("_");
                builder.Append(c);
                newWord = true;
            }

            for (int i = 1; i != name.Length; i++)
            {
                c = name[i];
                if (c >= 'A' && c <= 'Z')
                {
                    if (builder.Length == 0)
                        builder.Append(char.ToLowerInvariant(c));
                    else if (newWord)
                        builder.Append(c);
                    else
                    {
                        if (name[i - 1] >= 'A' && name[i - 1] <= 'Z')
                            builder.Append(char.ToLowerInvariant(c));
                        else
                            builder.Append(c);
                    }
                    newWord = false;
                }
                else if (c >= 'a' && c <= 'z')
                {
                    builder.Append(newWord ? char.ToUpperInvariant(c) : c);
                    newWord = false;
                }
                else if (c >= '0' && c <= '9')
                {
                    builder.Append(c);
                    newWord = true;
                }
                else
                {
                    newWord = true;
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// Converts a name to upper case
        /// </summary>
        /// <param name="name">The original name</param>
        /// <returns>The corresponding snake case name</returns>
        public static string ToUpperCase(string name)
        {
            if (name == null || name.Length == 0)
                return name;
            StringBuilder builder = new StringBuilder();
            char c = name[0];
            if (c >= 'A' && c <= 'Z')
                builder.Append(c);
            else if (c >= 'a' && c <= 'z')
                builder.Append(char.ToUpperInvariant(c));
            else if (c >= '0' && c <= '9')
            {
                builder.Append("_");
                builder.Append(c);
            }
            else
                builder.Append('_');

            for (int i = 1; i != name.Length; i++)
            {
                c = name[i];
                if (c >= 'A' && c <= 'Z')
                {
                    if ((name[i - 1] >= 'a' && name[i - 1] <= 'z') || (name[i - 1] >= '0' && name[i - 1] <= '9'))
                        // preceded by a lower-case character or a number, this is a new word
                        builder.Append("_");
                    builder.Append(c);
                }
                else if (c >= 'a' && c <= 'z')
                    builder.Append(char.ToUpperInvariant(c));
                else if (c >= '0' && c <= '9')
                    builder.Append(c);
                else
                    builder.Append('_');
            }
            return builder.ToString();
        }

        /// <summary>
        /// Converts a name to snake case
        /// </summary>
        /// <param name="name">The original name</param>
        /// <returns>The corresponding snake case name</returns>
        public static string ToSnakeCase(string name)
        {
            if (name == null || name.Length == 0)
                return name;
            StringBuilder builder = new StringBuilder();
            char c = name[0];
            if (c >= 'A' && c <= 'Z')
                builder.Append(char.ToLowerInvariant(c));
            else if (c >= 'a' && c <= 'z')
                builder.Append(c);
            else if (c >= '0' && c <= '9')
            {
                builder.Append("_");
                builder.Append(c);
            }
            else
                builder.Append('_');

            for (int i = 1; i != name.Length; i++)
            {
                c = name[i];
                if (c >= 'A' && c <= 'Z')
                {
                    if ((name[i - 1] >= 'a' && name[i - 1] <= 'z') || (name[i - 1] >= '0' && name[i - 1] <= '9'))
                        // preceded by a lower-case character or a number, this is a new word
                        builder.Append("_");
                    builder.Append(char.ToLowerInvariant(c));
                }
                else if (c >= 'a' && c <= 'z')
                    builder.Append(c);
                else if (c >= '0' && c <= '9')
                    builder.Append(c);
                else
                    builder.Append('_');
            }
            return builder.ToString();
        }
    }
}
