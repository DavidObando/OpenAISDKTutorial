using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAISDKTutorial
{
    internal class Constants
    {
        public const ConsoleColor UserColor = ConsoleColor.White;
        public const ConsoleColor UIColor = ConsoleColor.Green;
        public const ConsoleColor SystemColor = ConsoleColor.Cyan;
        public const ConsoleColor DiagnosticColor = ConsoleColor.DarkBlue;
        public const ConsoleColor WarningColor = ConsoleColor.Yellow;
        public const ConsoleColor DebugColor = ConsoleColor.DarkYellow;

        public const int MaximumTokenLength = 126000; // GPT4o has a maximum token length of 128000. Token counter is approximate value.
    }
}
