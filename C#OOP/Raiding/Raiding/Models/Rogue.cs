using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private readonly int power = 80;
        public Rogue(string name) : base(name)
        {
        }
        public override int Power => power;

        public override string CastAbility()
        {
            return string.Format(Exeptiones.StringOverrideRodueWarrior, GetType().Name, Name, Power);
        }
    }
}
