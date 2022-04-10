using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        private readonly int power = 100;
        public Paladin(string name) : base(name)
        {
        }
        public override int Power => power;

        public override string CastAbility()
        {
            return string.Format(Exeptiones.StringOverrideDruidPaladin, GetType().Name, Name, Power);
        }
    }
}
