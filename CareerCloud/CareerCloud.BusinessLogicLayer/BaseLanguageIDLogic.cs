using System;
using System.Collections.Generic;
using System.Linq;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
   public abstract class BaseLanguageIDLogic<TPoco> where TPoco : ILPoco
    {
        protected IDataRepository<TPoco> _repository;
        public BaseLanguageIDLogic(IDataRepository<TPoco> repository)
        {
            _repository = repository;
        }

        protected virtual void Verify(TPoco[] pocos)
        {
            return;
        }

        public virtual TPoco Get(string LanguageID)
        {
            return _repository.GetSingle(c => c.LanguageID == LanguageID);
        }

        public virtual List<TPoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual void Add(TPoco[] pocos)
        {
            foreach (TPoco poco in pocos)
            {
               
            }

            _repository.Add(pocos);
        }

        public virtual void Update(TPoco[] pocos)
        {
            _repository.Update(pocos);
        }

        public void Delete(TPoco[] pocos)
        {
            _repository.Remove(pocos);
        }
    }
}
