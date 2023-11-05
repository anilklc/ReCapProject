using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal) 
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(int id)
        {
            var customer = _customerDal.Get(c => c.Id == id);
            if (customer != null)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.ColorDelete);
            }
            else
            {
                return new ErrorResult(Messages.ColorNotDelete);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new DataResult<List<Customer>>(_customerDal.GetAll(),true,Messages.CustomerGetall);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new DataResult<Customer>(_customerDal.Get(c=>c.Id==id),true,Messages.CustomerGetId);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
