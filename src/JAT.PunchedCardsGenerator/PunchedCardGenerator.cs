namespace JAT.PunchedCardsGenerator;
public class PunchedCardGenerator
{
    public static MemoryStream Generate(int rowsAmount, int columnsAmount)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);

        var characterRowsAmount = (rowsAmount * 2) + 1;
        var characterColumnsAmount = columnsAmount == 1 || columnsAmount % 2 == 0 ? (columnsAmount * 2) + 1 : (columnsAmount * 2) + 1;

        for (int characterRowIndex = 1; characterRowIndex <= (characterRowsAmount); characterRowIndex++)
        {
            for (int characterColumnIndex = 1; characterColumnIndex <= (characterColumnsAmount); characterColumnIndex++)
            {
                char nextCharacter = ' ';
                if (characterColumnIndex < 3 && characterRowIndex < 3)
                {
                    nextCharacter = '.';
                }
                else
                {
                    if (characterColumnIndex % 2 >= 1)
                    {
                        nextCharacter = characterRowIndex % 2 >= 1 ? '+' : '|';
                    }
                    else
                    {
                        nextCharacter = characterRowIndex == 1 || characterRowIndex % 2 >= 1 ? '-' : '.';
                    }
                }
                writer.Write(nextCharacter);
            }

            if (characterRowIndex < characterRowsAmount)
                writer.Write("\r\n");
        }
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
}
