﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba10
{
    public class VRGame : VideoGame
    {
        
        public bool IsVRControllerRequired { get; private set; }
        public bool AreVRGlassesRequired { get; private set; }

        public string AreVRGlassesRequiredString => AreVRGlassesRequired ? "Да" : "Нет";
        public string IsVRControllerRequiredString => IsVRControllerRequired ? "Да" : "Нет";

        public VRGame() : base()
        {
            IsVRControllerRequired = false;
            AreVRGlassesRequired = false;
        }

        public VRGame(string name, uint minimumPlayers, uint maximumPlayers, IdNumber id, Device device, uint levelsCount, bool areVRGlassesRequired, bool isVRControllerRequired) : base(name, minimumPlayers, maximumPlayers, id, device, levelsCount)
        {
            IsVRControllerRequired = isVRControllerRequired;
            AreVRGlassesRequired = areVRGlassesRequired;
        }

        public VRGame(VRGame game) : base(game) {
            IsVRControllerRequired = game.IsVRControllerRequired;
            AreVRGlassesRequired = game.AreVRGlassesRequired;
        }

        [ExcludeFromCodeCoverage]
        public new void Show()
        {
            Console.WriteLine($"" +
                $"Нужны ли специальные очки?  {AreVRGlassesRequiredString}; " +
                $"Нужен ли специальный контроллер? {IsVRControllerRequiredString}; "
                );
        }

        [ExcludeFromCodeCoverage]
        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Show();
        }

        [ExcludeFromCodeCoverage]
        public override void Init()
        {
            base.Init();

            uint isVRContrRequired = Helpers.Helpers.EnterUInt("Нужен ли специальный контроллер для игры? 0 - нет, 1 - да", 0, 1);
            uint areGlassesRequired = Helpers.Helpers.EnterUInt("Нужны ли специальные очки для игры?  0 - нет, 1 - да", 0, 1);

            AreVRGlassesRequired = areGlassesRequired == 1;
            IsVRControllerRequired = isVRContrRequired == 1;
        }

        [ExcludeFromCodeCoverage]
        public override void RandomInit()
        {
            base.RandomInit();

            Random rnd = Helpers.Helpers.GetOrCreateRandom();

            int isVRContrRequired = rnd.Next(0, 2);
            int areGlassesRequired = rnd.Next(0, 2);

            AreVRGlassesRequired = areGlassesRequired == 1;
            IsVRControllerRequired = isVRContrRequired == 1;
        }

        public override bool Equals(object? obj)
        {
            bool parentEqual = base.Equals(obj);
            return parentEqual
                && (obj is VRGame vR)
                && IsVRControllerRequired == vR.IsVRControllerRequired
                && AreVRGlassesRequired == vR.AreVRGlassesRequired;
        }

    }
}
