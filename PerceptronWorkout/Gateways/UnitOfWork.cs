using PerceptronWorkout.Gateways.Context;
using PerceptronWorkout.Gateways.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.Gateways
{
    public class UnitOfWork
    {

        private static UnitOfWork _instance { get; set; }

        private Gate_And_Context _And_Context;
        private Gate_Or_Context _Or_Context;

        private Gate_And_Repository _gate_And_Repository;
        private Gate_Or_Repository _gate_Or_Repository;

        public Gate_And_Repository gate_And_Repository
        {
            get
            {
                return _gate_And_Repository == null ? _gate_And_Repository = new Gate_And_Repository(_And_Context) : _gate_And_Repository;
            }
        }

        public Gate_Or_Repository gate_Or_Repository
        {
            get
            {
                return _gate_Or_Repository == null ? _gate_Or_Repository = new Gate_Or_Repository(_Or_Context) : _gate_Or_Repository;
            }
        }


        private UnitOfWork()
        {
            _And_Context = Gate_And_Context.GetInstance();
            _Or_Context = Gate_Or_Context.GetInstance();
        }

        public static UnitOfWork GetInstance()
        {
            return _instance == null ? _instance = new UnitOfWork() : _instance;
        }

    }
}
