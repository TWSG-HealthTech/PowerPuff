﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPuff.Features.Medication.Models
{
    public class MedicationSchedule
    {
        public string Name;
        public DateTime TimeInDay;
        public IEnumerable<string> frequencies;
    }
}