using System;
using WordLearning.Infrastructure.UnitOfWorks;
using WordLearning.Domain.Entry;
using WordLearning.Domain.Repositories;

namespace WordLearning.Infrastructure.Repositories
{
    [Module]
    public class XmlWlRootFolderRepository : IWlRootFolderRepository
    {
        private readonly XmlUnitOfWork _unitOfWork;

        public XmlWlRootFolderRepository(XmlUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public event EventHandler OnCommited;

        public void Delete(WlRootFolder aggregateRoot)
        {
            _unitOfWork.ChangeEntityState(aggregateRoot, EntityState.Deleted);
        }

        public WlRootFolder GetById(int id)
        {
            return _unitOfWork.GetAggregateRoot<WlRootFolder>(id);
        }

        public void Insert(WlRootFolder aggregateRoot)
        {
            _unitOfWork.Add(aggregateRoot);
        }

        public void Save()
        {
            _unitOfWork.SaveChanges();
        }

        public void Update(WlRootFolder aggregateRoot)
        {
            _unitOfWork.ChangeEntityState(aggregateRoot, EntityState.Modified);
        }
    }
}