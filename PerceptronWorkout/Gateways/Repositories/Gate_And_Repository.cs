using PerceptronWorkout.DTOs.SimplePerceptronOperations;
using PerceptronWorkout.Gateways.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.Gateways.Repositories
{
    public class Gate_And_Repository
    {

        private readonly Gate_And_Context _context;

        public Gate_And_Repository(Gate_And_Context context) => _context = context;

        public GateDataDTO gateData() => _context.gateData();

    }
}
