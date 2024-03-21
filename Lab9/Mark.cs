using LAB10Classes;

namespace Lab9
{
    public class Mark : IInit
    {
        public static int InstancesCreated { get; private set; }

        private string _name { get; set; }
        public string Name { 
            get {

                return _name;
            }  
            set { 
                if (value == null) throw new ArgumentNullException("Название предмета не может быть null");
                _name = value;
            } 
        }

        private int _mark;
        public int mark
        {
            get => _mark;
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Оценка должна быть в пределах [0; 10]!");
                }
                else
                {
                    _mark = value;
                }

            }
        }

        public Mark()
        {
            InstancesCreated++;
            mark = 0;
            Name = string.Empty;
        }

        public Mark(string name, int mark)
        {
            this.Name = name;
            this.mark = mark;
            InstancesCreated++;
        }

        public Mark(Mark mark)
        {
            this.mark = mark.mark;
            this.Name = mark.Name;
            InstancesCreated++;
        }

        public void Print()
        {
            Console.WriteLine("Name: " + (Name == null || Name.Length == 0 ? "Пустое имя" : Name));
            Console.WriteLine("Mark: " + mark);
        }

        public string ConvertGrade()
        {
            return ConvertGradeStatic(this.mark);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Mark m2)
            {
                return m2.mark == mark && m2.Name == Name;
            }

            return false;
        }

        public static string ConvertGradeStatic(int mark)
        {
            if (mark < 4) return "Неудовлетворительно";
            if (mark < 6) return "Удовлетворительно";
            if (mark < 8) return "Хорошо";
            return "Отлично";
        }

        public void Init()
        {
            mark = (int)Helpers.Helpers.EnterUInt("Оценку от 0 до 10 вкл", 0, 10);
            Console.Write("Введите название предмета: ");
            Name = Console.ReadLine();
        }

        public void RandomInit()
        {
            var rnd = Helpers.Helpers.GetOrCreateRandom();

            mark = rnd.Next(0, 11);
            Name = $"Предмет" + (rnd.Next(1, int.MaxValue)).ToString();
        }

        public static Mark operator !(Mark mark)
        {
            return new Mark(mark.Name.ToUpper(), mark.mark);
        }

        public static Mark operator -(Mark mark)
        {
            return new Mark(mark.Name, 0);
        }

        public static Mark operator /(Mark m1, string newName)
        {
            return new Mark(newName, m1.mark);
        }

        public static bool operator >=(Mark m1, Mark m2)
        {
            return m1.mark >= m2.mark;
        }

        public static bool operator <=(Mark m1, Mark m2)
        {
            return m1.mark <= m2.mark;
        }

        public static explicit operator int(Mark mark)
        {
            return mark.Name.Length;
        }

        public static implicit operator bool(Mark mark)
        {
            return mark.mark >= 4;
        }


    }
}
