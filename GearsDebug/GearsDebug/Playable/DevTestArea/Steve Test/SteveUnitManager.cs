﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gears.Playable;

namespace GearsDebug
{
    sealed internal class SteveUnitManager : UnitManager
    {
        private TestUnitTypeFactory _tFactory; //theres only 1 of each type of factory afaic
        //this should be also tested with at least two different factories

        internal SteveUnitManager()
        {
            Register();
        }
        private void Register()
        {
            _tFactory = new TestUnitTypeFactory();

            List<UnitTypeFactory> _lFact = new List<UnitTypeFactory>();

            _lFact.Add(_tFactory); //iterate this for each UnitTypeFactory

            base.Register(_lFact.ToArray());

            _lFact = null; //this probably isn't necessary, is it?
        }
    }
}
