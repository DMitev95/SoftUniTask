using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {

        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public virtual int Power { get; private set; }
        public virtual string CastAbility()
        {
            return null;
        }
    }
}
