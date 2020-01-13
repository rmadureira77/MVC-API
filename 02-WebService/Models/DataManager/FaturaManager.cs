using _01_DAL;
using _02_WebService.Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_WebService.Models.DataManager
{
    
    public class FaturaManager : IDataRepositorio<Fatura>
    {
        readonly DataContext _dataContext;

        public FaturaManager(DataContext context)
        {
            _dataContext = context;
        }

        public IEnumerable<Fatura> GetAll()
        {
            return _dataContext.Faturas.ToList();
        }

        public Fatura Get(int id)
        {
            return _dataContext.Faturas
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Fatura entity)
        {
            _dataContext.Faturas.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Fatura fatura, Fatura entity)
        {
            fatura.NumeroFatura = entity.NumeroFatura;
            fatura.Data = entity.Data;
                      




            _dataContext.SaveChanges();
        }

        public void Delete(Fatura fatura)
        {
            _dataContext.Faturas.Remove(fatura);
            _dataContext.SaveChanges();
        }
    }

}