using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YCRCPracticeWebApp.Repository.Interface;

namespace YCRCPracticeWebApp.Repository
{

    /// <summary>
    /// Class UnitOfWork.
    /// </summary>
    /// <seealso cref="YCRCPracticeWebApp.Repository.Interface.IUnitOfWork" />
    public class UnitOfWork :  IUnitOfWork
    {
        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Gets or sets the data base context.
        /// </summary>
        /// <value>The data base context.</value>
        public DbContext DataBaseContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UnitOfWork(DbContext dbContext)
        {
            this.DataBaseContext = dbContext;
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int SaveChanges()
        {
            return this.DataBaseContext.SaveChanges();
        }

        /// <summary>
        /// 執行與釋放 (Free)、釋放 (Release) 或重設 Unmanaged 資源相關聯之應用程式定義的工作。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                DataBaseContext.Dispose();              
            }
            disposed = true;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
