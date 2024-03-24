using LAB10Classes;
using Laba10;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestParamlessConstr_SetName() // конструктор по умолчанию, св-во имени 
        {
            Game g1 = new Game();
            g1.Name = "Test";
            Assert.AreEqual("Test", g1.Name);
        }

        [TestMethod]
        public void TestParamConstructor() // конструктор  с параметрами
        {
            Game g = new Game("TestGame", 2, 5, new Game.IdNumber());
           
        }

        [TestMethod]
        public void TestMethodClone() // метод клонирования
        {
            Game g1 = new Game("TestGame", 2, 6, new Game.IdNumber());
            Game g2 = (Game)g1.Clone();
            Assert.AreNotSame(g2, g1);
        }

        [TestMethod]
        public void TestMethodSetMaximumPlayers () // setter для maximumPlayers
        {
            Game g1 = new Game("TestGame", 2, 6, new Game.IdNumber());
            g1.MaximumPlayers = 3;
            Assert.AreEqual(3, (int)g1.MaximumPlayers);
        }

        [TestMethod]
        public void TestMethodSetMaximumPlayers0()  // setter для maximumPlayers = 0
        {
            Game g1 = new Game("TestGame", 2, 6, new Game.IdNumber());
            Assert.ThrowsException<ArgumentException>(() => g1.MaximumPlayers = 0);
        }

        [TestMethod]
        public void TestMethodSetMinimumPlayers0()  // setter для minimumPlayers = 0
        {
            Game g1 = new Game("TestGame", 2, 6, new Game.IdNumber());
            Assert.ThrowsException<ArgumentException>(() => g1.MinimumPlayers = 0);
        }

        [TestMethod]
        public void TestMethodShallowCopy() // метод копирования
        {
            Game g1 = new Game("TestGame", 2, 6, new Game.IdNumber());
            Game g2 = (Game)g1.ShallowCopy();
            Assert.IsTrue(g2.Equals(g1));
            Assert.IsTrue(ReferenceEquals(g1.Id, g2.Id));
        }

        [TestMethod]
        public void TestMethodRandomInit() // случайное заполнение элемента
        {
            Game g1 = new Game();
            g1.RandomInit();
            Assert.IsNotNull(g1.Name);
            Assert.IsNotNull(g1.Id);
            Assert.IsTrue(g1.MinimumPlayers <= g1.MaximumPlayers);
        }

        [TestMethod]
        public void TestMethodCompareTo() // сравнение объектов
        {
            Game g1 = new Game { Name = "A" };
            Game g2 = new Game { Name = "B" };
            Assert.IsTrue(g1.CompareTo(g2) < 0);
        }

        [TestMethod]
        public void TestMethodSetIDException() // присваивание отрицательного значения в id -> exception
        {
            Assert.ThrowsException<ArgumentException>(() => new Game.IdNumber(-1));
        }

        [TestMethod]
        public void TestMethodIdComparison() // сравнение id
        {
            Game.IdNumber id1 = new Game.IdNumber(999);
            Game.IdNumber id2 = new Game.IdNumber(999);
            Assert.IsTrue(id1.Equals(id2));
        }

        [TestMethod]
        public void TestMethodDifferentID() // сравнение разных id
        {
            Game.IdNumber id1 = new Game.IdNumber(10);
            Game.IdNumber id2 = new Game.IdNumber(5);
            Assert.IsFalse(id1.Equals(id2));
        }

        [TestMethod]
        public void TestMethodIdToString()
        {
            Game.IdNumber id1 = new Game.IdNumber(41);
            Assert.AreEqual("41", id1.ToString());
        }

        //TABLE GAME TESTS

        [TestMethod]
        public void TestMethodTableGameConstructorWithoutParams() // конструктор без параметров
        {
            TableGame tg = new TableGame();
            Assert.IsFalse(tg.IsSpecialFieldRequired);
            Assert.IsFalse(tg.AreCardsRequired);
            Assert.IsFalse(tg.AreFishkiRequired);
            Assert.IsFalse(tg.AreKostiRequired);
        }

        [TestMethod]
        public void TestMethodTableGameConstructorWithParams() // конструктор с параметрами
        {
            TableGame tg = new TableGame("TestGame", 1, 4, new Game.IdNumber(), true, true, true, true);
            Assert.AreEqual("TestGame", tg.Name);
            Assert.AreEqual(1, (int)tg.MinimumPlayers);
            Assert.AreEqual(4, (int)tg.MaximumPlayers);
            Assert.IsTrue(tg.IsSpecialFieldRequired);
            Assert.IsTrue(tg.AreCardsRequired);
            Assert.IsTrue(tg.AreFishkiRequired);
            Assert.IsTrue(tg.AreKostiRequired);
        }

        [TestMethod]
        public void TestMethodTableGameRandomInit() // случайное заполнение элементов
        {
            TableGame tg = new TableGame();
            tg.RandomInit();
            Assert.IsNotNull(tg.Name);
        }

        [TestMethod]
        public void TestMethodCompareTableGamesEqual() // одинаковые объекты
        {
            TableGame tg1 = new TableGame("TestGame", 1, 4, new Game.IdNumber(1), true, true, true, true);
            TableGame tg2 = new TableGame("TestGame", 1, 4, new Game.IdNumber(1), true, true, true, true);

            Assert.IsTrue(tg1.Equals(tg2));
        }

        [TestMethod]
        public void TestMethodCompareTableGamesNotEqual() // одинаковые объекты
        {
            TableGame tg1 = new TableGame("TestGame", 1, 4, new Game.IdNumber(1), false, true, true, true);
            TableGame tg2 = new TableGame("TestGame", 1, 4, new Game.IdNumber(1), true, true, true, true);

            Assert.IsFalse(tg1.Equals(tg2));
        }

        //VIDEO GAMES
        [TestMethod]
        public void TestMethodVideoGameConstructorWithoutParams()
        {
            VideoGame vg = new VideoGame();
            Assert.AreEqual(Device.Mobile, vg.Device);
            Assert.AreEqual(1, (int)vg.LevelCount);
        }

        [TestMethod]
        public void TestMethodVideoGameConstructorWithParams()
        {
            VideoGame vg = new VideoGame("TestGame", 1, 4, new Game.IdNumber(), Device.Pc, 10);
            Assert.AreEqual(Device.Pc, vg.Device);
            Assert.AreEqual(10, (int)vg.LevelCount);
        }

        [TestMethod]
        public void TestMethodVideoGameRandomInit() // случайное заполнение элементов
        {
            VideoGame vg = new VideoGame();
            vg.RandomInit();
            Assert.IsNotNull(vg.Name);
            Assert.IsTrue(vg.LevelCount != 0);
        }

        [TestMethod]
        public void TestMethodVideoGamesCompareEqual() // одинаковые объекты
        {
            VideoGame vg1 = new VideoGame("TestGame", 1, 4, new Game.IdNumber(1), Device.Pc, 10);
            VideoGame vg2 = new VideoGame("TestGame", 1, 4, new Game.IdNumber(1), Device.Pc, 10);
            Assert.IsTrue(vg1.Equals(vg2));
        }

        [TestMethod]
        public void TestMethodVideoGamesCompareNotEqual() // разные объекты
        {
            VideoGame vg1 = new VideoGame("TestGame", 1, 4, new Game.IdNumber(1), Device.Mobile, 10);
            VideoGame vg2 = new VideoGame("TestGame", 1, 4, new Game.IdNumber(1), Device.Pc, 10);
            Assert.IsFalse(vg1.Equals(vg2));
        }

        //VR GAMES
        [TestMethod]
        public void TestMethodVRGameConstructorWithoutParams()
        {
            VRGame vg = new VRGame();
            Assert.AreEqual(Device.Mobile, vg.Device);
            Assert.AreEqual(1, (int)vg.LevelCount);
            Assert.AreEqual(vg.AreVRGlassesRequired, false);
            Assert.AreEqual(vg.IsVRControllerRequired, false);
        }

        [TestMethod]
        public void TestMethodVRGameConstructorWithParams()
        {
            VRGame vg = new VRGame("TestGame", 1, 4, new Game.IdNumber(), Device.Pc, 10, true, true);
            Assert.AreEqual(Device.Pc, vg.Device);
            Assert.AreEqual(10, (int)vg.LevelCount);
            Assert.AreEqual(vg.AreVRGlassesRequired, true);
            Assert.AreEqual(vg.IsVRControllerRequired, true);
        }

        [TestMethod]
        public void TestMethodVRGameRandomInit() // случайное заполнение элементов
        {
            VideoGame vg = new VideoGame();
            vg.RandomInit();
            Assert.IsNotNull(vg.Name);
            Assert.IsTrue(vg.LevelCount != 0);
        }

        [TestMethod]
        public void TestMethodVRGameCompareEqual() // одинаковые объекты
        {
            VRGame vg1 = new VRGame("TestGame", 1, 4, new Game.IdNumber(1), Device.Pc, 10, true, true);
            VRGame vg2 = new VRGame("TestGame", 1, 4, new Game.IdNumber(1), Device.Pc, 10, true, true);
            Assert.IsTrue(vg1.Equals(vg2));
        }

        [TestMethod]
        public void TestMethodVRGamesCompareEqual() // разные объекты
        {
            VRGame vg1 = new VRGame("TestGame", 1, 4, new Game.IdNumber(1), Device.Pc, 10, true, true);
            VRGame vg2 = new VRGame("TestGame", 1, 4, new Game.IdNumber(1), Device.Pc, 10, false, true);
            Assert.IsFalse(vg1.Equals(vg2));
        }

        [TestMethod]
        public void TestMethodAreVideoGameAndVRGameEqual()
        {
            VRGame vg1 = new VRGame("TestGame", 1, 4, new Game.IdNumber(1), Device.Pc, 10, true, true);
            VideoGame vg2 = new VideoGame("TestGame", 1, 4, new Game.IdNumber(1), Device.Pc, 10);

            Assert.IsFalse(vg1.Equals(vg2));
        }

        [TestMethod]
        public void TestMethodAreGameAndVRGameEqual()
        {
            VRGame vg1 = new VRGame("TestGame", 1, 4, new Game.IdNumber(1), Device.Pc, 10, true, true);
            Game vg2 = new Game("TestGame", 1, 4, new Game.IdNumber(1));

            Assert.IsFalse(vg1.Equals(vg2));
        }

        [TestMethod]
        public void TestMethodAreTableGameAndVRGameEqual()
        {
            VRGame vg1 = new VRGame("TestGame", 1, 4, new Game.IdNumber(1), Device.Pc, 10, true, true);
            TableGame vg2 = new TableGame("TestGame", 1, 4, new Game.IdNumber(1), true, true, true, true);

            Assert.IsFalse(vg1.Equals(vg2));
        }

        //внешний компаратор
        [TestMethod]
        public void TestMethodComparerNULL() // x & y NULL!
        {
            MaximumPlayersComparer comparer = new MaximumPlayersComparer();
            Assert.AreEqual(-1, comparer.Compare(null, null));
        }

        [TestMethod]
        public void TestMethodComparerNonHierarchyTypes() // x, y - не объекты нужного класса
        {
            MaximumPlayersComparer comparer = new MaximumPlayersComparer();
            Assert.AreEqual(-1, comparer.Compare(new object(), new object()));
        }

        [TestMethod]
        public void TestMethodComparerLessThan() // x < y
        {
            Game g1 = new Game("TestGame", 1, 4, new Game.IdNumber());
            Game g2 = new Game("TestGame", 1, 8, new Game.IdNumber());
            MaximumPlayersComparer comparer = new MaximumPlayersComparer();
            Assert.AreEqual(-1, comparer.Compare(g1, g2));
        }

        [TestMethod]
        public void TestMethodComparerEquality() // x = y
        {
            Game g1 = new Game("TestGame", 1, 8, new Game.IdNumber());
            Game g2 = new Game("TestGame", 1, 8, new Game.IdNumber());
            MaximumPlayersComparer comparer = new MaximumPlayersComparer();
            Assert.AreEqual(0, comparer.Compare(g1, g2));
        }

        [TestMethod]
        public void TestMethodComparerGreaterThan() // x > y
        {
            Game g1 = new Game("TestGame", 1, 8, new Game.IdNumber());
            Game g2 = new Game("TestGame", 1, 4, new Game.IdNumber());
            MaximumPlayersComparer comparer = new MaximumPlayersComparer();
            Assert.AreEqual(1, comparer.Compare(g1, g2));
        }
    }
}