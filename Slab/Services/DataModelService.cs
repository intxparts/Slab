using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slab.Services
{
    public interface IDataModelService
    { 
        DataModel DataModel { get; set; }
    }


    public class DataModelService : IDataModelService
    {
        private DataModel _dataModel;
        DataModel IDataModelService.DataModel 
        { 
            get { return _dataModel; }
            set
            {
                _dataModel = value;
            }
        }
    }
}
