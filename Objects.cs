using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    abstract public class Objects
    {
        protected string name;
        protected bool acquirable;

        public Objects( string name, bool acquirable)
        {
            this.name = name;
            this.acquirable = acquirable;
        }

        abstract protected void Description();

        public bool IsAquirable()
        {
            return acquirable;
        }

        public void SetIsAcquirable(bool acquirable)
        {
            this.acquirable = acquirable;
        }

        public bool GetAcquirable()
        {
            return acquirable;
        }

        public string GetName()
        {
            return name;
        }
    }
}
