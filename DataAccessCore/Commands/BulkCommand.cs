using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessCore.Commands
{
    public abstract class BulkCommand<T> : ICommand<T> where T : DbContext
    {
        public event ProgressChangedEventHandler ProgressChanged;

        public int BatchSize => _batchSize;
        public int ProgressPercentage => (_totalBatchesNumber == 0) ? 0 : (_currentBatch / _totalBatchesNumber) * 100;
        protected IEnumerable<IEnumerable<object>> _batches;

        protected int _fullBatchesNumber,
            _batchSize,
            _totalBatchesNumber,
            _lastBatchSize,
            _currentBatch = 0;

        public BulkCommand(IEnumerable<object> entities, int batchSize = 10000)
        {
            if (batchSize < 1)
                throw new InvalidOperationException("BatchSize must be a positive integer number greater than 0");

            _batchSize = batchSize;
            _batches = GetBatches(entities.ToList());
        }

        protected IEnumerable<IEnumerable<object>> GetBatches(List<object> inputList)
        {
            _fullBatchesNumber = 0;
            _totalBatchesNumber = 0;
            _lastBatchSize = 0;


            List<IEnumerable<object>> output = new List<IEnumerable<object>>();

            if (inputList.Count == 0)
                return output;

            _fullBatchesNumber = inputList.Count / _batchSize;
            _lastBatchSize = inputList.Count % _batchSize;
            _totalBatchesNumber = (_lastBatchSize != 0) ? _fullBatchesNumber + 1 : _fullBatchesNumber;
            
            for (int counter = 0; counter < _fullBatchesNumber; counter++)
                output.Add(inputList.GetRange(counter*BatchSize, _batchSize));

            if (_lastBatchSize != 0)
                output.Add(inputList.GetRange(_fullBatchesNumber * _batchSize, _lastBatchSize));

            return output;
        }
        
        protected virtual void RaiseProgressChanged()
        {
            ProgressChangedEventArgs e = new ProgressChangedEventArgs(ProgressPercentage, null);

            ProgressChanged.Invoke(this, e);
        }


        public virtual void Execute(T context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (_batches == null)
                throw new ArgumentNullException("Entities");

            if (_batches.Count() == 0)
                return;

            foreach (IEnumerable<object> batch in _batches)
            {
                
                using (IDbContextTransaction currentTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        ExecuteBatch(batch, context);
                        currentTransaction.Commit();
                    }

                    catch (Exception e)
                    {
                        currentTransaction.Rollback();
                        throw new DbUpdateException("Command Execution Failure: " + e.Message, e);
                    }
                }
            }

            context.Dispose();
        }

        protected abstract void ExecuteBatch(IEnumerable<object> batch, T context);
    }
}
