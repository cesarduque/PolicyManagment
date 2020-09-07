using GAP.PolicyManagment.Core;
using GAP.PolicyManagment.Core.Repositories;
using GAP.PolicyManagment.Infrastructure.Repositories;
using System;

namespace GAP.PolicyManagment.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private PolicyManagmentContext _context;

        public UnitOfWork()
        {
            _context = new PolicyManagmentContext();
        }

        private IClientRepository _clientRepository;
        private ICoverageTypeRepository _coverageTypeRepository;
        private IPolicyRepository _policyRepository;
        private IRiskTypeRepository _riskTypeRepository;

        public IClientRepository Client => _clientRepository ?? (_clientRepository = new ClientRepository(_context));
        public ICoverageTypeRepository CoverageType => _coverageTypeRepository ?? (_coverageTypeRepository = new CoverageTypeRepository(_context));
        public IPolicyRepository Policy => _policyRepository ?? (_policyRepository = new PolicyRepository(_context));
        public IRiskTypeRepository RiskType => _riskTypeRepository ?? (_riskTypeRepository = new RiskTypeRepository(_context));

        public int Confirm()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
