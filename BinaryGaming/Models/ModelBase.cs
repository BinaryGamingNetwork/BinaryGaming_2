using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BinaryGaming;

namespace BinaryGaming.Models
{
    public class ModelBase
    {
//        private String connectionString;
        protected BinaryGamingDataContainer _dataContext;
        protected Controller controller { get; set; }  // The controller is made available to model classes so that user security contexts can be determined
        public String ErrorMessage { get; private set; }
        public Exception exception { get; private set; }

        public ModelBase()
        {
            ClearError();

            try
            {
                _dataContext = new BinaryGamingDataContainer();
            }
            catch (Exception e)
            {
                SetError(e);
            }
        }

        public ModelBase(Controller controller) : this()
        {
            SetController(controller);
        }

        protected void ClearError()
        {
            ErrorMessage = "";
            exception = null;
        }

        protected void SetError(Exception e)
        {
            ErrorMessage = e.Message;
            exception = e;
        }

        protected void SetError(String ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
            exception = null;
        }

        protected void SetController(Controller controller)
        {
            this.controller = controller;
        }
    }
}
