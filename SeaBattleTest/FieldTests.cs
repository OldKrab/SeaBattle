using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaBattle;

namespace SeaBattleTest;

[TestClass]
public class FieldTests
{
    [TestMethod]
    public void Init()
    {
        Field field = new Field();
        Assert.IsNotNull(field.Ships);
        Assert.AreEqual(field.Ships.Count, 0);

        Assert.IsNotNull(field.Cells);
        Assert.AreEqual(field.Cells.GetLength(0), Field.DefaultSize);
        Assert.AreEqual(field.Cells.GetLength(1), Field.DefaultSize);
    }
}