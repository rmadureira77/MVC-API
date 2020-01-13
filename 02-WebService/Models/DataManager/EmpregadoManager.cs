using _01_DAL;
using _02_WebService.Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_WebService.Models.DataManager
{
    public class EmpregadoManager : IDataRepositorio<Empregado>
    {
        readonly DataContext _dataContext;

        public EmpregadoManager(DataContext context)
        {
            _dataContext = context;
        }

        public IEnumerable<Empregado> GetAll()
        {
            return _dataContext.Empregados.ToList();
        }

        public Empregado Get(int id)
        {
            return _dataContext.Empregados
                  .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Empregado entity)
        {
            _dataContext.Empregados.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Empregado empregado, Empregado entity)
        {
            empregado.NomeEmpregado = entity.NomeEmpregado;
            empregado.NumeroEmpregado = entity.NumeroEmpregado;
            empregado.UserEmpregado = entity.UserEmpregado;
                
            

            _dataContext.SaveChanges();
        }

        public void Delete(Empregado empregado)
        {
            _dataContext.Empregados.Remove(empregado);
            _dataContext.SaveChanges();
        }
    }

}
