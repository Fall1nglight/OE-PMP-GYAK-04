using System.Security.Cryptography.X509Certificates;

namespace OE_PMP_GYAK_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2. feladat
            string palSentence = "Géza kék az ég.";
            char[] marks = { '.', '?', '!' };
            string modifiedPalSentence = palSentence.Replace(" ", String.Empty).ToLower();

            // eltávolítjuk a mondatvégi írásjeleket
            while (
                Array.Exists(marks, m => m == modifiedPalSentence[modifiedPalSentence.Length - 1])
            )
            {
                modifiedPalSentence = modifiedPalSentence.Substring(
                    0,
                    modifiedPalSentence.Length - 1
                );
            }

            // megfordítjuk a stringet (lehetne 'for' ciklussal is)
            char[] reversedArr = modifiedPalSentence.ToCharArray();
            Array.Reverse(reversedArr);
            string reversedPalSentence = new string(reversedArr);

            Console.WriteLine($"{palSentence}");

            if (modifiedPalSentence == reversedPalSentence)
            {
                Console.WriteLine("A szöveg palindróm volt.");
            }

            // 3. feladat
            string[] plates = { "aabc 123", "a a BC123", "a a B c 1 2 3", "AABc-123" };

            foreach (string p in plates)
            {
                string tmp_plate = p.Replace(" ", String.Empty)
                    .Replace("-", String.Empty)
                    .ToUpper();

                string letters_ = tmp_plate.Substring(0, 4);
                string lettersFP = letters_.Substring(0, 2);
                string lettersSP = letters_.Substring(2);
                string numbers = tmp_plate.Substring(4);

                Console.WriteLine($"{lettersFP} {lettersSP}-{numbers}");
            }

            // 6. feladat

            // random karaktert generál 0-9 és a-z között
            static char getRandomChar()
            {
                char result = ' ';
                Random rand = new Random();

                if (rand.Next(2) == 0)
                {
                    int rndNumber = rand.Next(0, 10);
                    result = char.Parse(rndNumber.ToString());
                }
                else
                {
                    int abcBegin = 'a';
                    int abcEnd = 'z';
                    int rndCharCode = rand.Next(abcBegin, abcEnd + 1);
                    result = (char)rndCharCode;
                }

                return result;
            }

            static string generateNeptunId()
            {
                string neptunId = string.Empty;
                while (neptunId.Length != 6)
                {
                    char rndChar = getRandomChar();
                    neptunId += rndChar;

                    if (!char.IsLetter(neptunId[0]))
                        neptunId = string.Empty;
                }

                return neptunId.ToUpper();
            }

            string tmpNeptunId = string.Empty;
            string myNeptunId = "FKT9QE";

            int numOfTries = 0;
            while (tmpNeptunId != myNeptunId)
            {
                Console.WriteLine(tmpNeptunId);
                tmpNeptunId = generateNeptunId();
                numOfTries++;
            }

            Console.WriteLine($"A generált kód: {myNeptunId}, próbák száma: {numOfTries}");

            // 8. feladat
            string strToMatrix =
                "Vincent;Vega;Vince\nMarsellus;Wallace;Big Man\nWinston;Wolf;The Wolf";

            string[] lines = strToMatrix.Split('\n');

            // erre szükségünk van a dinamikusság miatt
            int maxRows = 0;
            foreach (string l in lines)
            {
                string[] words = l.Split(";");

                if (words.Length > maxRows)
                    maxRows = words.Length;
            }

            string[,] matrix = new string[lines.Length, maxRows];

            // mátrix feltöltése
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] word = line.Split(";");

                for (int j = 0; j < word.Length; j++)
                {
                    matrix[i, j] = word[j];
                }
            }

            // mátrix kiiratása
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " | ");
                }
                Console.WriteLine("\n-----------------------------------");
            }
        }
    }
}
