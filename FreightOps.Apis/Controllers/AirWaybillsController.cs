using FreightOps.Common;
using FreightOps.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace FreightOps.Apis.Controllers
{
    public class AirWaybillsController : ApiController
    {
        // GET: api/AirWaybills
        public IEnumerable<MyDTO> Get()
        {
            List<MyDTO> dtos = new List<MyDTO>();
            return dtos;
        }

        // GET: api/AirWaybills/5
        public MyDTO Get(int id)
        {
            MyDTO myDto = new MyDTO();
            return myDto;
        }

        // POST: api/AirWaybills
        //[ResponseType(typeof(MyDTO))]
        public IHttpActionResult Post(MyDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtRoute("DefaultApi", new { id = dto.Id }, dto);
        }

        // PUT: api/AirWaybills/5
        public void Put(int id, MyDTO dto)
        {
            var validator = new ISO6346Validation();

            validator.Validate("CSQU3054383");
        }

        // DELETE: api/AirWaybills/5
        public void Delete(int id)
        {
        }
    }
}
