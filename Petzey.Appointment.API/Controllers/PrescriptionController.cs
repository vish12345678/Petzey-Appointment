﻿using Petzey.Appointments.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Petzey.Appointments.API.Controllers
{
    public class PrescriptionController : ApiController
    {
        IAppointmentManager _appointmentManager;
        public PrescriptionController()
        {
            this._appointmentManager = new AppointmentManager();
        }
        public PrescriptionController(IAppointmentManager appointmentManager)
        {
            this._appointmentManager = appointmentManager;   
        }

        //api/prescription/pet/id
        [Route("api/prescription/pet/{id}")]
        public IHttpActionResult GetAllPrescription(long id)
        {
            var res = _appointmentManager.GetAllPrescriptionByPetId(id);
            if (res.Count >= 1)
                return Ok(res);
            else
                return BadRequest();
        }

        //api/prescription/pet/recent
        [Route("api/prescription/pet/recent")]
        public IHttpActionResult GetPrescription(long id)
        {
            var res = _appointmentManager.GetRecentPrescriptionByPetId(id);
            if (res != null)
                return Ok(res);
            else
                return BadRequest();
        }

        //api/prescription/pet/rec
        [Route("api/prescription/update")]
        public IHttpActionResult PutPrescription([FromBody] DTOPrescription dto)
        {
            try
            {
                return Ok(_appointmentManager.UpdatePrescription(dto));

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
