using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Saleular.DAL;
using Saleular.Interfaces;
using Saleular.Models;

namespace Saleular.Controllers
{
    public class SaleularServicesController : ApiController
    {
        protected IGadgetRepository Gadget;
        public SaleularServicesController()
        {
            Gadget = new GadgetRepository();            
        }

        [Route("saleularservices/gadgets")]
        [HttpGet]        
        public IEnumerable<Gadget> GetAllGadgets()
        {            
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            return gadgetsRepository.GetGadgets();
        }
        
        [Route("saleularservices/gadgets/{id}")]
        [HttpGet]        
        public Gadget GetGadget(int id)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            return Gadget.GetGadgetById(id);
        }

        [Route("saleularservices/gadgets/{type}/models")]
        [HttpGet]
        public IEnumerable<string> GetGadget(string type)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            return Gadget.GetDistinctModels(type);
        }

        [Route("saleularservices/gadgets/{type}/{model}")]
        [HttpGet]
        public IEnumerable<Gadget> GetGadget(string type, string model)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            return Gadget.GetGadgets().Where(g => g.Type == type
                && g.Model == model);
        }

        [Route("saleularservices/gadgets/{type}/{model}/{carrier}")]
        [HttpGet]
        public IEnumerable<Gadget> GetGadget(string type, string model, string carrier)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            return Gadget.GetGadgets().Where(g => g.Type == type
                && g.Model == model
                && g.Carrier == carrier);
        }

        [Route("saleularservices/gadgets/{type}/{model}/{carrier}/{capacity}")]
        [HttpGet]
        public IEnumerable<Gadget> GetGadget(string type, string model, string carrier, string capacity)
        {
            IGadgetRepository gadgetsRepository = new GadgetRepository();
            return Gadget.GetGadgets().Where(g => g.Type == type
                && g.Model == model
                && g.Carrier == carrier
                && g.Capacity == capacity);
        }

        [Route("saleularservices/gadgets")]
        [HttpPost]
        // UPDATE
        public Gadget Post(Gadget gadget)
        {
            Gadget.UpdateGadget(gadget);
            return gadget;
        }

        [HttpPut]
        // CREATE
        public void Put(Gadget gadget)
        {
            Gadget.InsertGadget(gadget);
        }

        [HttpDelete]
        // DELETE 
        public void Delete(int id)
        {
            Gadget.DeleteGadget(id);
        }
    }
}
