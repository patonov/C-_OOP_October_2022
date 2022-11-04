using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories.Contracts
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> formulaOneCars;

        public FormulaOneCarRepository()
        {
            this.formulaOneCars = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => formulaOneCars;

        public void Add(IFormulaOneCar model)
        {
            this.formulaOneCars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this.formulaOneCars.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {            
            return this.formulaOneCars.Remove(model);
        }
    }
}
