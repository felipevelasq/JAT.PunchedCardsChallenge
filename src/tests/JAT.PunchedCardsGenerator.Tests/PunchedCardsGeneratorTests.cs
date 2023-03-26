namespace JAT.PunchedCardsGenerator.Tests;

public class PunchedCardGeneratorTests
{
    public static IEnumerable<object[]> PunchedCardsScenariosTestData
    {
        get
        {
            var punchedCard1x1 =
            @"
..+
..|
+-+";
            // var punchedCard1x1 = "..+\r\n..|\r\n+-+";
            var punchedCard2x2 =
            @"
..+-+
..|.|
+-+-+
|.|.|
+-+-+";
            // var punchedCard2x2 = "..+-+\r\n..|.|\r\n+-+-+\r\n|.|.|\r\n+-+-+";
            var punchedCard3x3 =
            @"
..+-+-+
..|.|.|
+-+-+-+
|.|.|.|
+-+-+-+
|.|.|.|
+-+-+-+";
            // var punchedCard3x3 = "..+-+-+\r\n..|.|.|\r\n+-+-+-+\r\n|.|.|.|\r\n+-+-+-+\r\n|.|.|.|\r\n+-+-+-+";
            yield return new object[] { 1, 1, punchedCard1x1.Remove(0, 2) };
            yield return new object[] { 2, 2, punchedCard2x2.Remove(0, 2) };
            yield return new object[] { 3, 3, punchedCard3x3.Remove(0, 2) };
        }
    }

    [Theory]
    [MemberData(nameof(PunchedCardsScenariosTestData))]
    public void PunchedCardGeneratorTest(int nRowns, int nColumns, string expectedPunchedCard)
    {
        using (StreamReader reader = new StreamReader(PunchedCardGenerator.Generate(nRowns, nColumns)))
        {
            var generatedPunchedCard = reader.ReadToEnd();
            Assert.Equal(expectedPunchedCard, generatedPunchedCard);
        }
    }
}