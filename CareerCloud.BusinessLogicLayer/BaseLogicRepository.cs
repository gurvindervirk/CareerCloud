using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
   public abstract class BaseLogicRepository<TPoco>
         where TPoco : IPoco
    {
        protected IGenericRepository<TPoco> _repository;

        public BaseLogicRepository(IGenericRepository<TPoco> repository)
        {
            _repository = repository;
        }
        protected virtual void Verify(TPoco pocos)
        {
            return;
        }
        public virtual TPoco Get(Guid Id)
        {
            return _repository.GetById(Id);
        }
        public virtual List<TPoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual void Add(TPoco pocos)
        {
            
                if (pocos.Id == Guid.Empty)
                {
                    pocos.Id = Guid.NewGuid();
                }
          _repository.Insert(pocos);
            _repository.Save();
        }

        public virtual void Update(TPoco pocos)
        {
            _repository.Update(pocos);
            _repository.Save();
        }
        public void Delete(TPoco pocos)
        {
            _repository.Delete(pocos);
        }
    }
}

