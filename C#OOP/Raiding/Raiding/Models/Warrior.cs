using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        private readonly int power = 100;
        public Warrior(string name) : base(name)
        {
        }
        public override int Power => power;
        public override string CastAbility()
        {
            return string.Format(Exeptiones.StringOverrideRodueWarrior, GetType().Name, Name, Power);
        }
    }
}
