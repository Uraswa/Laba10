using LAB10Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba10
{
    public class TableGame : Game
    {

        public bool IsSpecialFieldRequired { get; private set; }
        public bool AreCardsRequired { get; private set; }
        public bool AreKostiRequired { get; private set; }

        public bool AreFishkiRequired { get; private set; }

        public string IsSpecialFieldRequiredString => IsSpecialFieldRequired ? "Да" : "Нет";
        public string AreCardsRequiredString => AreCardsRequired ? "Да" : "Нет";
        public string AreKostiRequiredString => AreKostiRequired ? "Да" : "Нет";
        public string AreFishkiRequiredString => AreFishkiRequired ? "Да" : "Нет";

        public TableGame() : base()
        {
            IsSpecialFieldRequired = false;
            AreCardsRequired = false;
            AreKostiRequired = false;
            AreFishkiRequired = false;
        }

        public TableGame(string name, uint minimumPlayers, uint maximumPlayers, IdNumber id, bool isSpecialFieldRequired, bool areCardsRequired, bool areKostiRequired, bool areFishkiRequired) : base(name, minimumPlayers, maximumPlayers, id)
        {
            IsSpecialFieldRequired = isSpecialFieldRequired;
            AreCardsRequired = areCardsRequired;
            AreKostiRequired = areKostiRequired;
            AreFishkiRequired = areFishkiRequired;
        }

        public TableGame(TableGame tableGame) : base(tableGame)
        {
            IsSpecialFieldRequired = tableGame.IsSpecialFieldRequired;
            AreCardsRequired = tableGame.AreCardsRequired;
            AreKostiRequired = tableGame.AreKostiRequired;
            AreFishkiRequired = tableGame.AreFishkiRequired;
        }

        public new void Show()
        {
            Console.WriteLine($"" +
                $"Нужно ли специальное поле? {IsSpecialFieldRequiredString}; " +
                $"Нужны ли карты? {AreCardsRequiredString}; " +
                $"Нужны ли кости? {AreKostiRequiredString}; " +
                $"Нужны ли фишки? {AreFishkiRequiredString}"
                );
        }

        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Show();
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();

            IsSpecialFieldRequired = Helpers.Helpers.EnterUInt("Нужно ли специальное поле? 0 - нет, 1 - да", 0, 1) == 1;
            AreCardsRequired = Helpers.Helpers.EnterUInt("Нужны карты? 0 - нет, 1 - да", 0, 1) == 1;
            AreKostiRequired= Helpers.Helpers.EnterUInt("Нужны ли кости? 0 - нет, 1 - да", 0, 1) == 1;
            AreFishkiRequired = Helpers.Helpers.EnterUInt("Нужны ли фишки? 0 - нет, 1 - да", 0, 1) == 1;
        }

        public override void RandomInit()
        {
            base.RandomInit();

            Random rnd = Helpers.Helpers.GetOrCreateRandom();
            IsSpecialFieldRequired = rnd.Next(0, 2) == 1;
            AreCardsRequired = rnd.Next(0, 2) == 1;
            AreKostiRequired = rnd.Next(0, 2) == 1;
            AreFishkiRequired = rnd.Next(0, 2) == 1;
        }

        public override bool Equals(object? obj)
        {
            bool parentEqual = base.Equals(obj);
            return parentEqual
                && (obj is TableGame tableGame2)
                && (tableGame2.IsSpecialFieldRequired == IsSpecialFieldRequired)
                && (tableGame2.AreCardsRequired == AreCardsRequired)
                && (tableGame2.AreKostiRequired == AreKostiRequired)
                && (tableGame2.AreFishkiRequired == AreFishkiRequired);
        }


    }
}
